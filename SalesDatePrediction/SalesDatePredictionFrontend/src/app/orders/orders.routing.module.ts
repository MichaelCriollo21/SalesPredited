import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateOrderComponent } from './pages/create-order/create-order.component';
import { ViewOrdersComponent } from './pages/view-orders/view-orders.component';

const routes: Routes = [
  {
    path: 'createOrder',
    component: CreateOrderComponent
  },
  {
    path: 'viewOrders',
    component: ViewOrdersComponent
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
