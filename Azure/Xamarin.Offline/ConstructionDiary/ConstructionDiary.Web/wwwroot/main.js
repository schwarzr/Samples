(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./dashboard/dasbhoard.component */ "./src/app/dashboard/dasbhoard.component.ts");
/* harmony import */ var _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./countries/countries-list.component */ "./src/app/countries/countries-list.component.ts");
/* harmony import */ var _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./countries/country-edit.component */ "./src/app/countries/country-edit.component.ts");
/* harmony import */ var _countries_country_create_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./countries/country-create.component */ "./src/app/countries/country-create.component.ts");
/* harmony import */ var _project_id_resolver__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./project-id.resolver */ "./src/app/project-id.resolver.ts");
/* harmony import */ var _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./issues/issue-list.component */ "./src/app/issues/issue-list.component.ts");









var routes = [{
        path: 'dashboard',
        component: _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_3__["DashboardComponent"]
    },
    {
        path: 'countries',
        children: [
            {
                path: '',
                component: _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_4__["CountriesListComponent"]
            },
            {
                path: 'new',
                component: _countries_country_create_component__WEBPACK_IMPORTED_MODULE_6__["CountryCreateComponent"]
            },
            {
                path: ':id',
                component: _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_5__["CountryEditComponent"]
            },
        ]
    },
    {
        path: 'issuetypes',
        children: [
            {
                path: '',
                component: _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_3__["DashboardComponent"]
            },
            {
                path: ':id',
                component: _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_3__["DashboardComponent"]
            }
        ]
    },
    {
        path: ':project',
        resolve: {
            project: _project_id_resolver__WEBPACK_IMPORTED_MODULE_7__["ProjectIdResolver"]
        },
        children: [
            {
                path: 'issues',
                children: [
                    {
                        path: '',
                        component: _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_8__["IssueListComponent"]
                    },
                    {
                        path: ':id',
                        component: _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_3__["DashboardComponent"]
                    }
                ]
            },
            {
                path: 'employees',
                children: [
                    {
                        path: '',
                        component: _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_3__["DashboardComponent"]
                    },
                    {
                        path: ':id',
                        component: _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_3__["DashboardComponent"]
                    }
                ]
            }
        ]
    },
    {
        path: '**',
        redirectTo: 'dashboard'
    }];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<nav class=\"navbar navbar-expand-lg navbar-light bg-light\">\r\n    <a class=\"navbar-brand\" href=\"#\">Construction Diary</a>\r\n    <button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" (click)=\"isCollapsed = !isCollapsed\"\r\n        data-target=\"#navbarSupportedContent\" aria-controls=\"navbarSupportedContent\" aria-expanded=\"false\"\r\n        aria-label=\"Toggle navigation\">\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n    </button>\r\n\r\n    <div class=\"collapse navbar-collapse\" [collapse]=\"isCollapsed\" id=\"navbarSupportedContent\">\r\n        <ul class=\"navbar-nav mr-auto\">\r\n            <li class=\"nav-item active\">\r\n                <a class=\"nav-link\" [routerLink]=\"['dashboard']\" routerLinkActive=\"active\">Dashboard</a>\r\n            </li>\r\n            <li class=\"nav-item active\" *ngIf=\"projectService.current\">\r\n                <a class=\"nav-link\" [routerLink]=\"[projectService.current.displayString,'issues']\"\r\n                    routerLinkActive=\"active\">Issues</a>\r\n            </li>\r\n            <li class=\"nav-item dropdown\" dropdown>\r\n                <div dropdownToggle class=\"nav-link dropdown-toggle\" id=\"navbarDropdown\" role=\"button\"\r\n                    data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n                    Masterdata\r\n                </div>\r\n                <div *dropdownMenu class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">\r\n                    <a class=\"dropdown-item\" [routerLink]=\"['countries']\" routerLinkActive=\"active\">Countries</a>\r\n                    <a class=\"dropdown-item\" [routerLink]=\"['issuetypes']\" routerLinkActive=\"active\">Issue types</a>\r\n                    <div class=\"dropdown-divider\"></div>\r\n                    <a *ngIf=\"projectService.current\" class=\"dropdown-item\"\r\n                        [routerLink]=\"[projectService.current.displayString,'employees']\"\r\n                        routerLinkActive=\"active\">Employees</a>\r\n                </div>\r\n            </li>\r\n        </ul>\r\n\r\n        <form class=\"form-inline my-2 my-lg-0\">\r\n            <select class=\"form-control\" #p (change)=\"selectProject(p.value)\">\r\n                <option *ngFor=\"let item of projectService.projects\"\r\n                    [attr.selected]=\"projectService.current && projectService.current.id == item.id ? 'selected' : null\"\r\n                    [value]=\"item.id\">{{item.displayString}}</option>\r\n            </select>\r\n        </form>\r\n    </div>\r\n\r\n</nav>\r\n\r\n<router-outlet></router-outlet>"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _project_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./project.service */ "./src/app/project.service.ts");



