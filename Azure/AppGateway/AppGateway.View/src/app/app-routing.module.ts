import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { HelloComponent } from './hello.component';

const routes: Routes = [{
  path:"",
  canActivate: [AuthGuard],
  children: [{
      path: "",
      component: HelloComponent
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
