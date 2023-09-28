import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductFull } from 'src/app/data/product/productFull';
import { DbDataService } from 'src/app/services/db-data-service/db-data.service';
import { ProductService } from 'src/app/services/product-service/product.service';
import { RatingService } from 'src/app/services/rating-service/rating.service';
import { ReviewService } from 'src/app/services/review-service/review.service';

@Component({
  selector: 'app-product-detail-page',
  templateUrl: './product-detail-page.component.html',
  styleUrls: ['./product-detail-page.component.css']
})
export class ProductDetailPageComponent implements OnInit {

  productId: number = 0;
  productFull: ProductFull | any;

  itemIsActive: boolean[] = [ true, false, false ];

  activeBlock: string = "About";

  reviewPageSize: number = 5;
  reviewCurrentPage: number = 1;
  reviewsExist: boolean = true;

  constructor(
    private dbDataService: DbDataService,
    private activatedRoute: ActivatedRoute,
    private productService: ProductService,
    private reviewService: ReviewService,
    private ratingService: RatingService) {
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe({
      next: (params: any) => {
        this.productId = params.id;

        this.productService.getProduct(this.productId).subscribe({
          next: (product: any) => {
            this.productFull = product;
            console.log(this.productFull);

            this.productService.getProductRating(this.productFull.id).subscribe({
              next: rating => {
                this.productFull.rating = rating;
                this.ratingService.updateRating(this.productFull.rating);
              }
            })

            if (this.reviewsExist) {
              this.reviewService.getReviews(this.productId, this.reviewPageSize, this.reviewCurrentPage).subscribe({
                next: (reviews: any) => {
                  if (reviews.length != 0) {
                    this.reviewCurrentPage++;
                  }
                  else {
                    this.reviewsExist = false;
                  }
                  this.productFull.reviews = this.productFull.reviews.concat(reviews);
                }
              });
            }
          }
        });
      }
    });
  }

  selectItem(index: number) {
    for (let i = 0; i < this.itemIsActive.length; i++) {
      this.itemIsActive[i] = false;
    }

    this.itemIsActive[index] = true;
    console.log(this.itemIsActive);
  }

  loadReviews() {
    if (this.reviewsExist) {
      this.reviewService.getReviews(this.productId, this.reviewPageSize, this.reviewCurrentPage).subscribe({
        next: (reviews: any) => {
          if (reviews.length != 0) {
            this.reviewCurrentPage++;
          }
          else {
            this.reviewsExist = false;
          }
          this.productFull.reviews = this.productFull.reviews.concat(reviews);
        }
      });
    }
  }

  reviewsExistUpdate() {
    this.reviewCurrentPage = 2;
    this.reviewsExist = true;
  }

  updateProductRating(rating: number) {
    this.productFull.rating = rating;
    console.log("Product after rating update: ", this.productFull)
  }
}
