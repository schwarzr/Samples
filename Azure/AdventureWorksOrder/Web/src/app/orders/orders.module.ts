import { RouterModule } from '@angular/router';
import { OrderDetailComponent } from './order-detail.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { DxButtonModule, DxDataGridModule, DxSelectBoxModule } from 'devextreme-angular';
import { OrderListComponent } from './order-list.component';
import { NgModule } from "@angular/core";

@NgModule({
    imports:
    [
        BrowserModule,
        FormsModule,
        DxDataGridModule,
        DxSelectBoxModule,
        RouterModule
    ],
    declarations: [
        OrderListComponent,
        OrderDetailComponent
    ]
})
export class OrdersModule {

}