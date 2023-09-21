import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductFull } from 'src/app/data/product/productFull';
import { DbDataService } from 'src/app/services/db-data-service/db-data.service';

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

  constructor(private dbDataService: DbDataService, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe({
      next: (params: any) => {
        this.productId = params.id;

        this.dbDataService.getProduct(this.productId).subscribe({
          next: (product: any) => {
            this.productFull = product;
            console.log(this.productFull);

            if (this.reviewsExist) {
              this.dbDataService.getReviews(this.productId, this.reviewPageSize, this.reviewCurrentPage).subscribe({
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
      this.dbDataService.getReviews(this.productId, this.reviewPageSize, this.reviewCurrentPage).subscribe({
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
}
