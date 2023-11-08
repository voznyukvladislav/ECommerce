import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductFull } from 'src/app/data/product/productFull';
import { Review } from 'src/app/data/product/review';
import { DbDataService } from 'src/app/services/db-data-service/db-data.service';
import { ProductService } from 'src/app/services/product-service/product.service';
import { RatingService } from 'src/app/services/rating-service/rating.service';
import { ReviewService } from 'src/app/services/review-service/review.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {

  @Input() reviews: Review[] = [];
  @Input() productFull: ProductFull = new ProductFull();

  @Output() loadReviews = new EventEmitter<void>();
  @Output() reviewsExist = new EventEmitter<void>();

  storage: Storage = localStorage;

  review: Review = new Review();

  rating: number = 1;
  starsCounter: number[] = [1, 2, 3, 4, 5];
  starIsHovered: boolean[] = [true, false, false, false, false];

  constructor(
    private productService: ProductService,
    private reviewService: ReviewService,
    private ratingService: RatingService) { }

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

    if (this.review.text) {
      this.reviewService.addReview(this.review, this.productFull.id).subscribe({
        next: (newReview: any) => {
          this.reviews.unshift(newReview);
          this.productFull.reviewsCount++;
  
          this.review = new Review();
          this.rating = 1;
          this.unhoverStars(this.starsCounter.length);
  
          if(this.reviews.length > 5) {
            for(let i = this.reviews.length - 1; i > 4; i--) {
              this.reviews.pop();
            }
          }
  
          this.reviewsExist.emit();  
  
          this.productService.getProductRating(this.productFull.id).subscribe({
            next: (rating: any) => {
              this.productFull.rating = rating;
              this.ratingService.updateRating(this.productFull.rating);
            }
          })
        }
      });
    }
  }
}
