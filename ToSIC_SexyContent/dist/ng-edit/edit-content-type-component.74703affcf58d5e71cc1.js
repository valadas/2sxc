(window.webpackJsonp=window.webpackJsonp||[]).push([[25],{YLeX:function(t,e,n){"use strict";n.r(e);var o=n("D57K"),i=function(t){function e(){return null!==t&&t.apply(this,arguments)||this}return Object(o.d)(e,t),e}(function(){return function(){}}()),a=n("o9tz"),c=n("Y2qJ"),s=n("1C3z"),r=n("BLjT"),p=n("5/c3"),u=n("S36y"),b=n("2pW/"),l=n("8AiQ"),d=n("ZSGP"),f=n("hOvr"),m=n("TDrE"),h=n("FONI"),g=n("LuBX"),y=n("OeRG"),v=n("9HSk"),S=n("Qc/f"),T=n("Uk43"),D=n("Zfm5"),O=n("r4gC");function V(t,e){1&t&&(s.Wb(0,"app-field-hint",24),s.Oc(1,"This field is required"),s.Vb()),2&t&&s.qc("isError",!0)}function W(t,e){if(1&t&&(s.Wb(0,"app-field-hint",24),s.Oc(1),s.Vb()),2&t){var n=s.ic(3);s.qc("isError",!0),s.Bb(1),s.Pc(n.contentTypeNameError)}}function C(t,e){if(1&t&&(s.Ub(0),s.Mc(1,V,2,1,"app-field-hint",23),s.Mc(2,W,2,2,"app-field-hint",23),s.Tb()),2&t){s.ic();var n=s.Bc(7);s.Bb(1),s.qc("ngIf",n.errors.required),s.Bb(1),s.qc("ngIf",n.errors.pattern)}}function k(t,e){if(1&t&&(s.Wb(0,"mat-option",25),s.Oc(1),s.Vb()),2&t){var n=e.$implicit;s.qc("value",n.value),s.Bb(1),s.Qc("",n.name," ")}}function I(t,e){if(1&t){var n=s.Xb();s.Wb(0,"mat-icon",26),s.ec("click",(function(t){return s.Dc(n),s.ic(2).unlockScope(t)})),s.Oc(1,"lock"),s.Vb()}}function B(t,e){if(1&t){var n=s.Xb();s.Wb(0,"mat-icon",26),s.ec("click",(function(t){return s.Dc(n),s.ic(2).unlockScope(t)})),s.Oc(1,"lock_open"),s.Vb()}}function M(t,e){if(1&t&&(s.Wb(0,"div",5),s.Wb(1,"h3"),s.Oc(2,"Shared Content Type (Ghost)"),s.Vb(),s.Wb(3,"p"),s.Oc(4,"Note: this can't be edited in the UI, for now if you really know what you're doing, do it in the DB"),s.Vb(),s.Wb(5,"p"),s.Oc(6),s.Vb(),s.Vb()),2&t){var n=s.ic(2);s.Bb(6),s.Qc("Uses Type Definition of: ",n.contentType.SharedDefId,"")}}function N(t,e){if(1&t){var n=s.Xb();s.Wb(0,"form",3,4),s.ec("ngSubmit",(function(){return s.Dc(n),s.ic().onSubmit()})),s.Wb(2,"div",5),s.Wb(3,"mat-form-field",6),s.Wb(4,"mat-label"),s.Oc(5,"Name"),s.Vb(),s.Wb(6,"input",7,8),s.ec("ngModelChange",(function(t){return s.Dc(n),s.ic().contentType.Name=t})),s.Vb(),s.Vb(),s.Mc(8,C,3,2,"ng-container",9),s.Vb(),s.Wb(9,"mat-accordion"),s.Wb(10,"mat-expansion-panel",10),s.Wb(11,"mat-expansion-panel-header"),s.Wb(12,"mat-panel-title"),s.Oc(13,"Advanced"),s.Vb(),s.Rb(14,"mat-panel-description"),s.Vb(),s.Wb(15,"div",5),s.Wb(16,"mat-form-field",6),s.Wb(17,"mat-label"),s.Oc(18,"Description"),s.Vb(),s.Wb(19,"input",11),s.ec("ngModelChange",(function(t){return s.Dc(n),s.ic().contentType.Description=t})),s.Vb(),s.Vb(),s.Vb(),s.Wb(20,"div",5),s.Wb(21,"mat-form-field",6),s.Wb(22,"mat-label"),s.Oc(23,"Scope"),s.Vb(),s.Wb(24,"mat-select",12),s.ec("selectionChange",(function(t){return s.Dc(n),s.ic().changeScope(t)})),s.Mc(25,k,2,2,"mat-option",13),s.Wb(26,"mat-option",14),s.Oc(27,"Other..."),s.Vb(),s.Vb(),s.Wb(28,"button",15),s.Mc(29,I,2,0,"mat-icon",16),s.Mc(30,B,2,0,"mat-icon",16),s.Vb(),s.Vb(),s.Wb(31,"app-field-hint"),s.Oc(32," The scope should almost never be changed - "),s.Wb(33,"a",17),s.Oc(34,"see help"),s.Vb(),s.Vb(),s.Vb(),s.Wb(35,"div",5),s.Wb(36,"mat-form-field",6),s.Wb(37,"mat-label"),s.Oc(38,"Static Name"),s.Vb(),s.Rb(39,"input",18),s.Vb(),s.Vb(),s.Mc(40,M,7,1,"div",19),s.Vb(),s.Vb(),s.Wb(41,"div",20),s.Wb(42,"button",21),s.ec("click",(function(){return s.Dc(n),s.ic().closeDialog()})),s.Oc(43,"Cancel"),s.Vb(),s.Wb(44,"button",22),s.Oc(45,"Save"),s.Vb(),s.Vb(),s.Vb()}if(2&t){var o=s.Bc(1),i=s.Bc(7),a=s.ic();s.Bb(6),s.qc("pattern",a.contentTypeNamePattern)("ngModel",a.contentType.Name),s.Bb(2),s.qc("ngIf",i.touched&&i.errors),s.Bb(1),s.qc("@.disabled",a.disableAnimation),s.Bb(10),s.qc("ngModel",a.contentType.Description),s.Bb(5),s.qc("ngModel",a.contentType.Scope)("disabled",a.lockScope),s.Bb(1),s.qc("ngForOf",a.scopeOptions),s.Bb(3),s.qc("matTooltip",a.lockScope?"Unlock":"Lock"),s.Bb(1),s.qc("ngIf",a.lockScope),s.Bb(1),s.qc("ngIf",!a.lockScope),s.Bb(9),s.qc("ngModel",a.contentType.StaticName),s.Bb(1),s.qc("ngIf",a.contentType.SharedDefId),s.Bb(4),s.qc("disabled",!o.form.valid)}}n.d(e,"EditContentTypeComponent",(function(){return q}));var q=function(){function t(t,e,n,o){this.dialogRef=t,this.route=e,this.contentTypesService=n,this.snackBar=o,this.lockScope=!0,this.contentTypeNamePattern=c.b,this.contentTypeNameError=c.a,this.disableAnimation=!0,this.scope=this.route.snapshot.paramMap.get("scope"),this.id=parseInt(this.route.snapshot.paramMap.get("id"),10)}return t.prototype.ngAfterViewInit=function(){var t=this;setTimeout((function(){return t.disableAnimation=!1}))},t.prototype.ngOnInit=function(){this.fetchScopes(),this.id?this.fetchContentType():this.contentType=Object(o.a)(Object(o.a)({},new i),{StaticName:"",Name:"",Description:"",Scope:this.scope,ChangeStaticName:!1,NewStaticName:""})},t.prototype.changeScope=function(t){var e=t.value;"Other"===e&&((e=prompt("This is an advanced feature to show content-types of another scope. Don't use this if you don't know what you're doing, as content-types of other scopes are usually hidden for a good reason."))?this.scopeOptions.find((function(t){return t.value===e}))||this.scopeOptions.push({name:e,value:e}):e=a.a.scopes.default.value),this.contentType.Scope=e},t.prototype.unlockScope=function(t){t.stopPropagation(),this.lockScope=!this.lockScope,this.lockScope&&(this.contentType.Scope=this.scope)},t.prototype.onSubmit=function(){var t=this;this.snackBar.open("Saving..."),this.contentTypesService.save(this.contentType).subscribe((function(e){t.snackBar.open("Saved",null,{duration:2e3}),t.closeDialog()}))},t.prototype.closeDialog=function(){this.dialogRef.close()},t.prototype.fetchScopes=function(){var t=this;this.contentTypesService.getScopes().subscribe((function(e){t.scopeOptions=e}))},t.prototype.fetchContentType=function(){var t=this;this.contentTypesService.retrieveContentTypes(this.scope).subscribe((function(e){var n=e.find((function(e){return e.Id===t.id}));t.contentType=Object(o.a)(Object(o.a)({},n),{ChangeStaticName:!1,NewStaticName:n.StaticName})}))},t.\u0275fac=function(e){return new(e||t)(s.Qb(r.h),s.Qb(p.a),s.Qb(u.a),s.Qb(b.b))},t.\u0275cmp=s.Kb({type:t,selectors:[["app-edit-content-type"]],decls:4,vars:2,consts:[["mat-dialog-title",""],[1,"dialog-title-box"],[3,"ngSubmit",4,"ngIf"],[3,"ngSubmit"],["ngForm","ngForm"],[1,"edit-input"],["appearance","standard","color","accent"],["matInput","","type","text","name","Name","required","",3,"pattern","ngModel","ngModelChange"],["name","ngModel"],[4,"ngIf"],["expanded","false"],["matInput","","type","text","name","Description",3,"ngModel","ngModelChange"],["name","Scope",3,"ngModel","disabled","selectionChange"],[3,"value",4,"ngFor","ngForOf"],["value","Other"],["mat-icon-button","","type","button","matSuffix","",3,"matTooltip"],[3,"click",4,"ngIf"],["href","http://2sxc.org/help?tag=scope","target","_blank","appClickStopPropagation",""],["matInput","","type","text","name","StaticName","disabled","",3,"ngModel"],["class","edit-input",4,"ngIf"],[1,"dialog-actions-box"],["mat-raised-button","","type","button",3,"click"],["mat-raised-button","","type","submit","color","accent",3,"disabled"],[3,"isError",4,"ngIf"],[3,"isError"],[3,"value"],[3,"click"]],template:function(t,e){1&t&&(s.Wb(0,"div",0),s.Wb(1,"div",1),s.Oc(2),s.Vb(),s.Vb(),s.Mc(3,N,46,14,"form",2)),2&t&&(s.Bb(2),s.Pc(e.id?"Edit Content Type":"New Content Type"),s.Bb(1),s.qc("ngIf",e.contentType))},directives:[r.i,l.t,d.G,d.s,d.t,f.c,f.g,m.b,d.c,d.B,d.x,d.r,d.u,h.a,h.c,h.e,h.f,h.d,g.a,l.s,y.l,v.b,f.j,S.a,T.a,D.a,O.a],styles:[".edit-input[_ngcontent-%COMP%]{padding-bottom:8px}.mat-hint[_ngcontent-%COMP%]{font-size:12px}"]}),t}()},o9tz:function(t,e,n){"use strict";n.d(e,"a",(function(){return o}));var o={metadata:{attribute:{type:2,target:"EAV Field Properties"},app:{type:3,target:"App"},entity:{type:4,target:"Entity"},contentType:{type:5,target:"ContentType"},zone:{type:6,target:"Zone"},cmsObject:{type:10,target:"CmsObject"}},keyTypes:{guid:"guid",string:"string",number:"number"},scopes:{default:{name:"Default",value:"2SexyContent"},app:{name:"System: App",value:"2SexyContent-App"}},contentTypes:{template:"2SexyContent-Template",permissions:"PermissionConfiguration",query:"DataPipeline",contentType:"ContentType",settings:"App-Settings",resources:"App-Resources"},pipelineDesigner:{outDataSource:{className:"SexyContentTemplate",in:["ListContent","Default"],name:"2sxc Target (View or API)",description:"The template/script which will show this data",visualDesignerData:{Top:20,Left:200,Width:700}},defaultPipeline:{dataSources:[{entityGuid:"unsaved1",partAssemblyAndType:"ToSic.Eav.DataSources.Caches.ICache, ToSic.Eav.DataSources",visualDesignerData:{Top:440,Left:440}},{entityGuid:"unsaved2",partAssemblyAndType:"ToSic.Eav.DataSources.PublishingFilter, ToSic.Eav.DataSources",visualDesignerData:{Top:300,Left:440}},{entityGuid:"unsaved3",partAssemblyAndType:"ToSic.SexyContent.DataSources.ModuleDataSource, ToSic.SexyContent",visualDesignerData:{Top:170,Left:440}}],streamWiring:[{From:"unsaved1",Out:"Default",To:"unsaved2",In:"Default"},{From:"unsaved1",Out:"Drafts",To:"unsaved2",In:"Drafts"},{From:"unsaved1",Out:"Published",To:"unsaved2",In:"Published"},{From:"unsaved2",Out:"Default",To:"unsaved3",In:"Default"},{From:"unsaved3",Out:"ListContent",To:"Out",In:"ListContent"},{From:"unsaved3",Out:"Default",To:"Out",In:"Default"}]},testParameters:"[Demo:Demo]=true"}}}}]);
//# sourceMappingURL=https://sources.2sxc.org/11.01.00/ng-edit/edit-content-type-component.74703affcf58d5e71cc1.js.map