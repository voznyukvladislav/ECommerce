import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  getProduct(productId: number) {
    return this.http.get(`${Constants.api}/${Constants.product}/${Constants.getProduct}?productId=${productId}`);
  }

  getProductRating(productId: number) {
    return this.http.get(`${Constants.api}/${Constants.product}/${Constants.getProductRating}?productId=${productId}`);
  }
}
