(window.webpackJsonp=window.webpackJsonp||[]).push([[28],{"0bV3":function(t,e,n){"use strict";n.r(e),n.d(e,"ExportAppPartsComponent",(function(){return B}));var o=n("D57K"),i=n("o9tz"),c=n("1C3z"),p=n("BLjT"),r=n("bkzA"),a=n("S36y"),s=n("hOvr"),l=n("LuBX"),b=n("ZSGP"),f=n("8AiQ"),u=n("OeRG"),h=n("9HSk"),d=n("Qc/f"),g=n("Uk43"),m=n("Zfm5"),x=n("r4gC"),v=n("mPmy");function _(t,e){if(1&t&&(c.Wb(0,"mat-option",17),c.Qc(1),c.Vb()),2&t){var n=e.$implicit;c.oc("value",n.value),c.Bb(1),c.Sc(" ",n.name," ")}}function W(t,e){if(1&t){var n=c.Xb();c.Wb(0,"mat-icon",18),c.ec("click",(function(t){return c.Ec(n),c.ic().unlockScope(t)})),c.Qc(1,"lock"),c.Vb()}}function V(t,e){if(1&t){var n=c.Xb();c.Wb(0,"mat-icon",18),c.ec("click",(function(t){return c.Ec(n),c.ic().unlockScope(t)})),c.Qc(1,"lock_open"),c.Vb()}}function y(t,e){if(1&t){var n=c.Xb();c.Wb(0,"li",22),c.Wb(1,"div",23),c.Wb(2,"mat-checkbox",24),c.ec("ngModelChange",(function(t){return c.Ec(n),e.$implicit._export=t})),c.Wb(3,"span",25),c.Qc(4),c.Vb(),c.Vb(),c.Vb(),c.Vb()}if(2&t){var o=e.$implicit;c.Bb(2),c.oc("ngModel",o._export),c.Bb(2),c.Tc("",o.Name," (",o.Id,")")}}function C(t,e){if(1&t&&(c.Wb(0,"ul",27),c.Wb(1,"p",28),c.Qc(2,"Templates"),c.Vb(),c.Oc(3,y,5,3,"li",21),c.Vb()),2&t){var n=c.ic().$implicit;c.Bb(3),c.oc("ngForOf",n.Templates)}}function O(t,e){if(1&t){var n=c.Xb();c.Wb(0,"li",22),c.Wb(1,"div",23),c.Wb(2,"mat-checkbox",24),c.ec("ngModelChange",(function(t){return c.Ec(n),e.$implicit._export=t})),c.Wb(3,"span",25),c.Qc(4),c.Vb(),c.Vb(),c.Vb(),c.Vb()}if(2&t){var o=e.$implicit;c.Bb(2),c.oc("ngModel",o._export),c.Bb(2),c.Tc("",o.Title," (",o.Id,")")}}function k(t,e){if(1&t&&(c.Wb(0,"ul",27),c.Wb(1,"p",28),c.Qc(2,"Entities"),c.Vb(),c.Oc(3,O,5,3,"li",21),c.Vb()),2&t){var n=c.ic().$implicit;c.Bb(3),c.oc("ngForOf",n.Entities)}}function T(t,e){if(1&t){var n=c.Xb();c.Wb(0,"li",22),c.Wb(1,"div",23),c.Wb(2,"mat-checkbox",24),c.ec("ngModelChange",(function(t){return c.Ec(n),e.$implicit._export=t})),c.Wb(3,"span",25),c.Qc(4),c.Vb(),c.Vb(),c.Vb(),c.Oc(5,C,4,1,"ul",26),c.Oc(6,k,4,1,"ul",26),c.Vb()}if(2&t){var o=e.$implicit;c.Bb(2),c.oc("ngModel",o._export),c.Bb(2),c.Tc("",o.Name," (",o.Id,")"),c.Bb(1),c.oc("ngIf",o.Templates.length>0),c.Bb(1),c.oc("ngIf",o.Entities.length>0)}}function S(t,e){if(1&t){var n=c.Xb();c.Wb(0,"li",22),c.Wb(1,"div",23),c.Wb(2,"mat-checkbox",24),c.ec("ngModelChange",(function(t){return c.Ec(n),e.$implicit._export=t})),c.Wb(3,"span",25),c.Qc(4),c.Vb(),c.Vb(),c.Vb(),c.Vb()}if(2&t){var o=e.$implicit;c.Bb(2),c.oc("ngModel",o._export),c.Bb(2),c.Tc("",o.Name," (",o.Id,")")}}function I(t,e){if(1&t&&(c.Wb(0,"div"),c.Wb(1,"ul",19),c.Wb(2,"p",20),c.Qc(3,"Content Types"),c.Vb(),c.Oc(4,T,7,5,"li",21),c.Vb(),c.Wb(5,"ul",19),c.Wb(6,"p",20),c.Qc(7,"Templates Without Content Types"),c.Vb(),c.Oc(8,S,5,3,"li",21),c.Vb(),c.Vb()),2&t){var n=c.ic();c.Bb(4),c.oc("ngForOf",n.contentInfo.ContentTypes),c.Bb(4),c.oc("ngForOf",n.contentInfo.TemplatesWithoutContentTypes)}}var B=function(){function t(t,e,n){this.dialogRef=t,this.exportAppPartsService=e,this.contentTypesService=n,this.hostClass="dialog-component",this.exportScope=i.a.scopes.default.value,this.lockScope=!0,this.isExporting=!1}return t.prototype.ngOnInit=function(){this.fetchScopes(),this.fetchContentInfo()},t.prototype.exportAppParts=function(){this.isExporting=!0;var t=this.selectedContentTypes().map((function(t){return t.Id})),e=this.selectedTemplates().map((function(t){return t.Id})),n=this.selectedEntities().map((function(t){return t.Id}));n=n.concat(e),this.exportAppPartsService.exportParts(t,n,e),this.isExporting=!1},t.prototype.changeScope=function(t){var e=t.value;"Other"===e&&((e=prompt("This is an advanced feature to show content-types of another scope. Don't use this if you don't know what you're doing, as content-types of other scopes are usually hidden for a good reason."))?this.scopeOptions.find((function(t){return t.value===e}))||this.scopeOptions.push({name:e,value:e}):e=i.a.scopes.default.value),this.exportScope=e,this.fetchContentInfo()},t.prototype.unlockScope=function(t){t.stopPropagation(),this.lockScope=!this.lockScope,this.lockScope&&(this.exportScope=i.a.scopes.default.value,this.fetchContentInfo())},t.prototype.closeDialog=function(){this.dialogRef.close()},t.prototype.fetchScopes=function(){var t=this;this.contentTypesService.getScopes().subscribe((function(e){t.scopeOptions=e}))},t.prototype.fetchContentInfo=function(){var t=this;this.exportAppPartsService.getContentInfo(this.exportScope).subscribe((function(e){t.contentInfo=e}))},t.prototype.selectedContentTypes=function(){return this.contentInfo.ContentTypes.filter((function(t){return t._export}))},t.prototype.selectedEntities=function(){var t,e,n=[];try{for(var i=Object(o.i)(this.contentInfo.ContentTypes),c=i.next();!c.done;c=i.next())n=n.concat(c.value.Entities.filter((function(t){return t._export})))}catch(p){t={error:p}}finally{try{c&&!c.done&&(e=i.return)&&e.call(i)}finally{if(t)throw t.error}}return n},t.prototype.selectedTemplates=function(){var t,e,n=[];try{for(var i=Object(o.i)(this.contentInfo.ContentTypes),c=i.next();!c.done;c=i.next())n=n.concat(c.value.Templates.filter((function(t){return t._export})))}catch(p){t={error:p}}finally{try{c&&!c.done&&(e=i.return)&&e.call(i)}finally{if(t)throw t.error}}return n.concat(this.contentInfo.TemplatesWithoutContentTypes.filter((function(t){return t._export})))},t.\u0275fac=function(e){return new(e||t)(c.Qb(p.h),c.Qb(r.a),c.Qb(a.a))},t.\u0275cmp=c.Kb({type:t,selectors:[["app-export-app-parts"]],hostVars:1,hostBindings:function(t,e){2&t&&c.Zb("className",e.hostClass)},decls:30,vars:9,consts:[["mat-dialog-title",""],[1,"dialog-title-box"],[1,"dialog-description"],["href","http://2sxc.org/en/help?tag=export","target","_blank"],[1,"dialog-component-content","fancy-scrollbar-light"],[1,"edit-input"],["appearance","standard","color","accent"],["name","Scope",3,"ngModel","disabled","selectionChange"],[3,"value",4,"ngFor","ngForOf"],["value","Other"],["mat-icon-button","","type","button","matSuffix","",3,"matTooltip"],[3,"click",4,"ngIf"],["href","http://2sxc.org/help?tag=scope","target","_blank","appClickStopPropagation",""],[4,"ngIf"],[1,"dialog-component-actions"],["mat-raised-button","",3,"disabled","click"],["mat-raised-button","","color","accent",3,"disabled","click"],[3,"value"],[3,"click"],[1,"content-info__list","content-info__base"],[1,"content-info__title"],["class","content-info__item",4,"ngFor","ngForOf"],[1,"content-info__item"],[1,"option-box"],[3,"ngModel","ngModelChange"],[1,"option-box__text"],["class","content-info__list",4,"ngIf"],[1,"content-info__list"],[1,"content-info__subtitle"]],template:function(t,e){1&t&&(c.Wb(0,"div",0),c.Wb(1,"div",1),c.Qc(2,"Export Content and Templates from this App"),c.Vb(),c.Vb(),c.Wb(3,"p",2),c.Qc(4," This is an advanced feature to export parts of the app. The export will create an xml file which can be imported into another site or app. To export the entire content of the app (for example when duplicating the entire site), go to the app export. For further help visit "),c.Wb(5,"a",3),c.Qc(6,"2sxc Help"),c.Vb(),c.Qc(7,".\n"),c.Vb(),c.Wb(8,"div",4),c.Wb(9,"div",5),c.Wb(10,"mat-form-field",6),c.Wb(11,"mat-label"),c.Qc(12,"Scope"),c.Vb(),c.Wb(13,"mat-select",7),c.ec("selectionChange",(function(t){return e.changeScope(t)})),c.Oc(14,_,2,2,"mat-option",8),c.Wb(15,"mat-option",9),c.Qc(16,"Other..."),c.Vb(),c.Vb(),c.Wb(17,"button",10),c.Oc(18,W,2,0,"mat-icon",11),c.Oc(19,V,2,0,"mat-icon",11),c.Vb(),c.Vb(),c.Wb(20,"app-field-hint"),c.Qc(21," The scope should almost never be changed - "),c.Wb(22,"a",12),c.Qc(23,"see help"),c.Vb(),c.Vb(),c.Vb(),c.Oc(24,I,9,2,"div",13),c.Vb(),c.Wb(25,"div",14),c.Wb(26,"button",15),c.ec("click",(function(){return e.closeDialog()})),c.Qc(27,"Cancel"),c.Vb(),c.Wb(28,"button",16),c.ec("click",(function(){return e.exportAppParts()})),c.Qc(29,"Export"),c.Vb(),c.Vb()),2&t&&(c.Bb(13),c.oc("ngModel",e.exportScope)("disabled",e.lockScope),c.Bb(1),c.oc("ngForOf",e.scopeOptions),c.Bb(3),c.oc("matTooltip",e.lockScope?"Unlock":"Lock"),c.Bb(1),c.oc("ngIf",e.lockScope),c.Bb(1),c.oc("ngIf",!e.lockScope),c.Bb(5),c.oc("ngIf",e.contentInfo),c.Bb(2),c.oc("disabled",e.isExporting),c.Bb(2),c.oc("disabled",e.isExporting))},directives:[p.i,s.c,s.g,l.a,b.r,b.u,f.s,u.l,h.b,s.j,d.a,f.t,g.a,m.a,x.a,v.a],styles:[".edit-input[_ngcontent-%COMP%]{padding-bottom:8px}.mat-hint[_ngcontent-%COMP%]{font-size:12px}.content-info__title[_ngcontent-%COMP%]{font-size:18px;font-weight:700}.content-info__subtitle[_ngcontent-%COMP%]{font-size:14px;font-weight:700}.content-info__list[_ngcontent-%COMP%]{font-size:14px;list-style-type:none}.content-info__base[_ngcontent-%COMP%]{padding:0}.content-info__item[_ngcontent-%COMP%]{border-top:1px solid #ddd;padding:2px}.option-box[_ngcontent-%COMP%]{margin:8px 0}.option-box__text[_ngcontent-%COMP%]{white-space:normal;font-size:14px}"]}),t}()}}]);
//# sourceMappingURL=https://sources.2sxc.org/11.04.00/ng-edit/export-app-parts-component.044d14b06db7143cdcff.js.map