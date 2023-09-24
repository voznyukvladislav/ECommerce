import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { Review } from 'src/app/data/product/review';

@Injectable({
  providedIn: 'root'
})
export class DbDataService {

  constructor(private http: HttpClient) { }

  getSubCategoryParent(subCategoryId: number) {
    return this.http.get(`${Constants.api}/${Constants.data}/${Constants.getSubCategoryParent}?subCategoryId=${subCategoryId}`)
  }

  getSubCategory(subCategoryId: number) {
    return this.http.get(`${Constants.api}/${Constants.data}/${Constants.getSubCategory}?subCategoryId=${subCategoryId}`)
  }

  getProduct(productId: number) {
    return this.http.get(`${Constants.api}/${Constants.data}/${Constants.getProduct}?productId=${productId}`);
  }

  getReviews(productId: number, count: number, page: number) {
    return this.http.get(`${Constants.api}/${Constants.data}/${Constants.getReviews}?productId=${productId}&count=${count}&page=${page}`);
  }

  addReview(review: Review, productId: number) {
    return this.http.post(`${Constants.api}/${Constants.data}/${Constants.addReview}?productId=${productId}`, review, { withCredentials: true });
  }

  getShoppingCart() {
    return this.http.get(`${Constants.api}/${Constants.data}/${Constants.getShoppingCart}`, { withCredentials: true })
  }
}
