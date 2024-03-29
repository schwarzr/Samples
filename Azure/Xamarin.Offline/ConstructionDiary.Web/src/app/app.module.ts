import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PaginationModule } from 'ngx-bootstrap/pagination'
import { AccordionModule } from 'ngx-bootstrap/accordion'
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { DashboardComponent } from './dashboard/dasbhoard.component';
import { CountriesListComponent } from './countries/countries-list.component';
import { CountryServiceClient, ProjectServiceClient, IssueServiceClient, IssueTypeListItem, EmployeeServiceClient } from '../service/service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CountryEditComponent } from './countries/country-edit.component';
import { CountryCreateComponent } from './countries/country-create.component';
import { ProjectService } from './project.service';
import { ProjectIdResolver } from './project-id.resolver';
import { IssueListComponent } from './issues/issue-list.component';
import { IssueTypeCreateComponent } from './issue-types/issue-type-create.component';
import { IssueTypeEditComponent } from './issue-types/issue-type-edit.component';
import { IssueTypesListComponent } from './issue-types/issue-types-list.component';
import { EmployeeCreateComponent } from './employees/employee-create.component';
import { EmployeeEditComponent } from './employees/employee-edit.component';
import { EmployeesListComponent } from './employees/employees-list.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    CountriesListComponent,
    CountryEditComponent,
    CountryCreateComponent,
    IssueListComponent,
    IssueTypeCreateComponent,
    IssueTypeEditComponent,
    IssueTypesListComponent,
    EmployeeCreateComponent,
    EmployeeEditComponent,
    EmployeesListComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    AccordionModule.forRoot(),
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    TabsModule.forRoot(),
    CollapseModule.forRoot()
  ],
  providers: [
    CountryServiceClient,
    ProjectServiceClient,
    IssueServiceClient,
    EmployeeServiceClient,
    ProjectService,
    ProjectIdResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
