import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { ShoppingCart_Product } from 'src/app/data/shoppingCart_product';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  addOrder(shoppingCartProducts: ShoppingCart_Product[]) {
    return this.http.post(`${Constants.api}/${Constants.order}/${Constants.addOrder}`, shoppingCartProducts, { withCredentials: true });
  }

  getOrders() {
    return this.http.get(`${Constants.api}/${Constants.order}/${Constants.getOrders}`, { withCredentials: true });
  }

  getOrderDetails(orderId: string) {
    return this.http.get(`${Constants.api}/${Constants.order}/${Constants.getOrderDetails}?orderId=${orderId}`, { withCredentials: true });
  }
}