var AppComponent = /** @class */ (function () {
    function AppComponent(projectService) {
        this.projectService = projectService;
        this.isCollapsed = true;
    }
    AppComponent.prototype.ngOnInit = function () {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.projectService.initialize()];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    AppComponent.prototype.selectProject = function (projectid) {
        this.projectService.current = this.projectService.projects.filter(function (p) { return p.id == projectid; })[0];
    };
    AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html")
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_project_service__WEBPACK_IMPORTED_MODULE_2__["ProjectService"]])
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var ngx_bootstrap_accordion__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ngx-bootstrap/accordion */ "./node_modules/ngx-bootstrap/accordion/fesm5/ngx-bootstrap-accordion.js");
/* harmony import */ var ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ngx-bootstrap/dropdown */ "./node_modules/ngx-bootstrap/dropdown/fesm5/ngx-bootstrap-dropdown.js");
/* harmony import */ var ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ngx-bootstrap/modal */ "./node_modules/ngx-bootstrap/modal/fesm5/ngx-bootstrap-modal.js");
/* harmony import */ var ngx_bootstrap_tabs__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ngx-bootstrap/tabs */ "./node_modules/ngx-bootstrap/tabs/fesm5/ngx-bootstrap-tabs.js");
/* harmony import */ var ngx_bootstrap_collapse__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ngx-bootstrap/collapse */ "./node_modules/ngx-bootstrap/collapse/fesm5/ngx-bootstrap-collapse.js");
/* harmony import */ var _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./dashboard/dasbhoard.component */ "./src/app/dashboard/dasbhoard.component.ts");
/* harmony import */ var _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./countries/countries-list.component */ "./src/app/countries/countries-list.component.ts");
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ../service/service */ "./src/service/service.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./countries/country-edit.component */ "./src/app/countries/country-edit.component.ts");
/* harmony import */ var _countries_country_create_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./countries/country-create.component */ "./src/app/countries/country-create.component.ts");
/* harmony import */ var _project_service__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./project.service */ "./src/app/project.service.ts");
/* harmony import */ var _project_id_resolver__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./project-id.resolver */ "./src/app/project-id.resolver.ts");
/* harmony import */ var _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./issues/issue-list.component */ "./src/app/issues/issue-list.component.ts");





















var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"],
                _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_10__["DashboardComponent"],
                _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_11__["CountriesListComponent"],
                _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_16__["CountryEditComponent"],
                _countries_country_create_component__WEBPACK_IMPORTED_MODULE_17__["CountryCreateComponent"],
                _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_20__["IssueListComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"],
                _app_routing_module__WEBPACK_IMPORTED_MODULE_3__["AppRoutingModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_13__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_14__["FormsModule"],
                _angular_common__WEBPACK_IMPORTED_MODULE_15__["CommonModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_14__["ReactiveFormsModule"],
                ngx_bootstrap_accordion__WEBPACK_IMPORTED_MODULE_5__["AccordionModule"].forRoot(),
                ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_6__["BsDropdownModule"].forRoot(),
                ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_7__["ModalModule"].forRoot(),
                ngx_bootstrap_tabs__WEBPACK_IMPORTED_MODULE_8__["TabsModule"].forRoot(),
                ngx_bootstrap_collapse__WEBPACK_IMPORTED_MODULE_9__["CollapseModule"].forRoot()
            ],
            providers: [
                _service_service__WEBPACK_IMPORTED_MODULE_12__["CountryClient"],
                _service_service__WEBPACK_IMPORTED_MODULE_12__["ProjectClient"],
                _service_service__WEBPACK_IMPORTED_MODULE_12__["IssueClient"],
                _project_service__WEBPACK_IMPORTED_MODULE_18__["ProjectService"],
                _project_id_resolver__WEBPACK_IMPORTED_MODULE_19__["ProjectIdResolver"]
            ],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/countries/countries-list.component.html":
/*!*********************************************************!*\
  !*** ./src/app/countries/countries-list.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Country List</h1>\r\n<a  class=\"btn btn-primary\" [routerLink]=\"['new']\">new item</a>\r\n\r\n<div class=\"table-responsive\" *ngIf=\"items\">\r\n    <table class=\"table table-striped table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th scope=\"col\">Iso</th>\r\n                <th scope=\"col\">Name</th>\r\n                <th scope=\"col\"></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr *ngFor=\"let item of items\" (click)=\"select(item)\" [class.table-primary]=\"item == selectedItem\">\r\n                <td>{{item.isoTwo}}</td>\r\n                <td>{{item.name}}</td>\r\n                <td>\r\n                    <a class=\"btn btn-primary\" [routerLink]=\"[item.id]\" role=\"button\">edit</a>\r\n                    &nbsp;\r\n                    <button class=\"btn btn-primary\" (click)=\"delete(item)\" role=\"button\">delete</button>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>"

/***/ }),

