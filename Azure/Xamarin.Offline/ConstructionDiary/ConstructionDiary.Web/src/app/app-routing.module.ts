import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dasbhoard.component';
import { CountriesListComponent } from './countries/countries-list.component';
import { CountryEditComponent } from './countries/country-edit.component';
import { CountryCreateComponent } from './countries/country-create.component';

const routes: Routes = [{
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

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
