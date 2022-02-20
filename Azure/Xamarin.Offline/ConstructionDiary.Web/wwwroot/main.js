"use strict";
(self["webpackChunkconstruction_diary"] = self["webpackChunkconstruction_diary"] || []).push([["main"],{

/***/ 158:
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppRoutingModule": () => (/* binding */ AppRoutingModule)
/* harmony export */ });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./dashboard/dasbhoard.component */ 4590);
/* harmony import */ var _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./countries/countries-list.component */ 8619);
/* harmony import */ var _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./countries/country-edit.component */ 4817);
/* harmony import */ var _countries_country_create_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./countries/country-create.component */ 9533);
/* harmony import */ var _project_id_resolver__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./project-id.resolver */ 7987);
/* harmony import */ var _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./issues/issue-list.component */ 2489);
/* harmony import */ var _issue_types_issue_types_list_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./issue-types/issue-types-list.component */ 5306);
/* harmony import */ var _issue_types_issue_type_edit_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./issue-types/issue-type-edit.component */ 9037);
/* harmony import */ var _issue_types_issue_type_create_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./issue-types/issue-type-create.component */ 6703);
/* harmony import */ var _employees_employees_list_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./employees/employees-list.component */ 2459);
/* harmony import */ var _employees_employee_edit_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./employees/employee-edit.component */ 6966);
/* harmony import */ var _employees_employee_create_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./employees/employee-create.component */ 4749);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/core */ 3184);















const routes = [{
        path: 'dashboard',
        component: _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_0__.DashboardComponent
    },
    {
        path: 'countries',
        children: [
            {
                path: '',
                component: _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_1__.CountriesListComponent
            },
            {
                path: 'new',
                component: _countries_country_create_component__WEBPACK_IMPORTED_MODULE_3__.CountryCreateComponent
            },
            {
                path: ':id',
                component: _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_2__.CountryEditComponent
            },
        ]
    },
    {
        path: 'issuetypes',
        children: [
            {
                path: '',
                component: _issue_types_issue_types_list_component__WEBPACK_IMPORTED_MODULE_6__.IssueTypesListComponent
            },
            {
                path: 'new',
                component: _issue_types_issue_type_create_component__WEBPACK_IMPORTED_MODULE_8__.IssueTypeCreateComponent
            },
            {
                path: ':id',
                component: _issue_types_issue_type_edit_component__WEBPACK_IMPORTED_MODULE_7__.IssueTypeEditComponent
            }
        ]
    },
    {
        path: ':project',
        resolve: {
            project: _project_id_resolver__WEBPACK_IMPORTED_MODULE_4__.ProjectIdResolver
        },
        children: [
            {
                path: 'issues',
                children: [
                    {
                        path: '',
                        component: _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_5__.IssueListComponent
                    }
                ]
            },
            {
                path: 'employees',
                children: [
                    {
                        path: '',
                        component: _employees_employees_list_component__WEBPACK_IMPORTED_MODULE_9__.EmployeesListComponent
                    },
                    {
                        path: 'new',
                        component: _employees_employee_create_component__WEBPACK_IMPORTED_MODULE_11__.EmployeeCreateComponent
                    },
                    {
                        path: ':id',
                        component: _employees_employee_edit_component__WEBPACK_IMPORTED_MODULE_10__.EmployeeEditComponent
                    }
                ]
            }
        ]
    },
    {
        path: '**',
        redirectTo: 'dashboard'
    }];
class AppRoutingModule {
}
AppRoutingModule.ɵfac = function AppRoutingModule_Factory(t) { return new (t || AppRoutingModule)(); };
AppRoutingModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdefineNgModule"]({ type: AppRoutingModule });
AppRoutingModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵdefineInjector"]({ imports: [[_angular_router__WEBPACK_IMPORTED_MODULE_13__.RouterModule.forRoot(routes)], _angular_router__WEBPACK_IMPORTED_MODULE_13__.RouterModule] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_12__["ɵɵsetNgModuleScope"](AppRoutingModule, { imports: [_angular_router__WEBPACK_IMPORTED_MODULE_13__.RouterModule], exports: [_angular_router__WEBPACK_IMPORTED_MODULE_13__.RouterModule] }); })();


/***/ }),

/***/ 5041:
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppComponent": () => (/* binding */ AppComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _project_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./project.service */ 6176);
/* harmony import */ var ngx_bootstrap_collapse__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-bootstrap/collapse */ 3179);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ngx-bootstrap/dropdown */ 7281);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/forms */ 587);









const _c0 = function (a0) {
  return [a0, "issues"];
};

function AppComponent_li_10_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "li", 6)(1, "a", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2, "Issues");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction1"](1, _c0, ctx_r0.projectService.current.displayString));
  }
}

const _c1 = function (a0) {
  return [a0, "employees"];
};

function AppComponent_div_14_a_6_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "a", 17);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1, "Employees");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
  }

  if (rf & 2) {
    const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction1"](1, _c1, ctx_r4.projectService.current.displayString));
  }
}

const _c2 = function () {
  return ["countries"];
};

const _c3 = function () {
  return ["issuetypes"];
};

function AppComponent_div_14_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 16)(1, "a", 17);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2, "Countries");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "a", 17);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4, "Issue types");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](5, "div", 18);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](6, AppComponent_div_14_a_6_Template, 2, 3, "a", 19);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
  }

  if (rf & 2) {
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](3, _c2));
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](4, _c3));
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx_r1.projectService.current);
  }
}

function AppComponent_option_18_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "option", 20);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
  }

  if (rf & 2) {
    const item_r5 = ctx.$implicit;
    const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("value", item_r5.id);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵattribute"]("selected", ctx_r3.projectService.current && ctx_r3.projectService.current.id == item_r5.id ? "selected" : null);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](1);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r5.displayString);
  }
}

const _c4 = function () {
  return ["dashboard"];
};

class AppComponent {
  constructor(projectService) {
    this.projectService = projectService;
    this.isCollapsed = true;
  }

  ngOnInit() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      yield _this.projectService.initialize();
    })();
  }

  selectProject(projectid) {
    this.projectService.current = this.projectService.projects.filter(p => p.id == projectid)[0];
  }

}

AppComponent.ɵfac = function AppComponent_Factory(t) {
  return new (t || AppComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_project_service__WEBPACK_IMPORTED_MODULE_1__.ProjectService));
};

AppComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: AppComponent,
  selectors: [["app-root"]],
  decls: 20,
  vars: 5,
  consts: [[1, "navbar", "navbar-expand-lg", "navbar-light", "bg-light"], ["href", "#", 1, "navbar-brand"], ["type", "button", "data-toggle", "collapse", "data-target", "#navbarSupportedContent", "aria-controls", "navbarSupportedContent", "aria-expanded", "false", "aria-label", "Toggle navigation", 1, "navbar-toggler", 3, "click"], [1, "navbar-toggler-icon"], ["id", "navbarSupportedContent", 1, "collapse", "navbar-collapse", 3, "collapse"], [1, "navbar-nav", "mr-auto"], [1, "nav-item", "active"], ["routerLinkActive", "active", 1, "nav-link", 3, "routerLink"], ["class", "nav-item active", 4, "ngIf"], ["dropdown", "", 1, "nav-item", "dropdown"], ["dropdownToggle", "", "id", "navbarDropdown", "role", "button", "data-toggle", "dropdown", "aria-haspopup", "true", "aria-expanded", "false", 1, "nav-link", "dropdown-toggle"], ["class", "dropdown-menu", "aria-labelledby", "navbarDropdown", 4, "dropdownMenu"], [1, "form-inline", "my-2", "my-lg-0"], [1, "form-control", 3, "change"], ["p", ""], [3, "value", 4, "ngFor", "ngForOf"], ["aria-labelledby", "navbarDropdown", 1, "dropdown-menu"], ["routerLinkActive", "active", 1, "dropdown-item", 3, "routerLink"], [1, "dropdown-divider"], ["class", "dropdown-item", "routerLinkActive", "active", 3, "routerLink", 4, "ngIf"], [3, "value"]],
  template: function AppComponent_Template(rf, ctx) {
    if (rf & 1) {
      const _r6 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "nav", 0)(1, "a", 1);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2, "Construction Diary");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "button", 2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function AppComponent_Template_button_click_3_listener() {
        return ctx.isCollapsed = !ctx.isCollapsed;
      });
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](4, "span", 3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "div", 4)(6, "ul", 5)(7, "li", 6)(8, "a", 7);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](9, "Dashboard");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](10, AppComponent_li_10_Template, 3, 3, "li", 8);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](11, "li", 9)(12, "div", 10);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](13, " Masterdata ");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](14, AppComponent_div_14_Template, 7, 5, "div", 11);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](15, "form", 12)(16, "select", 13, 14);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("change", function AppComponent_Template_select_change_16_listener() {
        _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r6);

        const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵreference"](17);

        return ctx.selectProject(_r2.value);
      });
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](18, AppComponent_option_18_Template, 2, 3, "option", 15);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()()();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](19, "router-outlet");
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](5);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("collapse", ctx.isCollapsed);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](4, _c4));
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.projectService.current);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](8);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx.projectService.projects);
    }
  },
  directives: [ngx_bootstrap_collapse__WEBPACK_IMPORTED_MODULE_3__.CollapseDirective, _angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterLinkWithHref, _angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterLinkActive, _angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_6__.BsDropdownDirective, ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_6__.BsDropdownToggleDirective, ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_6__.BsDropdownMenuDirective, _angular_forms__WEBPACK_IMPORTED_MODULE_7__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_7__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_7__.NgForm, _angular_common__WEBPACK_IMPORTED_MODULE_5__.NgForOf, _angular_forms__WEBPACK_IMPORTED_MODULE_7__.NgSelectOption, _angular_forms__WEBPACK_IMPORTED_MODULE_7__["ɵNgSelectMultipleOption"], _angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterOutlet],
  encapsulation: 2
});