/***/ "./src/app/countries/countries-list.component.ts":
/*!*******************************************************!*\
  !*** ./src/app/countries/countries-list.component.ts ***!
  \*******************************************************/
/*! exports provided: CountriesListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CountriesListComponent", function() { return CountriesListComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../service/service */ "./src/service/service.ts");



var CountriesListComponent = /** @class */ (function () {
    function CountriesListComponent(service) {
        this.service = service;
    }
    CountriesListComponent.prototype.ngOnInit = function () {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var data;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.getCountryListItems().toPromise()];
                    case 1:
                        data = _a.sent();
                        this.items = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    CountriesListComponent.prototype.select = function (item) {
        this.selectedItem = item;
    };
    CountriesListComponent.prototype.delete = function (item) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.deleteCountry(item.id).toPromise()];
                    case 1:
                        _a.sent();
                        return [4 /*yield*/, this.ngOnInit()];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    CountriesListComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'countries-list',
            template: __webpack_require__(/*! ./countries-list.component.html */ "./src/app/countries/countries-list.component.html")
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_service_service__WEBPACK_IMPORTED_MODULE_2__["CountryClient"]])
    ], CountriesListComponent);
    return CountriesListComponent;
}());



/***/ }),

/***/ "./src/app/countries/country-create.component.ts":
/*!*******************************************************!*\
  !*** ./src/app/countries/country-create.component.ts ***!
  \*******************************************************/
/*! exports provided: CountryCreateComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CountryCreateComponent", function() { return CountryCreateComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../service/service */ "./src/service/service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");




var CountryCreateComponent = /** @class */ (function () {
    function CountryCreateComponent(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
        this.item = new _service_service__WEBPACK_IMPORTED_MODULE_2__["CountryListItem"]();
    }
    CountryCreateComponent.prototype.save = function () {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var url;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.insertCountry(this.item).toPromise()];
                    case 1:
                        _a.sent();
                        url = this.getNavUrl(this.route);
                        return [4 /*yield*/, this.router.navigateByUrl(url)];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    CountryCreateComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    CountryCreateComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'country-create',
            template: __webpack_require__(/*! ./country-edit.component.html */ "./src/app/countries/country-edit.component.html")
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_service_service__WEBPACK_IMPORTED_MODULE_2__["CountryClient"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"]])
    ], CountryCreateComponent);
    return CountryCreateComponent;
}());



/***/ }),

/***/ "./src/app/countries/country-edit.component.html":
/*!*******************************************************!*\
  !*** ./src/app/countries/country-edit.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col align-self-center\">\r\n            <form *ngIf=\"item\">\r\n                <div class=\"form-group\">\r\n                    <label>Iso</label>\r\n                    <input type=\"text\" class=\"form-control\" [required] [maxlength]=\"2\" placeholder=\"Iso code\" [ngModelOptions]=\"{standalone: true}\" [(ngModel)]=\"item.isoTwo\">\r\n                </div>\r\n                <div class=\"form-group\">\r\n                        <label >Name</label>\r\n                        <input type=\"text\" class=\"form-control\" placeholder=\"Country name\" [ngModelOptions]=\"{standalone: true}\" [(ngModel)]=\"item.name\" />\r\n                </div>\r\n                \r\n                <button type=\"submit\" class=\"btn btn-primary\" (click)=\"save()\">Submit</button>\r\n            </form>\r\n        </div>\r\n    </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/countries/country-edit.component.ts":
/*!*****************************************************!*\
  !*** ./src/app/countries/country-edit.component.ts ***!
  \*****************************************************/
/*! exports provided: CountryEditComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CountryEditComponent", function() { return CountryEditComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../service/service */ "./src/service/service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");




var CountryEditComponent = /** @class */ (function () {
    function CountryEditComponent(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
    }
    CountryEditComponent.prototype.ngOnInit = function () {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var id, data;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0:
                        id = this.route.snapshot.params['id'];
                        return [4 /*yield*/, this.service.getCountry(id).toPromise()];
                    case 1:
                        data = _a.sent();
                        this.item = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    CountryEditComponent.prototype.save = function () {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var url;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.updateCountry(this.item).toPromise()];
                    case 1:
                        _a.sent();
                        url = this.getNavUrl(this.route);
                        return [4 /*yield*/, this.router.navigateByUrl(url)];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    CountryEditComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    CountryEditComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'country-edit',
            template: __webpack_require__(/*! ./country-edit.component.html */ "./src/app/countries/country-edit.component.html")
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_service_service__WEBPACK_IMPORTED_MODULE_2__["CountryClient"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"]])
    ], CountryEditComponent);
    return CountryEditComponent;
}());



