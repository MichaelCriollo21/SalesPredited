import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environment/environment";
import { map, Observable } from "rxjs";

@Injectable({providedIn: 'root'})
export class PredictedOrderService {

    private basePath = `${environment.urlApi}api/PredictedOrder`;

    constructor(private http: HttpClient){
    }

    PredictedOrders(): Observable<any> {
        return this.http.get<any>(`${this.basePath}/PredictedOrders`)
          .pipe(map(response => {
            return response;
        }));
    }
}