/***/ }),

/***/ 6747:
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppModule": () => (/* binding */ AppModule)
/* harmony export */ });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @angular/platform-browser */ 318);
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! @angular/platform-browser/animations */ 598);
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-routing.module */ 158);
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./app.component */ 5041);
/* harmony import */ var ngx_bootstrap_accordion__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ngx-bootstrap/accordion */ 819);
/* harmony import */ var ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ngx-bootstrap/dropdown */ 7281);
/* harmony import */ var ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ngx-bootstrap/modal */ 4712);
/* harmony import */ var ngx_bootstrap_tabs__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ngx-bootstrap/tabs */ 2916);
/* harmony import */ var ngx_bootstrap_collapse__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ngx-bootstrap/collapse */ 3179);
/* harmony import */ var _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./dashboard/dasbhoard.component */ 4590);
/* harmony import */ var _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./countries/countries-list.component */ 8619);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../service/service */ 6323);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! @angular/common/http */ 8784);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! @angular/forms */ 587);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./countries/country-edit.component */ 4817);
/* harmony import */ var _countries_country_create_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./countries/country-create.component */ 9533);
/* harmony import */ var _project_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./project.service */ 6176);
/* harmony import */ var _project_id_resolver__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./project-id.resolver */ 7987);
/* harmony import */ var _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./issues/issue-list.component */ 2489);
/* harmony import */ var _issue_types_issue_type_create_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./issue-types/issue-type-create.component */ 6703);
/* harmony import */ var _issue_types_issue_type_edit_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./issue-types/issue-type-edit.component */ 9037);
/* harmony import */ var _issue_types_issue_types_list_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./issue-types/issue-types-list.component */ 5306);
/* harmony import */ var _employees_employee_create_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./employees/employee-create.component */ 4749);
/* harmony import */ var _employees_employee_edit_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./employees/employee-edit.component */ 6966);
/* harmony import */ var _employees_employees_list_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./employees/employees-list.component */ 2459);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/core */ 3184);
































class AppModule {
}
AppModule.ɵfac = function AppModule_Factory(t) { return new (t || AppModule)(); };
AppModule.ɵmod = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_16__["ɵɵdefineNgModule"]({ type: AppModule, bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_1__.AppComponent] });
AppModule.ɵinj = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_16__["ɵɵdefineInjector"]({ providers: [
        _service_service__WEBPACK_IMPORTED_MODULE_4__.CountryServiceClient,
        _service_service__WEBPACK_IMPORTED_MODULE_4__.ProjectServiceClient,
        _service_service__WEBPACK_IMPORTED_MODULE_4__.IssueServiceClient,
        _service_service__WEBPACK_IMPORTED_MODULE_4__.EmployeeServiceClient,
        _project_service__WEBPACK_IMPORTED_MODULE_7__.ProjectService,
        _project_id_resolver__WEBPACK_IMPORTED_MODULE_8__.ProjectIdResolver
    ], imports: [[
            _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_17__.BrowserAnimationsModule,
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_18__.BrowserModule,
            _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
            _angular_common_http__WEBPACK_IMPORTED_MODULE_19__.HttpClientModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_20__.FormsModule,
            _angular_common__WEBPACK_IMPORTED_MODULE_21__.CommonModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_20__.ReactiveFormsModule,
            ngx_bootstrap_accordion__WEBPACK_IMPORTED_MODULE_22__.AccordionModule.forRoot(),
            ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_23__.BsDropdownModule.forRoot(),
            ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_24__.ModalModule.forRoot(),
            ngx_bootstrap_tabs__WEBPACK_IMPORTED_MODULE_25__.TabsModule.forRoot(),
            ngx_bootstrap_collapse__WEBPACK_IMPORTED_MODULE_26__.CollapseModule.forRoot()
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_16__["ɵɵsetNgModuleScope"](AppModule, { declarations: [_app_component__WEBPACK_IMPORTED_MODULE_1__.AppComponent,
        _dashboard_dasbhoard_component__WEBPACK_IMPORTED_MODULE_2__.DashboardComponent,
        _countries_countries_list_component__WEBPACK_IMPORTED_MODULE_3__.CountriesListComponent,
        _countries_country_edit_component__WEBPACK_IMPORTED_MODULE_5__.CountryEditComponent,
        _countries_country_create_component__WEBPACK_IMPORTED_MODULE_6__.CountryCreateComponent,
        _issues_issue_list_component__WEBPACK_IMPORTED_MODULE_9__.IssueListComponent,
        _issue_types_issue_type_create_component__WEBPACK_IMPORTED_MODULE_10__.IssueTypeCreateComponent,
        _issue_types_issue_type_edit_component__WEBPACK_IMPORTED_MODULE_11__.IssueTypeEditComponent,
        _issue_types_issue_types_list_component__WEBPACK_IMPORTED_MODULE_12__.IssueTypesListComponent,
        _employees_employee_create_component__WEBPACK_IMPORTED_MODULE_13__.EmployeeCreateComponent,
        _employees_employee_edit_component__WEBPACK_IMPORTED_MODULE_14__.EmployeeEditComponent,
        _employees_employees_list_component__WEBPACK_IMPORTED_MODULE_15__.EmployeesListComponent], imports: [_angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_17__.BrowserAnimationsModule,
        _angular_platform_browser__WEBPACK_IMPORTED_MODULE_18__.BrowserModule,
        _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
        _angular_common_http__WEBPACK_IMPORTED_MODULE_19__.HttpClientModule,
        _angular_forms__WEBPACK_IMPORTED_MODULE_20__.FormsModule,
        _angular_common__WEBPACK_IMPORTED_MODULE_21__.CommonModule,
        _angular_forms__WEBPACK_IMPORTED_MODULE_20__.ReactiveFormsModule, ngx_bootstrap_accordion__WEBPACK_IMPORTED_MODULE_22__.AccordionModule, ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_23__.BsDropdownModule, ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_24__.ModalModule, ngx_bootstrap_tabs__WEBPACK_IMPORTED_MODULE_25__.TabsModule, ngx_bootstrap_collapse__WEBPACK_IMPORTED_MODULE_26__.CollapseModule] }); })();


/***/ }),

/***/ 8619:
/*!*******************************************************!*\
  !*** ./src/app/countries/countries-list.component.ts ***!
  \*******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CountriesListComponent": () => (/* binding */ CountriesListComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);






const _c0 = function (a0) {
  return [a0];
};

function CountriesListComponent_div_4_tr_10_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "tr", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CountriesListComponent_div_4_tr_10_Template_tr_click_0_listener() {
      const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r4);
      const item_r2 = restoredCtx.$implicit;
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
      return ctx_r3.select(item_r2);
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "td")(6, "a", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "edit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](8, " \u00A0 ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CountriesListComponent_div_4_tr_10_Template_button_click_9_listener() {
      const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r4);
      const item_r2 = restoredCtx.$implicit;
      const ctx_r5 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
      return ctx_r5.delete(item_r2);
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "delete");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
  }

  if (rf & 2) {
    const item_r2 = ctx.$implicit;
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵclassProp"]("table-primary", item_r2 == ctx_r1.selectedItem);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.isoTwo);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.name);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction1"](5, _c0, item_r2.id));
  }
}