/***/ }),

/***/ "./src/app/dashboard/dasbhoard.component.ts":
/*!**************************************************!*\
  !*** ./src/app/dashboard/dasbhoard.component.ts ***!
  \**************************************************/
/*! exports provided: DashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DashboardComponent", function() { return DashboardComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var DashboardComponent = /** @class */ (function () {
    function DashboardComponent() {
    }
    DashboardComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'dashboard',
            template: __webpack_require__(/*! ./dashboard.component.html */ "./src/app/dashboard/dashboard.component.html")
        })
    ], DashboardComponent);
    return DashboardComponent;
}());



/***/ }),

/***/ "./src/app/dashboard/dashboard.component.html":
/*!****************************************************!*\
  !*** ./src/app/dashboard/dashboard.component.html ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Dashboard</h1>"

/***/ }),

/***/ "./src/app/issues/issue-list.component.html":
/*!**************************************************!*\
  !*** ./src/app/issues/issue-list.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Country List</h1>\r\n<a class=\"btn btn-primary\" [routerLink]=\"['new']\">new item</a>\r\n\r\n<div class=\"table-responsive\" *ngIf=\"items\">\r\n    <table class=\"table table-striped table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th scope=\"col\">Title</th>\r\n                <th scope=\"col\">Description</th>\r\n                <th scope=\"col\">IssueType</th>\r\n                <th scope=\"col\">Assigned To</th>\r\n                <th scope=\"col\">Creation Time</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr *ngFor=\"let item of items\" (click)=\"select(item)\" [class.table-primary]=\"item == selectedItem\">\r\n                <td>{{item.title}}</td>\r\n                <td>{{item.description}}</td>\r\n                <td>{{item.issueType}}</td>\r\n                <td>{{item.assignedTo}}</td>\r\n                <td>{{item.createTime}}</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>"

/***/ }),

/***/ "./src/app/issues/issue-list.component.ts":
/*!************************************************!*\
  !*** ./src/app/issues/issue-list.component.ts ***!
  \************************************************/
/*! exports provided: IssueListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IssueListComponent", function() { return IssueListComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _src_service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../src/service/service */ "./src/service/service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");





var IssueListComponent = /** @class */ (function () {
    function IssueListComponent(service, currentRoute) {
        var _this = this;
        this.service = service;
        this.currentRoute = currentRoute;
        currentRoute.data.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(function (p) { return p.project; }))
            .subscribe(function (p) { return _this.loadData(p); });
    }
    IssueListComponent.prototype.loadData = function (project) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var data;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.getIssues(project.id).toPromise()];
                    case 1:
                        data = _a.sent();
                        this.items = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    IssueListComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'issue-list',
            template: __webpack_require__(/*! ./issue-list.component.html */ "./src/app/issues/issue-list.component.html")
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_src_service_service__WEBPACK_IMPORTED_MODULE_2__["IssueClient"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"]])
    ], IssueListComponent);
    return IssueListComponent;
}());



/***/ }),

/***/ "./src/app/project-id.resolver.ts":
/*!****************************************!*\
  !*** ./src/app/project-id.resolver.ts ***!
  \****************************************/
/*! exports provided: ProjectIdResolver */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProjectIdResolver", function() { return ProjectIdResolver; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _src_service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../src/service/service */ "./src/service/service.ts");
/* harmony import */ var _project_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./project.service */ "./src/app/project.service.ts");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");




var ProjectIdResolver = /** @class */ (function () {
    function ProjectIdResolver(service, projectService) {
        this.service = service;
        this.projectService = projectService;
    }
    ProjectIdResolver.prototype.resolve = function (route, state) {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var projectName, project;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_a) {
                switch (_a.label) {
                    case 0:
                        projectName = route.params.project;
                        return [4 /*yield*/, this.service.getProjectByName(projectName).toPromise()];
                    case 1:
                        project = _a.sent();
                        if (this.projectService.current.id != project.id) {
                            this.projectService.current = project;
                        }
                        return [2 /*return*/, project];
                }
            });
        });
    };
    ProjectIdResolver = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_src_service_service__WEBPACK_IMPORTED_MODULE_1__["ProjectClient"], _project_service__WEBPACK_IMPORTED_MODULE_2__["ProjectService"]])
    ], ProjectIdResolver);
    return ProjectIdResolver;
}());



/***/ }),

/***/ "./src/app/project.service.ts":
/*!************************************!*\
  !*** ./src/app/project.service.ts ***!
  \************************************/
/*! exports provided: ProjectService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProjectService", function() { return ProjectService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _src_service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../src/service/service */ "./src/service/service.ts");



