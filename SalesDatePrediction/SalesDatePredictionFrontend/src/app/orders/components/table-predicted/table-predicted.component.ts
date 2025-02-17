import { Component, Input } from '@angular/core';
import { PredictedOrder } from '../../interfaces/predictedOrder';

@Component({
  selector: 'orders-table-predicted',
  standalone: false,
  templateUrl: './table-predicted.component.html',
})

export class TablePredictedComponent {

  @Input() 
  public predictedOrders: PredictedOrder[] = [];

}