function CountriesListComponent_div_4_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 2)(1, "table", 3)(2, "thead")(3, "tr")(4, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](5, "Iso");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](6, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Name");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](8, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "tbody");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](10, CountriesListComponent_div_4_tr_10_Template, 11, 7, "tr", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](10);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx_r0.items);
  }
}

const _c1 = function () {
  return ["new"];
};

class CountriesListComponent {
  constructor(service) {
    this.service = service;
    this.items = [];
  }

  ngOnInit() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      const data = yield _this.service.getCountryListItems().toPromise();

      if (data) {
        _this.items = data;
      }
    })();
  }

  select(item) {
    this.selectedItem = item;
  }

  delete(item) {
    var _this2 = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      if (item.id) {
        yield _this2.service.deleteCountry(item.id).toPromise();
        yield _this2.ngOnInit();
      }
    })();
  }

}

CountriesListComponent.ɵfac = function CountriesListComponent_Factory(t) {
  return new (t || CountriesListComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.CountryServiceClient));
};

CountriesListComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: CountriesListComponent,
  selectors: [["countries-list"]],
  decls: 5,
  vars: 3,
  consts: [[1, "btn", "btn-primary", 3, "routerLink"], ["class", "table-responsive", 4, "ngIf"], [1, "table-responsive"], [1, "table", "table-striped", "table-hover"], ["scope", "col"], [3, "table-primary", "click", 4, "ngFor", "ngForOf"], [3, "click"], ["role", "button", 1, "btn", "btn-primary", 3, "routerLink"], ["role", "button", 1, "btn", "btn-primary", 3, "click"]],
  template: function CountriesListComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1, "Country List");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](2, "a", 0);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "new item");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, CountriesListComponent_div_4_Template, 11, 1, "div", 1);
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](2, _c1));
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.items);
    }
  },
  directives: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterLinkWithHref, _angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_common__WEBPACK_IMPORTED_MODULE_4__.NgForOf],
  encapsulation: 2
});

/***/ }),

/***/ 9533:
/*!*******************************************************!*\
  !*** ./src/app/countries/country-create.component.ts ***!
  \*******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CountryCreateComponent": () => (/* binding */ CountryCreateComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 587);








const _c0 = function () {
  return {
    standalone: true
  };
};

function CountryCreateComponent_form_3_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "form")(1, "div", 4)(2, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "Iso");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](4, "input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function CountryCreateComponent_form_3_Template_input_ngModelChange_4_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r1.item.isoTwo = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "div", 4)(6, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Name");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function CountryCreateComponent_form_3_Template_input_ngModelChange_8_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r3.item.name = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CountryCreateComponent_form_3_Template_button_click_9_listener() {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r4.save();
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "Submit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("required", true)("maxlength", 2)("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](6, _c0))("ngModel", ctx_r0.item.isoTwo);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](7, _c0))("ngModel", ctx_r0.item.name);
  }
}

class CountryCreateComponent {
  constructor(service, route, router) {
    this.service = service;
    this.route = route;
    this.router = router;
    this.item = new _service_service__WEBPACK_IMPORTED_MODULE_1__.CountryListItem();
  }

  save() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      yield _this.service.insertCountry(_this.item).toPromise();

      const url = _this.getNavUrl(_this.route);

      yield _this.router.navigateByUrl(url);
    })();
  }

  getNavUrl(route) {
    if (route.parent) {
      var items = route.parent.snapshot.pathFromRoot;
      return items.map(p => p.url.join('/')).join('/');
    }

    return "";
  }

}

CountryCreateComponent.ɵfac = function CountryCreateComponent_Factory(t) {
  return new (t || CountryCreateComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.CountryServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.Router));
};

CountryCreateComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: CountryCreateComponent,
  selectors: [["country-create"]],
  decls: 4,
  vars: 1,
  consts: [[1, "container"], [1, "row"], [1, "col", "align-self-center"], [4, "ngIf"], [1, "form-group"], ["type", "text", "placeholder", "Iso code", 1, "form-control", 3, "required", "maxlength", "ngModelOptions", "ngModel", "ngModelChange"], ["type", "text", "placeholder", "Country name", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "submit", 1, "btn", "btn-primary", 3, "click"]],
  template: function CountryCreateComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](3, CountryCreateComponent_form_3_Template, 11, 8, "form", 3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.item);
    }
  },
  directives: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_forms__WEBPACK_IMPORTED_MODULE_5__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgForm, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.RequiredValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.MaxLengthValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgModel],
  encapsulation: 2
});

/***/ }),

/***/ 4817:
/*!*****************************************************!*\
  !*** ./src/app/countries/country-edit.component.ts ***!
  \*****************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CountryEditComponent": () => (/* binding */ CountryEditComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 587);







const _c0 = function () {
  return {
    standalone: true
  };
};

function CountryEditComponent_form_3_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "form")(1, "div", 4)(2, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "Iso");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](4, "input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function CountryEditComponent_form_3_Template_input_ngModelChange_4_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r1.item.isoTwo = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "div", 4)(6, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Name");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function CountryEditComponent_form_3_Template_input_ngModelChange_8_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r3.item.name = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function CountryEditComponent_form_3_Template_button_click_9_listener() {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r4.save();
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "Submit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("required", true)("maxlength", 2)("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](6, _c0))("ngModel", ctx_r0.item.isoTwo);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](7, _c0))("ngModel", ctx_r0.item.name);
  }
}

class CountryEditComponent {
  constructor(service, route, router) {
    this.service = service;
    this.route = route;
    this.router = router;
  }

  ngOnInit() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      var id = _this.route.snapshot.params['id'];
      const data = yield _this.service.getCountry(id).toPromise();

      if (data) {
        _this.item = data;
      }
    })();
  }

  save() {
    var _this2 = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      if (_this2.item) {
        yield _this2.service.updateCountry(_this2.item).toPromise();

        const url = _this2.getNavUrl(_this2.route);

        yield _this2.router.navigateByUrl(url);
      }
    })();
  }

  getNavUrl(route) {
    if (route.parent) {
      var items = route.parent.snapshot.pathFromRoot;
      return items.map(p => p.url.join('/')).join('/');
    }

    return "";
  }

}

CountryEditComponent.ɵfac = function CountryEditComponent_Factory(t) {
  return new (t || CountryEditComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.CountryServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.Router));
};

CountryEditComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: CountryEditComponent,
  selectors: [["country-edit"]],
  decls: 4,
  vars: 1,
  consts: [[1, "container"], [1, "row"], [1, "col", "align-self-center"], [4, "ngIf"], [1, "form-group"], ["type", "text", "placeholder", "Iso code", 1, "form-control", 3, "required", "maxlength", "ngModelOptions", "ngModel", "ngModelChange"], ["type", "text", "placeholder", "Country name", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "submit", 1, "btn", "btn-primary", 3, "click"]],
  template: function CountryEditComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](3, CountryEditComponent_form_3_Template, 11, 8, "form", 3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.item);
    }
  },
  directives: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_forms__WEBPACK_IMPORTED_MODULE_5__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgForm, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.RequiredValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.MaxLengthValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgModel],
  encapsulation: 2
});

/***/ }),

/***/ 4590:
/*!**************************************************!*\
  !*** ./src/app/dashboard/dasbhoard.component.ts ***!
  \**************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DashboardComponent": () => (/* binding */ DashboardComponent)
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ 3184);

class DashboardComponent {
}
DashboardComponent.ɵfac = function DashboardComponent_Factory(t) { return new (t || DashboardComponent)(); };
DashboardComponent.ɵcmp = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: DashboardComponent, selectors: [["dashboard"]], decls: 2, vars: 0, template: function DashboardComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementStart"](0, "h1");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵtext"](1, "Dashboard");
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelementEnd"]();
    } }, encapsulation: 2 });


/***/ }),

/***/ 4749:
/*!********************************************************!*\
  !*** ./src/app/employees/employee-create.component.ts ***!
  \********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "EmployeeCreateComponent": () => (/* binding */ EmployeeCreateComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 6942);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 587);









const _c0 = function () {
  return {
    standalone: true
  };
};

