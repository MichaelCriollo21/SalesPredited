import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateOrderComponent } from './pages/create-order/create-order.component';
import { ViewOrdersComponent } from './pages/view-orders/view-orders.component';
import { OrdersRoutingModule } from './orders.routing.module';
import { SharedModule } from '../shared/shared.module';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { TablePredictedComponent } from './components/table-predicted/table-predicted.component';


@NgModule({
  declarations: [
    CreateOrderComponent,
    ViewOrdersComponent,
    HomePageComponent,
    TablePredictedComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    SharedModule,
  ],
  exports:[]
})
export class OrdersModule { }