var ProjectService = /** @class */ (function () {
    function ProjectService(service) {
        this.service = service;
        this.projects = [];
    }
    ProjectService.prototype.initialize = function () {
        return tslib__WEBPACK_IMPORTED_MODULE_0__["__awaiter"](this, void 0, void 0, function () {
            var _a;
            return tslib__WEBPACK_IMPORTED_MODULE_0__["__generator"](this, function (_b) {
                switch (_b.label) {
                    case 0:
                        _a = this;
                        return [4 /*yield*/, this.service.getProjects().toPromise()];
                    case 1:
                        _a.projects = _b.sent();
                        this.current = this.projects[0];
                        return [2 /*return*/];
                }
            });
        });
    };
    ProjectService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_src_service_service__WEBPACK_IMPORTED_MODULE_2__["ProjectClient"]])
    ], ProjectService);
    return ProjectService;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ "./src/service/service.ts":
/*!********************************!*\
  !*** ./src/service/service.ts ***!
  \********************************/
/*! exports provided: API_BASE_URL, OfflineClient, AreaClient, CountryClient, EmployeeClient, IssueClient, ProjectClient, AreaInfo, CountryListItem, CountryInfo, EmployeeInfo, IssueCreateData, IssueTypeInfo, IssueListItem, IssueCreateItem, ProjectInfo, SwaggerException */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "API_BASE_URL", function() { return API_BASE_URL; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "OfflineClient", function() { return OfflineClient; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AreaClient", function() { return AreaClient; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CountryClient", function() { return CountryClient; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EmployeeClient", function() { return EmployeeClient; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IssueClient", function() { return IssueClient; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProjectClient", function() { return ProjectClient; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AreaInfo", function() { return AreaInfo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CountryListItem", function() { return CountryListItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CountryInfo", function() { return CountryInfo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EmployeeInfo", function() { return EmployeeInfo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IssueCreateData", function() { return IssueCreateData; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IssueTypeInfo", function() { return IssueTypeInfo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IssueListItem", function() { return IssueListItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "IssueCreateItem", function() { return IssueCreateItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProjectInfo", function() { return ProjectInfo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SwaggerException", function() { return SwaggerException; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v12.2.0.0 (NJsonSchema v9.13.35.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming





var API_BASE_URL = new _angular_core__WEBPACK_IMPORTED_MODULE_3__["InjectionToken"]('API_BASE_URL');
var OfflineClient = /** @class */ (function () {
    function OfflineClient(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:5001";
    }
    OfflineClient.prototype.getOfflineDB = function (projectId) {
        var _this = this;
        var url_ = this.baseUrl + "/api/offline/db/{projectId}";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetOfflineDB(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetOfflineDB(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    OfflineClient.prototype.processGetOfflineDB = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : null;
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    OfflineClient = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"])), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Optional"])()), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(API_BASE_URL)),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"], String])
    ], OfflineClient);
    return OfflineClient;
}());

var AreaClient = /** @class */ (function () {
    function AreaClient(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:5001";
    }
    AreaClient.prototype.getAreaInfos = function () {
        var _this = this;
        var url_ = this.baseUrl + "/api/area/infos";
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetAreaInfos(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetAreaInfos(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    AreaClient.prototype.processGetAreaInfos = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                if (resultData200 && resultData200.constructor === Array) {
                    result200 = [];
                    for (var _i = 0, resultData200_1 = resultData200; _i < resultData200_1.length; _i++) {
                        var item = resultData200_1[_i];
                        result200.push(AreaInfo.fromJS(item));
                    }
                }
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    AreaClient = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"])), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Optional"])()), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(API_BASE_URL)),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"], String])
    ], AreaClient);
    return AreaClient;
}());

var CountryClient = /** @class */ (function () {
    function CountryClient(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:5001";
    }
    CountryClient.prototype.deleteCountry = function (id) {
        var _this = this;
        var url_ = this.baseUrl + "/api/country/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({})
        };
        return this.http.request("delete", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processDeleteCountry(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processDeleteCountry(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    CountryClient.prototype.processDeleteCountry = function (response) {
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    CountryClient.prototype.getCountry = function (id) {
        var _this = this;
        var url_ = this.baseUrl + "/api/country/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetCountry(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetCountry(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    CountryClient.prototype.processGetCountry = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                result200 = resultData200 ? CountryListItem.fromJS(resultData200) : null;
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    CountryClient.prototype.getCountryInfos = function () {
        var _this = this;
        var url_ = this.baseUrl + "/api/country/infos";
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetCountryInfos(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetCountryInfos(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    CountryClient.prototype.processGetCountryInfos = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                if (resultData200 && resultData200.constructor === Array) {
                    result200 = [];
                    for (var _i = 0, resultData200_2 = resultData200; _i < resultData200_2.length; _i++) {
                        var item = resultData200_2[_i];
                        result200.push(CountryInfo.fromJS(item));
                    }
                }
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    CountryClient.prototype.getCountryListItems = function () {
        var _this = this;
        var url_ = this.baseUrl + "/api/country/list";
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetCountryListItems(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetCountryListItems(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    CountryClient.prototype.processGetCountryListItems = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                if (resultData200 && resultData200.constructor === Array) {
                    result200 = [];
                    for (var _i = 0, resultData200_3 = resultData200; _i < resultData200_3.length; _i++) {
                        var item = resultData200_3[_i];
                        result200.push(CountryListItem.fromJS(item));
                    }
                }
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    CountryClient.prototype.insertCountry = function (item) {
        var _this = this;
        var url_ = this.baseUrl + "/api/country";
        url_ = url_.replace(/[?&]$/, "");
        var content_ = JSON.stringify(item);
        var options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("post", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processInsertCountry(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processInsertCountry(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    CountryClient.prototype.processInsertCountry = function (response) {
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    CountryClient.prototype.updateCountry = function (item) {
        var _this = this;
        var url_ = this.baseUrl + "/api/country";
        url_ = url_.replace(/[?&]$/, "");
        var content_ = JSON.stringify(item);
        var options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("put", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processUpdateCountry(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processUpdateCountry(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    CountryClient.prototype.processUpdateCountry = function (response) {
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    CountryClient = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"])), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Optional"])()), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(API_BASE_URL)),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"], String])
    ], CountryClient);
    return CountryClient;
}());

var EmployeeClient = /** @class */ (function () {
    function EmployeeClient(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:5001";
    }
    EmployeeClient.prototype.getEmployeeInfos = function (projectId) {
        var _this = this;
        var url_ = this.baseUrl + "/api/employee/{projectId}/all";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetEmployeeInfos(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetEmployeeInfos(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    EmployeeClient.prototype.processGetEmployeeInfos = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                if (resultData200 && resultData200.constructor === Array) {
                    result200 = [];
                    for (var _i = 0, resultData200_4 = resultData200; _i < resultData200_4.length; _i++) {
                        var item = resultData200_4[_i];
                        result200.push(EmployeeInfo.fromJS(item));
                    }
                }
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    EmployeeClient = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"])), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Optional"])()), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(API_BASE_URL)),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"], String])
    ], EmployeeClient);
    return EmployeeClient;
}());

var IssueClient = /** @class */ (function () {
    function IssueClient(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:5001";
    }
    IssueClient.prototype.getIssueCreate = function (projectId) {
        var _this = this;
        var url_ = this.baseUrl + "/api/issue/{projectId}/create";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetIssueCreate(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetIssueCreate(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    IssueClient.prototype.processGetIssueCreate = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                result200 = resultData200 ? IssueCreateData.fromJS(resultData200) : null;
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    IssueClient.prototype.getIssues = function (projectId) {
        var _this = this;
        var url_ = this.baseUrl + "/api/issue/{projectId}/list";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetIssues(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetIssues(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    IssueClient.prototype.processGetIssues = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                if (resultData200 && resultData200.constructor === Array) {
                    result200 = [];
                    for (var _i = 0, resultData200_5 = resultData200; _i < resultData200_5.length; _i++) {
                        var item = resultData200_5[_i];
                        result200.push(IssueListItem.fromJS(item));
                    }
                }
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    IssueClient.prototype.getIssueTypes = function () {
        var _this = this;
        var url_ = this.baseUrl + "/api/issue/types";
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetIssueTypes(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetIssueTypes(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    IssueClient.prototype.processGetIssueTypes = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                if (resultData200 && resultData200.constructor === Array) {
                    result200 = [];
                    for (var _i = 0, resultData200_6 = resultData200; _i < resultData200_6.length; _i++) {
                        var item = resultData200_6[_i];
                        result200.push(IssueTypeInfo.fromJS(item));
                    }
                }
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    IssueClient.prototype.insertIssue = function (issue) {
        var _this = this;
        var url_ = this.baseUrl + "/api/issue";
        url_ = url_.replace(/[?&]$/, "");
        var content_ = JSON.stringify(issue);
        var options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("post", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processInsertIssue(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processInsertIssue(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    IssueClient.prototype.processInsertIssue = function (response) {
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    IssueClient = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"])), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Optional"])()), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(API_BASE_URL)),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"], String])
    ], IssueClient);
    return IssueClient;
}());

var ProjectClient = /** @class */ (function () {
    function ProjectClient(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:5001";
    }
    ProjectClient.prototype.getProjectByName = function (name) {
        var _this = this;
        var url_ = this.baseUrl + "/api/project/search/{name}";
        if (name === undefined || name === null)
            throw new Error("The parameter 'name' must be defined.");
        url_ = url_.replace("{name}", encodeURIComponent("" + name));
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetProjectByName(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetProjectByName(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    ProjectClient.prototype.processGetProjectByName = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                result200 = resultData200 ? ProjectInfo.fromJS(resultData200) : null;
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    ProjectClient.prototype.getProjects = function () {
        var _this = this;
        var url_ = this.baseUrl + "/api/project/all";
        url_ = url_.replace(/[?&]$/, "");
        var options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpHeaders"]({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (response_) {
            return _this.processGetProjects(response_);
        })).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["catchError"])(function (response_) {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponseBase"]) {
                try {
                    return _this.processGetProjects(response_);
                }
                catch (e) {
                    return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(e);
                }
            }
            else
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(response_);
        }));
    };
    ProjectClient.prototype.processGetProjects = function (response) {
        var _this = this;
        var status = response.status;
        var responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpResponse"] ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        var _headers = {};
        if (response.headers) {
            for (var _i = 0, _a = response.headers.keys(); _i < _a.length; _i++) {
                var key = _a[_i];
                _headers[key] = response.headers.get(key);
            }
        }
        ;
        if (status === 200) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                var result200 = null;
                var resultData200 = _responseText === "" ? null : JSON.parse(_responseText, _this.jsonParseReviver);
                if (resultData200 && resultData200.constructor === Array) {
                    result200 = [];
                    for (var _i = 0, resultData200_7 = resultData200; _i < resultData200_7.length; _i++) {
                        var item = resultData200_7[_i];
                        result200.push(ProjectInfo.fromJS(item));
                    }
                }
                return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["mergeMap"])(function (_responseText) {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["of"])(null);
    };
    ProjectClient = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"])), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Optional"])()), tslib__WEBPACK_IMPORTED_MODULE_0__["__param"](1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["Inject"])(API_BASE_URL)),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClient"], String])
    ], ProjectClient);
    return ProjectClient;
}());

var AreaInfo = /** @class */ (function () {
    function AreaInfo(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    AreaInfo.prototype.init = function (data) {
        if (data) {
            this.areaName = data["areaName"];
            this.id = data["id"];
        }
    };
    AreaInfo.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new AreaInfo();
        result.init(data);
        return result;
    };
    AreaInfo.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["areaName"] = this.areaName;
        data["id"] = this.id;
        return data;
    };
    return AreaInfo;
}());

var CountryListItem = /** @class */ (function () {
    function CountryListItem(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    CountryListItem.prototype.init = function (data) {
        if (data) {
            this.id = data["id"];
            this.isoTwo = data["isoTwo"];
            this.name = data["name"];
        }
    };
    CountryListItem.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new CountryListItem();
        result.init(data);
        return result;
    };
    CountryListItem.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["isoTwo"] = this.isoTwo;
        data["name"] = this.name;
        return data;
    };
    return CountryListItem;
}());

var CountryInfo = /** @class */ (function () {
    function CountryInfo(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    CountryInfo.prototype.init = function (data) {
        if (data) {
            this.displayString = data["displayString"];
            this.id = data["id"];
        }
    };
    CountryInfo.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new CountryInfo();
        result.init(data);
        return result;
    };
    CountryInfo.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["displayString"] = this.displayString;
        data["id"] = this.id;
        return data;
    };
    return CountryInfo;
}());

var EmployeeInfo = /** @class */ (function () {
    function EmployeeInfo(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    EmployeeInfo.prototype.init = function (data) {
        if (data) {
            this.displayName = data["displayName"];
            this.id = data["id"];
        }
    };
    EmployeeInfo.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new EmployeeInfo();
        result.init(data);
        return result;
    };
    EmployeeInfo.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["displayName"] = this.displayName;
        data["id"] = this.id;
        return data;
    };
    return EmployeeInfo;
}());

var IssueCreateData = /** @class */ (function () {
    function IssueCreateData(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    IssueCreateData.prototype.init = function (data) {
        if (data) {
            if (data["employees"] && data["employees"].constructor === Array) {
                this.employees = [];
                for (var _i = 0, _a = data["employees"]; _i < _a.length; _i++) {
                    var item = _a[_i];
                    this.employees.push(EmployeeInfo.fromJS(item));
                }
            }
            if (data["issueTypes"] && data["issueTypes"].constructor === Array) {
                this.issueTypes = [];
                for (var _b = 0, _c = data["issueTypes"]; _b < _c.length; _b++) {
                    var item = _c[_b];
                    this.issueTypes.push(IssueTypeInfo.fromJS(item));
                }
            }
        }
    };
    IssueCreateData.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new IssueCreateData();
        result.init(data);
        return result;
    };
    IssueCreateData.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        if (this.employees && this.employees.constructor === Array) {
            data["employees"] = [];
            for (var _i = 0, _a = this.employees; _i < _a.length; _i++) {
                var item = _a[_i];
                data["employees"].push(item.toJSON());
            }
        }
        if (this.issueTypes && this.issueTypes.constructor === Array) {
            data["issueTypes"] = [];
            for (var _b = 0, _c = this.issueTypes; _b < _c.length; _b++) {
                var item = _c[_b];
                data["issueTypes"].push(item.toJSON());
            }
        }
        return data;
    };
    return IssueCreateData;
}());

var IssueTypeInfo = /** @class */ (function () {
    function IssueTypeInfo(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    IssueTypeInfo.prototype.init = function (data) {
        if (data) {
            this.displayString = data["displayString"];
            this.id = data["id"];
        }
    };
    IssueTypeInfo.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new IssueTypeInfo();
        result.init(data);
        return result;
    };
    IssueTypeInfo.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["displayString"] = this.displayString;
        data["id"] = this.id;
        return data;
    };
    return IssueTypeInfo;
}());

var IssueListItem = /** @class */ (function () {
    function IssueListItem(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    IssueListItem.prototype.init = function (data) {
        if (data) {
            this.assignedTo = data["assignedTo"];
            this.createTime = data["createTime"] ? new Date(data["createTime"].toString()) : undefined;
            this.description = data["description"];
            this.id = data["id"];
            this.issueType = data["issueType"];
            this.title = data["title"];
        }
    };
    IssueListItem.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new IssueListItem();
        result.init(data);
        return result;
    };
    IssueListItem.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["assignedTo"] = this.assignedTo;
        data["createTime"] = this.createTime ? this.createTime.toISOString() : undefined;
        data["description"] = this.description;
        data["id"] = this.id;
        data["issueType"] = this.issueType;
        data["title"] = this.title;
        return data;
    };
    return IssueListItem;
}());

var IssueCreateItem = /** @class */ (function () {
    function IssueCreateItem(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    IssueCreateItem.prototype.init = function (data) {
        if (data) {
            this.areaId = data["areaId"];
            this.assignedToId = data["assignedToId"];
            if (data["attachments"] && data["attachments"].constructor === Array) {
                this.attachments = [];
                for (var _i = 0, _a = data["attachments"]; _i < _a.length; _i++) {
                    var item = _a[_i];
                    this.attachments.push(item);
                }
            }
            this.creationTime = data["creationTime"] ? new Date(data["creationTime"].toString()) : undefined;
            this.descripton = data["descripton"];
            this.issueTypeId = data["issueTypeId"];
            this.title = data["title"];
        }
    };
    IssueCreateItem.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new IssueCreateItem();
        result.init(data);
        return result;
    };
    IssueCreateItem.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["areaId"] = this.areaId;
        data["assignedToId"] = this.assignedToId;
        if (this.attachments && this.attachments.constructor === Array) {
            data["attachments"] = [];
            for (var _i = 0, _a = this.attachments; _i < _a.length; _i++) {
                var item = _a[_i];
                data["attachments"].push(item);
            }
        }
        data["creationTime"] = this.creationTime ? this.creationTime.toISOString() : undefined;
        data["descripton"] = this.descripton;
        data["issueTypeId"] = this.issueTypeId;
        data["title"] = this.title;
        return data;
    };
    return IssueCreateItem;
}());

var ProjectInfo = /** @class */ (function () {
    function ProjectInfo(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    ProjectInfo.prototype.init = function (data) {
        if (data) {
            this.displayString = data["displayString"];
            this.id = data["id"];
        }
    };
    ProjectInfo.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new ProjectInfo();
        result.init(data);
        return result;
    };
    ProjectInfo.prototype.toJSON = function (data) {
        data = typeof data === 'object' ? data : {};
        data["displayString"] = this.displayString;
        data["id"] = this.id;
        return data;
    };
    return ProjectInfo;
}());

var SwaggerException = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](SwaggerException, _super);
    function SwaggerException(message, status, response, headers, result) {
        var _this = _super.call(this) || this;
        _this.isSwaggerException = true;
        _this.message = message;
        _this.status = status;
        _this.response = response;
        _this.headers = headers;
        _this.result = result;
        return _this;
    }
    SwaggerException.isSwaggerException = function (obj) {
        return obj.isSwaggerException === true;
    };
    return SwaggerException;
}(Error));

function throwException(message, status, response, headers, result) {
    if (result !== null && result !== undefined)
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(result);
    else
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(new SwaggerException(message, status, response, headers, null));
}
function blobToText(blob) {
    return new rxjs__WEBPACK_IMPORTED_MODULE_2__["Observable"](function (observer) {
        if (!blob) {
            observer.next("");
            observer.complete();
        }
        else {
            var reader = new FileReader();
            reader.onload = function (event) {
                observer.next(event.target.result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Projects\git_rschwarz\Samples\Azure\Xamarin.Offline\ConstructionDiary\ConstructionDiary.Web\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map