function EmployeeCreateComponent_form_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "form")(1, "div", 4)(2, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "Firstname");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](4, "input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function EmployeeCreateComponent_form_5_Template_input_ngModelChange_4_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r1.item.firstName = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "div", 4)(6, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Lastname");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function EmployeeCreateComponent_form_5_Template_input_ngModelChange_8_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r3.item.lastName = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function EmployeeCreateComponent_form_5_Template_button_click_9_listener() {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r4.save();
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "Submit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](4, _c0))("ngModel", ctx_r0.item.firstName);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](5, _c0))("ngModel", ctx_r0.item.lastName);
  }
}

class EmployeeCreateComponent {
  constructor(service, route, router) {
    this.service = service;
    this.route = route;
    this.router = router;
    this.item = new _service_service__WEBPACK_IMPORTED_MODULE_1__.EmployeeListItem();
    route.data.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.map)(p => {
      var _a;

      return (_a = p['project']) !== null && _a !== void 0 ? _a : null;
    })).subscribe(p => {
      this.project = p;
    });
  }

  save() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      var _a;

      if ((_a = _this.project) === null || _a === void 0 ? void 0 : _a.id) {
        yield _this.service.insert(_this.project.id, _this.item).toPromise();

        const url = _this.getNavUrl(_this.route);

        yield _this.router.navigateByUrl(url);
      }
    })();
  }

  getNavUrl(route) {
    if (route.parent) {
      var items = route.parent.snapshot.pathFromRoot;
      return items.map(p => p.url.join('/')).join('/');
    }

    return "";
  }

}

EmployeeCreateComponent.ɵfac = function EmployeeCreateComponent_Factory(t) {
  return new (t || EmployeeCreateComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.EmployeeServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.Router));
};

EmployeeCreateComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: EmployeeCreateComponent,
  selectors: [["employee-create"]],
  decls: 6,
  vars: 1,
  consts: [[1, "container"], [1, "row"], [1, "col", "align-self-center"], [4, "ngIf"], [1, "form-group"], ["type", "text", "required", "", "placeholder", "Firstname", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "text", "placeholder", "Lastname", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "submit", 1, "btn", "btn-primary", 3, "click"]],
  template: function EmployeeCreateComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2)(3, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4, "Employee");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](5, EmployeeCreateComponent_form_5_Template, 11, 6, "form", 3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](5);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.item);
    }
  },
  directives: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _angular_forms__WEBPACK_IMPORTED_MODULE_6__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgForm, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.RequiredValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgModel],
  encapsulation: 2
});

/***/ }),

/***/ 6966:
/*!******************************************************!*\
  !*** ./src/app/employees/employee-edit.component.ts ***!
  \******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "EmployeeEditComponent": () => (/* binding */ EmployeeEditComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 6942);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 587);








const _c0 = function () {
  return {
    standalone: true
  };
};

function EmployeeEditComponent_form_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "form")(1, "div", 4)(2, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "Firstname");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](4, "input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function EmployeeEditComponent_form_5_Template_input_ngModelChange_4_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r1.item.firstName = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "div", 4)(6, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Lastname");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function EmployeeEditComponent_form_5_Template_input_ngModelChange_8_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r3.item.lastName = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function EmployeeEditComponent_form_5_Template_button_click_9_listener() {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r4.save();
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "Submit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](4, _c0))("ngModel", ctx_r0.item.firstName);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](5, _c0))("ngModel", ctx_r0.item.lastName);
  }
}

class EmployeeEditComponent {
  constructor(service, route, router) {
    this.service = service;
    this.route = route;
    this.router = router;
    route.data.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.map)(p => p['project'])).subscribe(p => {
      this.project = p;
      this.loadData();
    });
  }

  loadData() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      var id = _this.route.snapshot.params['id'];
      const data = yield _this.service.getEmployeeListItem(id).toPromise();

      if (data) {
        _this.item = data;
      }
    })();
  }

  save() {
    var _this2 = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      if (_this2.item) {
        yield _this2.service.update(_this2.item).toPromise();

        const url = _this2.getNavUrl(_this2.route);

        yield _this2.router.navigateByUrl(url);
      }
    })();
  }

  getNavUrl(route) {
    if (route.parent) {
      var items = route.parent.snapshot.pathFromRoot;
      return items.map(p => p.url.join('/')).join('/');
    }

    return "";
  }

}

EmployeeEditComponent.ɵfac = function EmployeeEditComponent_Factory(t) {
  return new (t || EmployeeEditComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.EmployeeServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.Router));
};

EmployeeEditComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: EmployeeEditComponent,
  selectors: [["employee-edit"]],
  decls: 6,
  vars: 1,
  consts: [[1, "container"], [1, "row"], [1, "col", "align-self-center"], [4, "ngIf"], [1, "form-group"], ["type", "text", "required", "", "placeholder", "Firstname", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "text", "placeholder", "Lastname", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "submit", 1, "btn", "btn-primary", 3, "click"]],
  template: function EmployeeEditComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2)(3, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4, "Employee");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](5, EmployeeEditComponent_form_5_Template, 11, 6, "form", 3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](5);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.item);
    }
  },
  directives: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _angular_forms__WEBPACK_IMPORTED_MODULE_6__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgForm, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.RequiredValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_6__.NgModel],
  encapsulation: 2
});

/***/ }),

/***/ 2459:
/*!*******************************************************!*\
  !*** ./src/app/employees/employees-list.component.ts ***!
  \*******************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "EmployeesListComponent": () => (/* binding */ EmployeesListComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 6942);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 6362);







const _c0 = function (a0) {
  return [a0];
};

function EmployeesListComponent_div_4_tr_14_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "tr", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function EmployeesListComponent_div_4_tr_14_Template_tr_click_0_listener() {
      const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r4);
      const item_r2 = restoredCtx.$implicit;
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
      return ctx_r3.select(item_r2);
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](7, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](8);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "td")(10, "a", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](11, "edit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](12, " \u00A0 ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](13, "button", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function EmployeesListComponent_div_4_tr_14_Template_button_click_13_listener() {
      const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r4);
      const item_r2 = restoredCtx.$implicit;
      const ctx_r5 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
      return ctx_r5.delete(item_r2);
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](14, "delete");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
  }

  if (rf & 2) {
    const item_r2 = ctx.$implicit;
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵclassProp"]("table-primary", item_r2 == ctx_r1.selectedItem);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.firstName);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.lastName);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.created);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.isDisabled);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction1"](7, _c0, item_r2.id));
  }
}

function EmployeesListComponent_div_4_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 2)(1, "table", 3)(2, "thead")(3, "tr")(4, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](5, "Firstname");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](6, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Lastname");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](9, "Created");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](10, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](11, "Disabled");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](12, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](13, "tbody");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](14, EmployeesListComponent_div_4_tr_14_Template, 15, 9, "tr", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](14);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx_r0.items);
  }
}

const _c1 = function () {
  return ["new"];
};

class EmployeesListComponent {
  constructor(service, currentRoute) {
    this.service = service;
    this.items = [];
    currentRoute.data.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.map)(p => p['project'])).subscribe(p => {
      this.project = p;
      this.loadData();
    });
  }

  loadData() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      var _a;

      if ((_a = _this.project) === null || _a === void 0 ? void 0 : _a.id) {
        const data = yield _this.service.getEmployeeListItems(_this.project.id).toPromise();

        if (data) {
          _this.items = data;
        }
      }
    })();
  }

  select(item) {
    this.selectedItem = item;
  }

  delete(item) {
    var _this2 = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      if (item.id) {
        yield _this2.service.delete(item.id).toPromise();
        yield _this2.loadData();
      }
    })();
  }

}

EmployeesListComponent.ɵfac = function EmployeesListComponent_Factory(t) {
  return new (t || EmployeesListComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.EmployeeServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute));
};

EmployeesListComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: EmployeesListComponent,
  selectors: [["employees-list"]],
  decls: 5,
  vars: 3,
  consts: [[1, "btn", "btn-primary", 3, "routerLink"], ["class", "table-responsive", 4, "ngIf"], [1, "table-responsive"], [1, "table", "table-striped", "table-hover"], ["scope", "col"], [3, "table-primary", "click", 4, "ngFor", "ngForOf"], [3, "click"], ["role", "button", 1, "btn", "btn-primary", 3, "routerLink"], ["role", "button", 1, "btn", "btn-primary", 3, "click"]],
  template: function EmployeesListComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1, "Employee List");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](2, "a", 0);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "new item");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, EmployeesListComponent_div_4_Template, 15, 1, "div", 1);
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](2, _c1));
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.items);
    }
  },
  directives: [_angular_router__WEBPACK_IMPORTED_MODULE_4__.RouterLinkWithHref, _angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _angular_common__WEBPACK_IMPORTED_MODULE_5__.NgForOf],
  encapsulation: 2
});

