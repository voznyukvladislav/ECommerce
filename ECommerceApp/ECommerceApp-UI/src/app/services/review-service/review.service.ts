import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { Review } from 'src/app/data/product/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http: HttpClient) { }

  getReviews(productId: number, count: number, page: number) {
    return this.http.get(`${Constants.api}/${Constants.review}/${Constants.getReviews}?productId=${productId}&count=${count}&page=${page}`);
  }

  addReview(review: Review, productId: number) {
    return this.http.post(`${Constants.api}/${Constants.review}/${Constants.addReview}?productId=${productId}`, review, {withCredentials: true});
  }
}
