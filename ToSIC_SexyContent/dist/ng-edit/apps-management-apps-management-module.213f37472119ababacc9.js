(window.webpackJsonp=window.webpackJsonp||[]).push([[13],{I3IT:function(t,n,e){"use strict";e.d(n,"a",(function(){return i}));var r=e("1C3z"),a=e("t5c9"),o=e("dkRO"),i=function(){function t(t,n){this.http=t,this.dnnContext=n}return t.prototype.activatePageLog=function(t){return this.http.get(this.dnnContext.$2sxc.http.apiUrl("app-sys/system/extendedlogging"),{params:{duration:t.toString()}})},t.\u0275fac=function(n){return new(n||t)(r.ac(a.b),r.ac(o.a))},t.\u0275prov=r.Mb({token:t,factory:t.\u0275fac}),t}()},dyKt:function(t,n,e){"use strict";e.r(n);var r=e("8AiQ"),a=e("ZSGP"),o=e("G6Ml"),i=e("9HSk"),s=e("r4gC"),p=e("Qc/f"),c=e("nYrE"),u=e("F7GT"),h=e("JNB8"),l=e("BLjT"),f=e("OeRG"),d=e("Bata"),g=e("TDrE"),m=e("KYsL"),y=e("5/c3"),b=e("nXrb"),C=e("mQU2"),x=e("D57K"),v={name:"APPS_MANAGEMENT_DIALOG",initContext:!0,panelSize:"large",panelClass:null,getComponent:function(){return Object(x.b)(this,void 0,void 0,(function(){return Object(x.e)(this,(function(t){switch(t.label){case 0:return[4,Promise.all([e.e(4),e.e(0),e.e(14)]).then(e.bind(null,"25Tt"))];case 1:return[2,t.sent().AppsManagementNavComponent]}}))}))}},w=e("1C3z"),A=[{path:"",component:b.a,data:{dialog:v},children:[{path:"",redirectTo:"list",pathMatch:"full"},{path:"list",component:C.a,children:[{path:"import",loadChildren:function(){return Promise.all([e.e(1),e.e(30)]).then(e.bind(null,"QK70")).then((function(t){return t.ImportAppModule}))}}]},{path:"languages",component:C.a},{path:"features",component:C.a},{path:"sxc-insights",component:C.a},{path:":appId",loadChildren:function(){return Promise.all([e.e(1),e.e(2),e.e(3),e.e(5),e.e(7),e.e(9),e.e(0),e.e(11)]).then(e.bind(null,"i2HA")).then((function(t){return t.AppAdministrationModule}))}}]}],M=function(){function t(){}return t.\u0275mod=w.Ob({type:t}),t.\u0275inj=w.Nb({factory:function(n){return new(n||t)},imports:[[y.g.forChild(A)],y.g]}),t}(),O=e("O6Xb"),k=e("Iv+g"),U=e("2aC0"),j=e("xNdR"),I=e("ycnj"),N=e("I3IT");e.d(n,"AppsManagementModule",(function(){return S}));var S=function(){function t(){}return t.\u0275mod=w.Ob({type:t}),t.\u0275inj=w.Nb({factory:function(n){return new(n||t)},providers:[k.a,U.a,j.a,I.a,N.a],imports:[[M,O.a,l.g,r.c,o.b.withComponents([]),i.c,s.b,c.a,p.b,u.b,h.e,f.r,m.c,d.j,a.l,g.c]]}),t}()},xNdR:function(t,n,e){"use strict";e.d(n,"a",(function(){return i}));var r=e("1C3z"),a=e("t5c9"),o=e("dkRO"),i=function(){function t(t,n){this.http=t,this.dnnContext=n}return t.prototype.getAll=function(){return this.http.get(this.dnnContext.$2sxc.http.apiUrl("app-sys/system/getlanguages"))},t.prototype.toggle=function(t,n){return this.http.get(this.dnnContext.$2sxc.http.apiUrl("app-sys/system/switchlanguage"),{params:{cultureCode:t,enable:n.toString()}})},t.prototype.save=function(t,n){return this.http.get(this.dnnContext.$2sxc.http.apiUrl("app-sys/system/switchlanguage"),{params:{cultureCode:t,enable:n.toString()}})},t.\u0275fac=function(n){return new(n||t)(r.ac(a.b),r.ac(o.a))},t.\u0275prov=r.Mb({token:t,factory:t.\u0275fac}),t}()},ycnj:function(t,n,e){"use strict";e.d(n,"a",(function(){return i}));var r=e("1C3z"),a=e("t5c9"),o=e("dkRO"),i=function(){function t(t,n){this.http=t,this.dnnContext=n}return t.prototype.getAll=function(){return this.http.get(this.dnnContext.$2sxc.http.apiUrl("app-sys/system/features"))},t.prototype.getManageFeaturesUrl=function(){return this.http.get(this.dnnContext.$2sxc.http.apiUrl("app-sys/system/managefeaturesurl"))},t.prototype.saveFeatures=function(t){return this.http.post(this.dnnContext.$2sxc.http.apiUrl("app-sys/system/SaveFeatures"),t)},t.\u0275fac=function(n){return new(n||t)(r.ac(a.b),r.ac(o.a))},t.\u0275prov=r.Mb({token:t,factory:t.\u0275fac}),t}()}}]);
//# sourceMappingURL=https://sources.2sxc.org/11.04.00/ng-edit/apps-management-apps-management-module.213f37472119ababacc9.js.map