/***/ }),

/***/ 6703:
/*!************************************************************!*\
  !*** ./src/app/issue-types/issue-type-create.component.ts ***!
  \************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "IssueTypeCreateComponent": () => (/* binding */ IssueTypeCreateComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 587);








const _c0 = function () {
  return {
    standalone: true
  };
};

function IssueTypeCreateComponent_form_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "form")(1, "div", 4)(2, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "Title");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](4, "input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function IssueTypeCreateComponent_form_5_Template_input_ngModelChange_4_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r1.item.title = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "div", 4)(6, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Description");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function IssueTypeCreateComponent_form_5_Template_input_ngModelChange_8_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r3.item.description = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function IssueTypeCreateComponent_form_5_Template_button_click_9_listener() {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r4.save();
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "Submit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](4, _c0))("ngModel", ctx_r0.item.title);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](5, _c0))("ngModel", ctx_r0.item.description);
  }
}

class IssueTypeCreateComponent {
  constructor(service, route, router) {
    this.service = service;
    this.route = route;
    this.router = router;
    this.item = new _service_service__WEBPACK_IMPORTED_MODULE_1__.IssueTypeListItem();
  }

  save() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      yield _this.service.insertIssueType(_this.item).toPromise();

      const url = _this.getNavUrl(_this.route);

      yield _this.router.navigateByUrl(url);
    })();
  }

  getNavUrl(route) {
    if (route.parent) {
      var items = route.parent.snapshot.pathFromRoot;
      return items.map(p => p.url.join('/')).join('/');
    }

    return "";
  }

}

IssueTypeCreateComponent.ɵfac = function IssueTypeCreateComponent_Factory(t) {
  return new (t || IssueTypeCreateComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.IssueServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.Router));
};

IssueTypeCreateComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: IssueTypeCreateComponent,
  selectors: [["issue-type-create"]],
  decls: 6,
  vars: 1,
  consts: [[1, "container"], [1, "row"], [1, "col", "align-self-center"], [4, "ngIf"], [1, "form-group"], ["type", "text", "required", "", "placeholder", "Title", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "text", "placeholder", "Description", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "submit", 1, "btn", "btn-primary", 3, "click"]],
  template: function IssueTypeCreateComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2)(3, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4, "Issue Type");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](5, IssueTypeCreateComponent_form_5_Template, 11, 6, "form", 3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](5);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.item);
    }
  },
  directives: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_forms__WEBPACK_IMPORTED_MODULE_5__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgForm, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.RequiredValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgModel],
  encapsulation: 2
});

/***/ }),

/***/ 9037:
/*!**********************************************************!*\
  !*** ./src/app/issue-types/issue-type-edit.component.ts ***!
  \**********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "IssueTypeEditComponent": () => (/* binding */ IssueTypeEditComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 587);







const _c0 = function () {
  return {
    standalone: true
  };
};

function IssueTypeEditComponent_form_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "form")(1, "div", 4)(2, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "Title");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](4, "input", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function IssueTypeEditComponent_form_5_Template_input_ngModelChange_4_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r1.item.title = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "div", 4)(6, "label");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Description");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "input", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("ngModelChange", function IssueTypeEditComponent_form_5_Template_input_ngModelChange_8_listener($event) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r3.item.description = $event;
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function IssueTypeEditComponent_form_5_Template_button_click_9_listener() {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r2);
      const ctx_r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
      return ctx_r4.save();
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "Submit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](4, _c0))("ngModel", ctx_r0.item.title);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngModelOptions", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](5, _c0))("ngModel", ctx_r0.item.description);
  }
}

class IssueTypeEditComponent {
  constructor(service, route, router) {
    this.service = service;
    this.route = route;
    this.router = router;
  }

  ngOnInit() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      var id = _this.route.snapshot.params['id'];
      const data = yield _this.service.getIssueType(id).toPromise();

      if (data) {
        _this.item = data;
      }
    })();
  }

  save() {
    var _this2 = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      if (_this2.item) {
        yield _this2.service.updateIssueType(_this2.item).toPromise();

        const url = _this2.getNavUrl(_this2.route);

        yield _this2.router.navigateByUrl(url);
      }
    })();
  }

  getNavUrl(route) {
    if (route.parent) {
      var items = route.parent.snapshot.pathFromRoot;
      return items.map(p => p.url.join('/')).join('/');
    }

    return "";
  }

}

IssueTypeEditComponent.ɵfac = function IssueTypeEditComponent_Factory(t) {
  return new (t || IssueTypeEditComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.IssueServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.Router));
};

IssueTypeEditComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: IssueTypeEditComponent,
  selectors: [["country-edit"]],
  decls: 6,
  vars: 1,
  consts: [[1, "container"], [1, "row"], [1, "col", "align-self-center"], [4, "ngIf"], [1, "form-group"], ["type", "text", "required", "", "placeholder", "Title", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "text", "placeholder", "Description", 1, "form-control", 3, "ngModelOptions", "ngModel", "ngModelChange"], ["type", "submit", 1, "btn", "btn-primary", 3, "click"]],
  template: function IssueTypeEditComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 0)(1, "div", 1)(2, "div", 2)(3, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4, "Issue Type");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](5, IssueTypeEditComponent_form_5_Template, 11, 6, "form", 3);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](5);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.item);
    }
  },
  directives: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_forms__WEBPACK_IMPORTED_MODULE_5__["ɵNgNoValidate"], _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatusGroup, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgForm, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.DefaultValueAccessor, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.RequiredValidator, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgControlStatus, _angular_forms__WEBPACK_IMPORTED_MODULE_5__.NgModel],
  encapsulation: 2
});

/***/ }),

/***/ 5306:
/*!***********************************************************!*\
  !*** ./src/app/issue-types/issue-types-list.component.ts ***!
  \***********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "IssueTypesListComponent": () => (/* binding */ IssueTypesListComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../service/service */ 6323);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);






const _c0 = function (a0) {
  return [a0];
};

function IssueTypesListComponent_div_4_tr_10_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "tr", 6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function IssueTypesListComponent_div_4_tr_10_Template_tr_click_0_listener() {
      const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r4);
      const item_r2 = restoredCtx.$implicit;
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
      return ctx_r3.select(item_r2);
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "td")(6, "a", 7);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "edit");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](8, " \u00A0 ");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "button", 8);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function IssueTypesListComponent_div_4_tr_10_Template_button_click_9_listener() {
      const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r4);
      const item_r2 = restoredCtx.$implicit;
      const ctx_r5 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
      return ctx_r5.delete(item_r2);
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10, "delete");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
  }

  if (rf & 2) {
    const item_r2 = ctx.$implicit;
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵclassProp"]("table-primary", item_r2 == ctx_r1.selectedItem);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.title);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.description);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction1"](5, _c0, item_r2.id));
  }
}

function IssueTypesListComponent_div_4_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 2)(1, "table", 3)(2, "thead")(3, "tr")(4, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](5, "Title");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](6, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Description");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelement"](8, "th", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "tbody");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](10, IssueTypesListComponent_div_4_tr_10_Template, 11, 7, "tr", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](10);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx_r0.items);
  }
}

const _c1 = function () {
  return ["new"];
};

class IssueTypesListComponent {
  constructor(service) {
    this.service = service;
    this.items = [];
  }

  ngOnInit() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      const data = yield _this.service.getIssueTypeListItems().toPromise();

      if (data) {
        _this.items = data;
      }
    })();
  }

  select(item) {
    this.selectedItem = item;
  }

  delete(item) {
    var _this2 = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      if (item.id) {
        yield _this2.service.deleteIssueType(item.id).toPromise();
        yield _this2.ngOnInit();
      }
    })();
  }

}

IssueTypesListComponent.ɵfac = function IssueTypesListComponent_Factory(t) {
  return new (t || IssueTypesListComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_service_service__WEBPACK_IMPORTED_MODULE_1__.IssueServiceClient));
};

IssueTypesListComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: IssueTypesListComponent,
  selectors: [["issue-types-list"]],
  decls: 5,
  vars: 3,
  consts: [[1, "btn", "btn-primary", 3, "routerLink"], ["class", "table-responsive", 4, "ngIf"], [1, "table-responsive"], [1, "table", "table-striped", "table-hover"], ["scope", "col"], [3, "table-primary", "click", 4, "ngFor", "ngForOf"], [3, "click"], ["role", "button", 1, "btn", "btn-primary", 3, "routerLink"], ["role", "button", 1, "btn", "btn-primary", 3, "click"]],
  template: function IssueTypesListComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1, "Issue Type List");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](2, "a", 0);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](3, "new item");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](4, IssueTypesListComponent_div_4_Template, 11, 1, "div", 1);
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("routerLink", _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵpureFunction0"](2, _c1));
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.items);
    }
  },
  directives: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterLinkWithHref, _angular_common__WEBPACK_IMPORTED_MODULE_4__.NgIf, _angular_common__WEBPACK_IMPORTED_MODULE_4__.NgForOf],
  encapsulation: 2
});

/***/ }),

/***/ 2489:
/*!************************************************!*\
  !*** ./src/app/issues/issue-list.component.ts ***!
  \************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "IssueListComponent": () => (/* binding */ IssueListComponent)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 6942);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _src_service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../src/service/service */ 6323);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common */ 6362);







function IssueListComponent_div_2_tr_15_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵgetCurrentView"]();

    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "tr", 5);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵlistener"]("click", function IssueListComponent_div_2_tr_15_Template_tr_click_0_listener() {
      const restoredCtx = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵrestoreView"](_r4);
      const item_r2 = restoredCtx.$implicit;
      const ctx_r3 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
      return ctx_r3.select(item_r2);
    });
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](1, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](3, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](5, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](6);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](7, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](8);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](9, "td");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](10);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()();
  }

  if (rf & 2) {
    const item_r2 = ctx.$implicit;
    const ctx_r1 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵclassProp"]("table-primary", item_r2 == ctx_r1.selectedItem);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.title);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.description);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.issueType);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.assignedTo);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtextInterpolate"](item_r2.createTime);
  }
}

function IssueListComponent_div_2_Template(rf, ctx) {
  if (rf & 1) {
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "div", 1)(1, "table", 2)(2, "thead")(3, "tr")(4, "th", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](5, "Title");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](6, "th", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](7, "Description");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](8, "th", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](9, "IssueType");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](10, "th", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](11, "Assigned To");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](12, "th", 3);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](13, "Creation Time");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](14, "tbody");
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](15, IssueListComponent_div_2_tr_15_Template, 11, 7, "tr", 4);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]()()();
  }

  if (rf & 2) {
    const ctx_r0 = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵnextContext"]();
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](15);
    _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngForOf", ctx_r0.items);
  }
}

class IssueListComponent {
  constructor(service, currentRoute) {
    this.service = service;
    this.currentRoute = currentRoute;
    this.items = [];
    currentRoute.data.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.map)(p => p['project'])).subscribe(p => this.loadData(p));
  }

  select(item) {
    this.selectedItem = item;
  }

  loadData(project) {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      if (project.id) {
        let data = yield _this.service.getIssues(project.id).toPromise();

        if (data) {
          _this.items = data;
        }
      }
    })();
  }

}

IssueListComponent.ɵfac = function IssueListComponent_Factory(t) {
  return new (t || IssueListComponent)(_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_src_service_service__WEBPACK_IMPORTED_MODULE_1__.IssueServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdirectiveInject"](_angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute));
};

IssueListComponent.ɵcmp = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineComponent"]({
  type: IssueListComponent,
  selectors: [["issue-list"]],
  decls: 3,
  vars: 1,
  consts: [["class", "table-responsive", 4, "ngIf"], [1, "table-responsive"], [1, "table", "table-striped", "table-hover"], ["scope", "col"], [3, "table-primary", "click", 4, "ngFor", "ngForOf"], [3, "click"]],
  template: function IssueListComponent_Template(rf, ctx) {
    if (rf & 1) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementStart"](0, "h1");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtext"](1, "Issues List");
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵelementEnd"]();
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵtemplate"](2, IssueListComponent_div_2_Template, 16, 1, "div", 0);
    }

    if (rf & 2) {
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵadvance"](2);
      _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵproperty"]("ngIf", ctx.items);
    }
  },
  directives: [_angular_common__WEBPACK_IMPORTED_MODULE_5__.NgIf, _angular_common__WEBPACK_IMPORTED_MODULE_5__.NgForOf],
  encapsulation: 2
});

/***/ }),

/***/ 7987:
/*!****************************************!*\
  !*** ./src/app/project-id.resolver.ts ***!
  \****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ProjectIdResolver": () => (/* binding */ ProjectIdResolver)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _src_service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../src/service/service */ 6323);
/* harmony import */ var _project_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./project.service */ 6176);




class ProjectIdResolver {
  constructor(service, projectService) {
    this.service = service;
    this.projectService = projectService;
  }

  resolve(route, state) {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      let projectName = route.params['project'];
      var project = yield _this.service.getProjectByName(projectName).toPromise();

      if (_this.projectService.current && _this.projectService.current.id != project.id) {
        _this.projectService.current = project;
      }

      return project;
    })();
  }

}

ProjectIdResolver.ɵfac = function ProjectIdResolver_Factory(t) {
  return new (t || ProjectIdResolver)(_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵinject"](_src_service_service__WEBPACK_IMPORTED_MODULE_1__.ProjectServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵinject"](_project_service__WEBPACK_IMPORTED_MODULE_2__.ProjectService));
};

ProjectIdResolver.ɵprov = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineInjectable"]({
  token: ProjectIdResolver,
  factory: ProjectIdResolver.ɵfac
});

/***/ }),

/***/ 6176:
/*!************************************!*\
  !*** ./src/app/project.service.ts ***!
  \************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ProjectService": () => (/* binding */ ProjectService)
/* harmony export */ });
/* harmony import */ var C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/esm/asyncToGenerator.js */ 1670);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ 9151);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _src_service_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../src/service/service */ 6323);






class ProjectService {
  constructor(service, route, router) {
    this.service = service;
    this.route = route;
    this.router = router;
    this.projects = [];
    router.events.pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.filter)(e => e instanceof _angular_router__WEBPACK_IMPORTED_MODULE_3__.NavigationEnd)).subscribe(p => console.log('title', p.url));
  }

  get current() {
    return this._current;
  }

  set current(value) {
    this._current = value;

    if (value === null || value === void 0 ? void 0 : value.displayString) {
      var url = this.getNavUrl(value.displayString);
      this.router.navigateByUrl('/' + url);
    }
  }

  initialize() {
    var _this = this;

    return (0,C_Projects_ghschwarzr_Samples_Azure_Xamarin_Offline_ConstructionDiary_Web_node_modules_babel_runtime_helpers_esm_asyncToGenerator_js__WEBPACK_IMPORTED_MODULE_0__["default"])(function* () {
      _this.projects = yield _this.service.getProjects().toPromise();
      _this.current = _this.projects[0];
    })();
  }

  getNavUrl(newProject) {
    let root = this.router.routerState.snapshot.root;

    while (root.firstChild) {
      root = root.firstChild;
    }

    let items = root.pathFromRoot;
    return items.map(p => p.routeConfig && p.routeConfig.path == ':project' ? newProject : p.url.join('/')).filter(p => p).join('/');
  }

}

ProjectService.ɵfac = function ProjectService_Factory(t) {
  return new (t || ProjectService)(_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_src_service_service__WEBPACK_IMPORTED_MODULE_1__.ProjectServiceClient), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.ActivatedRoute), _angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵinject"](_angular_router__WEBPACK_IMPORTED_MODULE_3__.Router));
};

ProjectService.ɵprov = /*@__PURE__*/_angular_core__WEBPACK_IMPORTED_MODULE_4__["ɵɵdefineInjectable"]({
  token: ProjectService,
  factory: ProjectService.ɵfac
});

/***/ }),

/***/ 2340:
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "environment": () => (/* binding */ environment)
/* harmony export */ });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
const environment = {
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

/***/ 4431:
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/platform-browser */ 318);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app/app.module */ 6747);
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./environments/environment */ 2340);




if (_environments_environment__WEBPACK_IMPORTED_MODULE_1__.environment.production) {
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.enableProdMode)();
}
_angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__.platformBrowser().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_0__.AppModule)
    .catch(err => console.error(err));


/***/ }),

