(window.webpackJsonp=window.webpackJsonp||[]).push([[38],{SNUn:function(t,e,n){"use strict";n.d(e,"a",(function(){return r}));var i=n("o9tz"),o=n("1C3z"),a=n("ykZ8"),s=n("GTfO"),r=function(){function t(t,e){this.metadataService=t,this.entitiesService=e}return t.prototype.getAll=function(t,e,n){return this.metadataService.getMetadata(t,e,n,i.a.contentTypes.permissions)},t.prototype.delete=function(t){return this.entitiesService.delete(i.a.contentTypes.permissions,t,!1)},t.\u0275fac=function(e){return new(e||t)(o.ac(a.a),o.ac(s.a))},t.\u0275prov=o.Mb({token:t,factory:t.\u0275fac}),t}()},jl54:function(t,e,n){"use strict";n.r(e);var i=n("8AiQ"),o=n("BLjT"),a=n("9HSk"),s=n("r4gC"),r=n("Qc/f"),u=n("OeRG"),c=n("2pW/"),l=n("G6Ml"),p=n("5/c3"),d=n("nXrb"),f=n("D57K"),g={name:"SET_PERMISSIONS_DIALOG",initContext:!0,panelSize:"large",panelClass:null,getComponent:function(){return Object(f.b)(this,void 0,void 0,(function(){return Object(f.e)(this,(function(t){switch(t.label){case 0:return[4,Promise.all([n.e(5),n.e(0),n.e(37)]).then(n.bind(null,"SST1"))];case 1:return[2,t.sent().PermissionsComponent]}}))}))}},h=n("it7M"),b=n("1C3z"),m=[{path:"",component:d.a,data:{dialog:g},children:[{matcher:h.a,loadChildren:function(){return Promise.all([n.e(1),n.e(2),n.e(3),n.e(7),n.e(8),n.e(10),n.e(9),n.e(11),n.e(0),n.e(27)]).then(n.bind(null,"B+J5")).then((function(t){return t.EditModule}))}}]}],y=function(){function t(){}return t.\u0275mod=b.Ob({type:t}),t.\u0275inj=b.Nb({factory:function(e){return new(e||t)},imports:[[p.g.forChild(m)],p.g]}),t}(),C=n("O6Xb"),v=n("Iv+g"),T=n("SNUn"),S=n("ykZ8"),D=n("GTfO");n.d(e,"PermissionsModule",(function(){return O}));var O=function(){function t(){}return t.\u0275mod=b.Ob({type:t}),t.\u0275inj=b.Nb({factory:function(e){return new(e||t)},providers:[v.a,T.a,S.a,D.a],imports:[[i.c,y,C.a,o.g,a.c,s.b,r.b,l.b.withComponents([]),u.r,c.d]]}),t}()},nXrb:function(t,e,n){"use strict";n.d(e,"a",(function(){return l}));var i=n("D57K"),o=n("LR82"),a=n("50eG"),s=n("1C3z"),r=n("BLjT"),u=n("5/c3"),c=n("Iv+g"),l=function(){function t(t,e,n,i,a){if(this.dialog=t,this.viewContainerRef=e,this.router=n,this.route=i,this.context=a,this.subscription=new o.a,this.dialogConfig=this.route.snapshot.data.dialog,!this.dialogConfig)throw new Error("Could not find config for dialog. Did you forget to add DialogConfig to route data?")}return t.prototype.ngOnInit=function(){return Object(i.b)(this,void 0,void 0,(function(){var t,e=this;return Object(i.e)(this,(function(n){switch(n.label){case 0:return Object(a.a)("Open dialog:",this.dialogConfig.name,"Context id:",this.context.id,"Context:",this.context),t=this,[4,this.dialogConfig.getComponent()];case 1:return t.component=n.sent(),this.dialogConfig.initContext&&this.context.init(this.route),this.dialogRef=this.dialog.open(this.component,{backdropClass:"dialog-backdrop",panelClass:Object(i.g)(["dialog-panel","dialog-panel-"+this.dialogConfig.panelSize,this.dialogConfig.showScrollbar?"show-scrollbar":"no-scrollbar"],this.dialogConfig.panelClass?this.dialogConfig.panelClass:[]),viewContainerRef:this.viewContainerRef,autoFocus:!1,closeOnNavigation:!1,position:{top:"0"}}),this.subscription.add(this.dialogRef.afterClosed().subscribe((function(t){if(Object(a.a)("Dialog was closed:",e.dialogConfig.name,"Data:",t),e.route.pathFromRoot.length<=3)try{window.parent.$2sxc.totalPopup.close()}catch(n){}else e.router.navigate(["./"],e.route.snapshot.url.length>0?{relativeTo:e.route.parent,state:t}:{relativeTo:e.route.parent.parent,state:t})}))),[2]}}))}))},t.prototype.ngOnDestroy=function(){this.subscription.unsubscribe(),this.subscription=null,this.dialogConfig=null,this.component=null,this.dialogRef.close(),this.dialogRef=null},t.\u0275fac=function(e){return new(e||t)(s.Qb(r.b),s.Qb(s.O),s.Qb(u.c),s.Qb(u.a),s.Qb(c.a))},t.\u0275cmp=s.Kb({type:t,selectors:[["app-dialog-entry"]],decls:0,vars:0,template:function(t,e){},styles:[""]}),t}()},o9tz:function(t,e,n){"use strict";n.d(e,"a",(function(){return i}));var i={metadata:{attribute:{type:2,target:"EAV Field Properties"},app:{type:3,target:"App"},entity:{type:4,target:"Entity"},contentType:{type:5,target:"ContentType"},zone:{type:6,target:"Zone"},cmsObject:{type:10,target:"CmsObject"}},keyTypes:{guid:"guid",string:"string",number:"number"},scopes:{default:{name:"Default",value:"2SexyContent"},app:{name:"System: App",value:"2SexyContent-App"}},contentTypes:{template:"2SexyContent-Template",permissions:"PermissionConfiguration",query:"DataPipeline",contentType:"ContentType",settings:"App-Settings",resources:"App-Resources"},pipelineDesigner:{outDataSource:{className:"SexyContentTemplate",in:["ListContent","Default"],name:"2sxc Target (View or API)",description:"The template/script which will show this data",visualDesignerData:{Top:20,Left:200,Width:700}},defaultPipeline:{dataSources:[{entityGuid:"unsaved1",partAssemblyAndType:"ToSic.Eav.DataSources.Caches.ICache, ToSic.Eav.DataSources",visualDesignerData:{Top:440,Left:440}},{entityGuid:"unsaved2",partAssemblyAndType:"ToSic.Eav.DataSources.PublishingFilter, ToSic.Eav.DataSources",visualDesignerData:{Top:300,Left:440}},{entityGuid:"unsaved3",partAssemblyAndType:"ToSic.SexyContent.DataSources.ModuleDataSource, ToSic.SexyContent",visualDesignerData:{Top:170,Left:440}}],streamWiring:[{From:"unsaved1",Out:"Default",To:"unsaved2",In:"Default"},{From:"unsaved1",Out:"Drafts",To:"unsaved2",In:"Drafts"},{From:"unsaved1",Out:"Published",To:"unsaved2",In:"Published"},{From:"unsaved2",Out:"Default",To:"unsaved3",In:"Default"},{From:"unsaved3",Out:"ListContent",To:"Out",In:"ListContent"},{From:"unsaved3",Out:"Default",To:"Out",In:"Default"}]},testParameters:"[Demo:Demo]=true"}}}}]);
//# sourceMappingURL=https://sources.2sxc.org/11.01.00/ng-edit/permissions-permissions-module.66164197e6988b13da12.js.map