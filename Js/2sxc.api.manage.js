﻿
$2sxc.getManageController = function(id) {

    var moduleElement = $('.DnnModule-' + id);
    var manageInfo = $.parseJSON(moduleElement.find('.Mod2sxcC, .Mod2sxcappC').attr('data-2sxc')).manage;
    var config = manageInfo.config;
    var isEditMode = manageInfo.isEditMode;
    var sf = $.ServicesFramework(id);

    var manageController = {

        isEditMode: function() {
            return isEditMode;
        },

        // The config object has the following properties:
        // portalId, tabId, moduleId, contentGroupId, dialogUrl, returnUrl, appPath
        config: config,

        getLink: function (settings) {
            settings = $.extend({}, config, settings);

            var params = {
                ctl: 'editcontentgroup',
                mid: settings.moduleId
            };

            if (settings.cultureDimension && settings.cultureDimension != null)
                params.cultureDimension = settings.cultureDimension;

            if (settings.action == 'new') {
                params.editMode = "New";
            }

            if (!settings.useModuleList) {
                if (settings.action != 'new')
                    params.entityId = settings.entityId;
                if(settings.attributeSetName)
                    params.attributeSetName = settings.attributeSetName;
            } else {
                params.sortOrder = settings.sortOrder;
                params.contentGroupId = settings.contentGroupId;
            }

            if (settings.prefill)
                params.prefill = JSON.stringify(settings.prefill);

            return settings.dialogUrl
                + (settings.dialogUrl.indexOf('?') == -1 ? '?' : '&')
                + $.param(params);
        },

        _openDialog: function(settings) {

            var link = manageController.getLink(settings);

            if (window.dnnModal && dnnModal.show) {
                link += (link.indexOf('?') == -1 ? '?' : '&') + "popUp=true";
                dnnModal.show(link, /*showReturn*/true, 550, 950, true, '');
            } else {
                window.location = link;
            }
            
        },

        action: function(settings) {
            if (settings.action == 'edit' || settings.action == 'new')
                manageController._openDialog(settings);
            else if (settings.action == 'add') {

                $.ajax({
                    type: "GET",
                    dataType: "json",
                    async: false,
                    url: sf.getServiceRoot('2sxc') + "View/ContentGroup/" + "AddItem",
                    data: { sortOrder: settings.sortOrder },
                    beforeSend: sf.setModuleHeaders
                }).done(function (e) {
                    window.location.reload();
                }).error(function (e) {
                    if (window.console) {
                        console.log("Error: Could not add item. Status: " + e.status + " - " + e.statusText);
                    }
                });

            } else {
                throw "Action " + settings.action + " not known.";
            }
        },

        getButton: function (settings) {


            if (settings.entity && settings.entity._2sxcEditInformation) {
                if (settings.entity._2sxcEditInformation.entityId) {
                    settings.entityId = settings.entity._2sxcEditInformation.entityId;
                }
                if (settings.entity._2sxcEditInformation.sortOrder != null) {
                    settings.sortOrder = settings.entity._2sxcEditInformation.sortOrder;
                    settings.useModuleList = true;
                }
                delete settings.entity;
            }

            //settings = $.extend({}, config, settings);
            var button = $('<a />', {
                'class': 'sc-' + settings.action,
                'onclick': 'javascript:$2sxc(' + id + ').manage.action(' + JSON.stringify(settings) + ');'
            });

            var title = "Edit";
            switch(settings.action) {
                case "add":
                    title = "Add";
                    break;
                case "new":
                    title = "New";
                    break;
            }

            if (settings.action == "edit") {
                if (settings.isPublished == null || settings.isPublished == true) {
                    button.addClass("sc-published");
                    title = title + " (published)";
                } else {
                    button.addClass("sc-draft");
                    title = title + " (unpublished)";
                }
            }

            button.attr("title", title);

            return button[0].outerHTML;
        },

        // Builds the toolbar and returns it as HTML
        getToolbar: function (settings) {


            var buttons = [];

            if (settings.action)
                settings = [settings];
            
            if ($.isArray(settings)) {
                buttons = settings;
            } else {

                buttons = [
                    $.extend({ action: 'edit' }, settings)
                ];

                if (config.isList && settings.sortOrder != -1) {
                    buttons.push($.extend({ action: 'add' }, settings));
                    buttons.push($.extend({ action: 'new' }, settings));
                }
            }

            var toolbar = $('<ul />', { 'class': 'sc-menu', 'onclick': 'javascript: var e = arguments[0] || window.event; e.stopPropagation();' });

            for (var i = 0; i < buttons.length; i++)
                toolbar.append($('<li />').append($(manageController.getButton(buttons[i]))));

            return toolbar[0].outerHTML;
        },

        _setTemplateChooserState: function (state)
        {
            $.ajax({
                type: "GET",
                dataType: "json",
                async: false,
                url: sf.getServiceRoot('2sxc') + "View/Module/" + "SetTemplateChooserState",
                data: { state: state },
                beforeSend: sf.setModuleHeaders
            }).done(function (e) {
                window.location.reload();
            }).error(function (e) {
                if (window.console) {
                    console.log("Error: Could not set template chooser state. Status: " + e.status + " - " + e.statusText);
                }
            });
        }

    };

    return manageController;
}