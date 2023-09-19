import { Component, Input, OnInit } from '@angular/core';
import { Review } from 'src/app/data/product/review';
import { DbDataService } from 'src/app/services/db-data-service/db-data.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {

  @Input() reviews: Review[] = [];
  @Input() productId: number = 0;

  storage: Storage = localStorage;

  review: Review = new Review();

  rating: number = 1;
  starsCounter: number[] = [1, 2, 3, 4, 5];
  starIsHovered: boolean[] = [true, false, false, false, false];

  constructor(private dbDataService: DbDataService) { }

  ngOnInit(): void {
  }

  hoverStars(index: number) {
    for (let i = 0; i <= index; i++) {
      this.starIsHovered[i] = true;
    }
  }

  unhoverStars(index: number) {
    for (let i = 0; i <= index; i++) {
      this.starIsHovered[i] = false;
    }
    
    for (let i = 0; i < this.rating; i++) {
      this.starIsHovered[i] = true;
    }
  }

  selectRating(index: number) {
    this.rating = index + 1;
    this.unhoverStars(this.starsCounter.length);
  }

  addReview() {
    this.review.rating = this.rating;
    this.review.user.login = this.storage.getItem("userInfo.login")!;
    this.review.user.email = this.storage.getItem("userInfo.email")!;
    this.review.user.name = this.storage.getItem("userInfo.name")!;

    this.dbDataService.addReview(this.review, this.productId).subscribe({
      next: (newReview: any) => {
        this.reviews.unshift(newReview);

        this.review = new Review();
        this.rating = 1;
        this.unhoverStars(this.starsCounter.length);
      }
    });
  }
}
