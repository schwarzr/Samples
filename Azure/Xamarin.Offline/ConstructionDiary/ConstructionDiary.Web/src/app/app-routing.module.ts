import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dasbhoard.component';

const routes: Routes = [{
  path: 'dashboard',
  component: DashboardComponent
},
{
  path: 'countries',
  children: [
    {
      path:'',
      component: DashboardComponent
    },
    {
      path:':id',
      component: DashboardComponent
    }
  ]
},
{
  path: 'issuetypes',
  children: [
    {
      path:'',
      component: DashboardComponent
    },
    {
      path:':id',
      component: DashboardComponent
    }
  ]
},
{
  path: ':project',
  children: [
    {
      path:'issues',
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
      path:'employees',
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
