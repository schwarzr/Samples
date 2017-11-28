import { OrderListComponent } from './orders/order-list.component';
import { RouterModule } from '@angular/router';
import { OrdersModule } from './orders/orders.module';
import { HttpClientModule } from '@angular/common/http';
import { API_URI } from '../service/api-uri';
import { RestOrderService } from '../service/rest-order-service';
import { OrderService } from '../service/order-service';
import { providerDef } from '@angular/compiler/src/view_compiler/provider_compiler';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { OrderDetailComponent } from "./orders/order-detail.component";


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    OrdersModule,
    RouterModule.forRoot([
      {
        path: 'orders',
        children: [{
          path: '',
          component: OrderListComponent,
        }, {
          path: ':id',
          component: OrderDetailComponent,
        }]
      }
    ])
  ],
  providers: [
    {
      provide: OrderService,
      useClass: RestOrderService
    },
    {
      provide: API_URI,
      useValue: "http://localhost:64145/api/orders/"
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
