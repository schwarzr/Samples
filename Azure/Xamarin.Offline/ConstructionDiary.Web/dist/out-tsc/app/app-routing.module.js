import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dasbhoard.component';
import { CountriesListComponent } from './countries/countries-list.component';
import { CountryEditComponent } from './countries/country-edit.component';
import { CountryCreateComponent } from './countries/country-create.component';
import { ProjectIdResolver } from './project-id.resolver';
import { IssueListComponent } from './issues/issue-list.component';
import { IssueTypesListComponent } from './issue-types/issue-types-list.component';
import { IssueTypeEditComponent } from './issue-types/issue-type-edit.component';
import { IssueTypeCreateComponent } from './issue-types/issue-type-create.component';
import { EmployeesListComponent } from './employees/employees-list.component';
import { EmployeeEditComponent } from './employees/employee-edit.component';
import { EmployeeCreateComponent } from './employees/employee-create.component';
var routes = [{
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: 'countries',
        children: [
            {
                path: '',
                component: CountriesListComponent
            },
            {
                path: 'new',
                component: CountryCreateComponent
            },
            {
                path: ':id',
                component: CountryEditComponent
            },
        ]
    },
    {
        path: 'issuetypes',
        children: [
            {
                path: '',
                component: IssueTypesListComponent
            },
            {
                path: 'new',
                component: IssueTypeCreateComponent
            },
            {
                path: ':id',
                component: IssueTypeEditComponent
            }
        ]
    },
    {
        path: ':project',
        resolve: {
            project: ProjectIdResolver
        },
        children: [
            {
                path: 'issues',
                children: [
                    {
                        path: '',
                        component: IssueListComponent
                    }
                ]
            },
            {
                path: 'employees',
                children: [
                    {
                        path: '',
                        component: EmployeesListComponent
                    },
                    {
                        path: 'new',
                        component: EmployeeCreateComponent
                    },
                    {
                        path: ':id',
                        component: EmployeeEditComponent
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
    AppRoutingModule = __decorate([
        NgModule({
            imports: [RouterModule.forRoot(routes)],
            exports: [RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map