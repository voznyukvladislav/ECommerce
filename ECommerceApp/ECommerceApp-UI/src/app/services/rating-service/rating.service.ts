import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RatingService {

  rating: BehaviorSubject<number> = new BehaviorSubject<number>(0);

  getRating() {
    return this.rating;
  }

  updateRating(number: number) {
    this.rating.next(number);
  }

  constructor() { }
}