/***/ 6323:
/*!********************************!*\
  !*** ./src/service/service.ts ***!
  \********************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "API_BASE_URL": () => (/* binding */ API_BASE_URL),
/* harmony export */   "OfflineServiceClient": () => (/* binding */ OfflineServiceClient),
/* harmony export */   "AreaServiceClient": () => (/* binding */ AreaServiceClient),
/* harmony export */   "CountryServiceClient": () => (/* binding */ CountryServiceClient),
/* harmony export */   "EmployeeServiceClient": () => (/* binding */ EmployeeServiceClient),
/* harmony export */   "IssueServiceClient": () => (/* binding */ IssueServiceClient),
/* harmony export */   "ProjectServiceClient": () => (/* binding */ ProjectServiceClient),
/* harmony export */   "AreaInfo": () => (/* binding */ AreaInfo),
/* harmony export */   "CountryListItem": () => (/* binding */ CountryListItem),
/* harmony export */   "CountryInfo": () => (/* binding */ CountryInfo),
/* harmony export */   "EmployeeInfo": () => (/* binding */ EmployeeInfo),
/* harmony export */   "EmployeeListItem": () => (/* binding */ EmployeeListItem),
/* harmony export */   "IssueCreateData": () => (/* binding */ IssueCreateData),
/* harmony export */   "IssueTypeInfo": () => (/* binding */ IssueTypeInfo),
/* harmony export */   "IssueListItem": () => (/* binding */ IssueListItem),
/* harmony export */   "IssueTypeListItem": () => (/* binding */ IssueTypeListItem),
/* harmony export */   "ProjectInfo": () => (/* binding */ ProjectInfo),
/* harmony export */   "ApiException": () => (/* binding */ ApiException)
/* harmony export */ });
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ 522);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ 7418);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs */ 6587);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs */ 4139);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs */ 2378);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 8784);
/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming
// @ts-nocheck






