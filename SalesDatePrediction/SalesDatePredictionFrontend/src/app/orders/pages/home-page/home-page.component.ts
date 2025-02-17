import { Component, Output } from '@angular/core';
import { PredictedOrderService } from '../../services/predictedOrder.service';
import { PredictedOrder } from '../../interfaces/predictedOrder';

@Component({
  selector: 'order-home-page',
  standalone: false,
  templateUrl: './home-page.component.html',
})
export class HomePageComponent {
  
  public predictedOrders: PredictedOrder[] = [];

  constructor(private predictedOrderService: PredictedOrderService){}

  ngOnInit(): void {
    this.predictedOrderService.PredictedOrders().subscribe(
      response => {
        this.predictedOrders = response;
      }
    )
  }
  
  GetNextPredictedOrders(value: string):void {
  }

}
