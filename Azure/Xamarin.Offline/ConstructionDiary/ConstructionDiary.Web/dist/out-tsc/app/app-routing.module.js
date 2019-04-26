import * as tslib_1 from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dasbhoard.component';
var routes = [{
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: 'countries',
        children: [
            {
                path: '',
                component: DashboardComponent
            },
            {
                path: ':id',
                component: DashboardComponent
            }
        ]
    },
    {
        path: 'issuetypes',
        children: [
            {
                path: '',
                component: DashboardComponent
            },
            {
                path: ':id',
                component: DashboardComponent
            }
        ]
    },
    {
        path: ':project',
        children: [
            {
                path: 'issues',
                children: [
                    {
                        path: '',
                        component: DashboardComponent
                    },
                    {
                        path: ':id',
                        component: DashboardComponent
                    }
                ]
            },
            {
                path: 'employees',
                children: [
                    {
                        path: '',
                        component: DashboardComponent
                    },
                    {
                        path: ':id',
                        component: DashboardComponent
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
    AppRoutingModule = tslib_1.__decorate([
        NgModule({
            imports: [RouterModule.forRoot(routes)],
            exports: [RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map