const API_BASE_URL = new _angular_core__WEBPACK_IMPORTED_MODULE_0__.InjectionToken('API_BASE_URL');
class OfflineServiceClient {
    constructor(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "http://localhost:5001";
    }
    getOfflineDB(projectId) {
        let url_ = this.baseUrl + "/api/offline/db/{projectId}";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetOfflineDB(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetOfflineDB(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetOfflineDB(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : null;
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
}
OfflineServiceClient.ɵfac = function OfflineServiceClient_Factory(t) { return new (t || OfflineServiceClient)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](API_BASE_URL, 8)); };
OfflineServiceClient.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: OfflineServiceClient, factory: OfflineServiceClient.ɵfac });
class AreaServiceClient {
    constructor(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "http://localhost:5001";
    }
    getAreaInfos(projectId) {
        let url_ = this.baseUrl + "/api/area/{projectId}/infos";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetAreaInfos(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetAreaInfos(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetAreaInfos(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(AreaInfo.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
}
AreaServiceClient.ɵfac = function AreaServiceClient_Factory(t) { return new (t || AreaServiceClient)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](API_BASE_URL, 8)); };
AreaServiceClient.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: AreaServiceClient, factory: AreaServiceClient.ɵfac });
class CountryServiceClient {
    constructor(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "http://localhost:5001";
    }
    deleteCountry(id) {
        let url_ = this.baseUrl + "/api/country/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({})
        };
        return this.http.request("delete", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processDeleteCountry(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processDeleteCountry(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processDeleteCountry(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getCountry(id) {
        let url_ = this.baseUrl + "/api/country/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetCountry(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetCountry(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetCountry(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = CountryListItem.fromJS(resultData200);
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getCountryInfos() {
        let url_ = this.baseUrl + "/api/country/infos";
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetCountryInfos(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetCountryInfos(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetCountryInfos(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(CountryInfo.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getCountryListItems() {
        let url_ = this.baseUrl + "/api/country/list";
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetCountryListItems(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetCountryListItems(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetCountryListItems(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(CountryListItem.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    insertCountry(item) {
        let url_ = this.baseUrl + "/api/country";
        url_ = url_.replace(/[?&]$/, "");
        const content_ = JSON.stringify(item);
        let options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("post", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processInsertCountry(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processInsertCountry(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processInsertCountry(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    updateCountry(item) {
        let url_ = this.baseUrl + "/api/country";
        url_ = url_.replace(/[?&]$/, "");
        const content_ = JSON.stringify(item);
        let options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("put", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processUpdateCountry(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processUpdateCountry(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processUpdateCountry(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
}
CountryServiceClient.ɵfac = function CountryServiceClient_Factory(t) { return new (t || CountryServiceClient)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](API_BASE_URL, 8)); };
CountryServiceClient.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: CountryServiceClient, factory: CountryServiceClient.ɵfac });
class EmployeeServiceClient {
    constructor(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "http://localhost:5001";
    }
    delete(id) {
        let url_ = this.baseUrl + "/api/employee/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({})
        };
        return this.http.request("delete", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processDelete(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processDelete(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processDelete(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getEmployeeListItem(id) {
        let url_ = this.baseUrl + "/api/employee/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetEmployeeListItem(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetEmployeeListItem(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetEmployeeListItem(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = EmployeeListItem.fromJS(resultData200);
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getEmployeeInfos(projectId) {
        let url_ = this.baseUrl + "/api/employee/{projectId}/all";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetEmployeeInfos(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetEmployeeInfos(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetEmployeeInfos(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(EmployeeInfo.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getEmployeeListItems(projectId) {
        let url_ = this.baseUrl + "/api/employee/{projectId}/list";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetEmployeeListItems(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetEmployeeListItems(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetEmployeeListItems(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(EmployeeListItem.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    insert(projectId, item) {
        let url_ = this.baseUrl + "/api/employee/{projectId}";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        const content_ = JSON.stringify(item);
        let options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("post", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processInsert(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processInsert(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processInsert(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    update(item) {
        let url_ = this.baseUrl + "/api/employee";
        url_ = url_.replace(/[?&]$/, "");
        const content_ = JSON.stringify(item);
        let options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("put", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processUpdate(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processUpdate(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processUpdate(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
}
EmployeeServiceClient.ɵfac = function EmployeeServiceClient_Factory(t) { return new (t || EmployeeServiceClient)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](API_BASE_URL, 8)); };
EmployeeServiceClient.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: EmployeeServiceClient, factory: EmployeeServiceClient.ɵfac });
class IssueServiceClient {
    constructor(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "http://localhost:5001";
    }
    createIssue(areaId, assignedToId, attachments, creationTime, descripton, issueTypeId, title) {
        let url_ = this.baseUrl + "/api/issue?";
        if (areaId === null)
            throw new Error("The parameter 'areaId' cannot be null.");
        else if (areaId !== undefined)
            url_ += "AreaId=" + encodeURIComponent("" + areaId) + "&";
        if (assignedToId !== undefined && assignedToId !== null)
            url_ += "AssignedToId=" + encodeURIComponent("" + assignedToId) + "&";
        if (attachments !== undefined && attachments !== null)
            attachments && attachments.forEach(item => { url_ += "Attachments=" + encodeURIComponent("" + item) + "&"; });
        if (creationTime === null)
            throw new Error("The parameter 'creationTime' cannot be null.");
        else if (creationTime !== undefined)
            url_ += "CreationTime=" + encodeURIComponent(creationTime ? "" + creationTime.toJSON() : "") + "&";
        if (descripton !== undefined && descripton !== null)
            url_ += "Descripton=" + encodeURIComponent("" + descripton) + "&";
        if (issueTypeId === null)
            throw new Error("The parameter 'issueTypeId' cannot be null.");
        else if (issueTypeId !== undefined)
            url_ += "IssueTypeId=" + encodeURIComponent("" + issueTypeId) + "&";
        if (title !== undefined && title !== null)
            url_ += "Title=" + encodeURIComponent("" + title) + "&";
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({})
        };
        return this.http.request("post", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processCreateIssue(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processCreateIssue(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processCreateIssue(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    deleteIssueType(id) {
        let url_ = this.baseUrl + "/api/issue/type/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({})
        };
        return this.http.request("delete", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processDeleteIssueType(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processDeleteIssueType(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processDeleteIssueType(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getIssueCreate(projectId) {
        let url_ = this.baseUrl + "/api/issue/{projectId}/create";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetIssueCreate(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetIssueCreate(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetIssueCreate(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = IssueCreateData.fromJS(resultData200);
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getIssues(projectId) {
        let url_ = this.baseUrl + "/api/issue/{projectId}/list";
        if (projectId === undefined || projectId === null)
            throw new Error("The parameter 'projectId' must be defined.");
        url_ = url_.replace("{projectId}", encodeURIComponent("" + projectId));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetIssues(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetIssues(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetIssues(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(IssueListItem.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getIssueType(id) {
        let url_ = this.baseUrl + "/api/issue/types/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetIssueType(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetIssueType(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetIssueType(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = IssueTypeListItem.fromJS(resultData200);
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getIssueTypeListItems() {
        let url_ = this.baseUrl + "/api/issue/types/list";
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetIssueTypeListItems(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetIssueTypeListItems(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetIssueTypeListItems(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(IssueTypeListItem.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getIssueTypes() {
        let url_ = this.baseUrl + "/api/issue/types";
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetIssueTypes(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetIssueTypes(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetIssueTypes(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(IssueTypeInfo.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    insertIssueType(issue) {
        let url_ = this.baseUrl + "/api/issue/type";
        url_ = url_.replace(/[?&]$/, "");
        const content_ = JSON.stringify(issue);
        let options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("post", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processInsertIssueType(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processInsertIssueType(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processInsertIssueType(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    updateIssueType(issue) {
        let url_ = this.baseUrl + "/api/issue/type";
        url_ = url_.replace(/[?&]$/, "");
        const content_ = JSON.stringify(issue);
        let options_ = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("put", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processUpdateIssueType(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processUpdateIssueType(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processUpdateIssueType(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
}
IssueServiceClient.ɵfac = function IssueServiceClient_Factory(t) { return new (t || IssueServiceClient)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](API_BASE_URL, 8)); };
IssueServiceClient.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: IssueServiceClient, factory: IssueServiceClient.ɵfac });
class ProjectServiceClient {
    constructor(http, baseUrl) {
        this.jsonParseReviver = undefined;
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "http://localhost:5001";
    }
    getProjectByName(name) {
        let url_ = this.baseUrl + "/api/project/search/{name}";
        if (name === undefined || name === null)
            throw new Error("The parameter 'name' must be defined.");
        url_ = url_.replace("{name}", encodeURIComponent("" + name));
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetProjectByName(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetProjectByName(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetProjectByName(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = ProjectInfo.fromJS(resultData200);
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
    getProjects() {
        let url_ = this.baseUrl + "/api/project/all";
        url_ = url_.replace(/[?&]$/, "");
        let options_ = {
            observe: "response",
            responseType: "blob",
            headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({
                "Accept": "application/json"
            })
        };
        return this.http.request("get", url_, options_).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)((response_) => {
            return this.processGetProjects(response_);
        })).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_3__.catchError)((response_) => {
            if (response_ instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponseBase) {
                try {
                    return this.processGetProjects(response_);
                }
                catch (e) {
                    return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(e);
                }
            }
            else
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(response_);
        }));
    }
    processGetProjects(response) {
        const status = response.status;
        const responseBlob = response instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpResponse ? response.body :
            response.error instanceof Blob ? response.error : undefined;
        let _headers = {};
        if (response.headers) {
            for (let key of response.headers.keys()) {
                _headers[key] = response.headers.get(key);
            }
        }
        if (status === 200) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                let result200 = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [];
                    for (let item of resultData200)
                        result200.push(ProjectInfo.fromJS(item));
                }
                else {
                    result200 = null;
                }
                return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(result200);
            }));
        }
        else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_2__.mergeMap)(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_5__.of)(null);
    }
}
ProjectServiceClient.ɵfac = function ProjectServiceClient_Factory(t) { return new (t || ProjectServiceClient)(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](_angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵinject"](API_BASE_URL, 8)); };
ProjectServiceClient.ɵprov = /*@__PURE__*/ _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineInjectable"]({ token: ProjectServiceClient, factory: ProjectServiceClient.ɵfac });
class AreaInfo {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.areaName = _data["areaName"];
            this.id = _data["id"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new AreaInfo();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["areaName"] = this.areaName;
        data["id"] = this.id;
        return data;
    }
}
class CountryListItem {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.id = _data["id"];
            this.isoTwo = _data["isoTwo"];
            this.name = _data["name"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new CountryListItem();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["isoTwo"] = this.isoTwo;
        data["name"] = this.name;
        return data;
    }
}
class CountryInfo {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.displayString = _data["displayString"];
            this.id = _data["id"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new CountryInfo();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["displayString"] = this.displayString;
        data["id"] = this.id;
        return data;
    }
}
class EmployeeInfo {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.displayName = _data["displayName"];
            this.id = _data["id"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new EmployeeInfo();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["displayName"] = this.displayName;
        data["id"] = this.id;
        return data;
    }
}
class EmployeeListItem {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.created = _data["created"] ? new Date(_data["created"].toString()) : undefined;
            this.firstName = _data["firstName"];
            this.id = _data["id"];
            this.isDisabled = _data["isDisabled"];
            this.lastName = _data["lastName"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new EmployeeListItem();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["created"] = this.created ? this.created.toISOString() : undefined;
        data["firstName"] = this.firstName;
        data["id"] = this.id;
        data["isDisabled"] = this.isDisabled;
        data["lastName"] = this.lastName;
        return data;
    }
}
class IssueCreateData {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            if (Array.isArray(_data["employees"])) {
                this.employees = [];
                for (let item of _data["employees"])
                    this.employees.push(EmployeeInfo.fromJS(item));
            }
            if (Array.isArray(_data["issueTypes"])) {
                this.issueTypes = [];
                for (let item of _data["issueTypes"])
                    this.issueTypes.push(IssueTypeInfo.fromJS(item));
            }
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new IssueCreateData();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.employees)) {
            data["employees"] = [];
            for (let item of this.employees)
                data["employees"].push(item.toJSON());
        }
        if (Array.isArray(this.issueTypes)) {
            data["issueTypes"] = [];
            for (let item of this.issueTypes)
                data["issueTypes"].push(item.toJSON());
        }
        return data;
    }
}
class IssueTypeInfo {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.displayString = _data["displayString"];
            this.id = _data["id"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new IssueTypeInfo();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["displayString"] = this.displayString;
        data["id"] = this.id;
        return data;
    }
}
class IssueListItem {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.assignedTo = _data["assignedTo"];
            this.createTime = _data["createTime"] ? new Date(_data["createTime"].toString()) : undefined;
            this.description = _data["description"];
            this.id = _data["id"];
            this.issueType = _data["issueType"];
            this.title = _data["title"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new IssueListItem();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["assignedTo"] = this.assignedTo;
        data["createTime"] = this.createTime ? this.createTime.toISOString() : undefined;
        data["description"] = this.description;
        data["id"] = this.id;
        data["issueType"] = this.issueType;
        data["title"] = this.title;
        return data;
    }
}
class IssueTypeListItem {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.description = _data["description"];
            this.id = _data["id"];
            this.title = _data["title"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new IssueTypeListItem();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["description"] = this.description;
        data["id"] = this.id;
        data["title"] = this.title;
        return data;
    }
}
class ProjectInfo {
    constructor(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    init(_data) {
        if (_data) {
            this.displayString = _data["displayString"];
            this.id = _data["id"];
        }
    }
    static fromJS(data) {
        data = typeof data === 'object' ? data : {};
        let result = new ProjectInfo();
        result.init(data);
        return result;
    }
    toJSON(data) {
        data = typeof data === 'object' ? data : {};
        data["displayString"] = this.displayString;
        data["id"] = this.id;
        return data;
    }
}
class ApiException extends Error {
    constructor(message, status, response, headers, result) {
        super();
        this.isApiException = true;
        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }
    static isApiException(obj) {
        return obj.isApiException === true;
    }
}
function throwException(message, status, response, headers, result) {
    if (result !== null && result !== undefined)
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(result);
    else
        return (0,rxjs__WEBPACK_IMPORTED_MODULE_4__.throwError)(new ApiException(message, status, response, headers, null));
}
function blobToText(blob) {
    return new rxjs__WEBPACK_IMPORTED_MODULE_6__.Observable((observer) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        }
        else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next(event.target.result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}


/***/ })

},
/******/ __webpack_require__ => { // webpackRuntimeModules
/******/ var __webpack_exec__ = (moduleId) => (__webpack_require__(__webpack_require__.s = moduleId))
/******/ __webpack_require__.O(0, ["vendor"], () => (__webpack_exec__(4431)));
/******/ var __webpack_exports__ = __webpack_require__.O();
/******/ }
]);
//# sourceMappingURL=main.js.map