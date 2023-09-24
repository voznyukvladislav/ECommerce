import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  
  constructor(private http: HttpClient) { }

  getShoppingCart() {
    return this.http.get(`${Constants.api}/${Constants.shoppingCart}/${Constants.getShoppingCart}`, { withCredentials: true });
  }

  addShoppingCartProduct(productId: number) {
    return this.http.post(`${Constants.api}/${Constants.shoppingCart}/${Constants.addShoppingCartProduct}?productId=${productId}`, { }, { withCredentials: true });
  }

  removeShoppingCartProduct(productId: number) {
    return this.http.delete(`${Constants.api}/${Constants.shoppingCart}/${Constants.removeShoppingCartProduct}?productId=${productId}`, { withCredentials: true });
  }

  updateShoppingCartProductCount(productId: number, count: number) {
    return this.http.patch(`${Constants.api}/${Constants.shoppingCart}/${Constants.updateShoppingCartProductCount}?productId=${productId}&count=${count}`, { }, { withCredentials: true });
  }
}
