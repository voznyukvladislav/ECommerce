import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { ProductFull } from 'src/app/data/product/productFull';

@Component({
  selector: 'app-product-detail-info',
  templateUrl: './product-detail-info.component.html',
  styleUrls: ['./product-detail-info.component.css']
})
export class ProductDetailInfoComponent implements OnInit, AfterViewInit {

  @Input() productFull: ProductFull = new ProductFull();

  starsCounter: number[] = [1, 2, 3, 4, 5];

  constructor() { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      let rating = document.getElementById("rating");
      let filled = (this.productFull.rating / 5) * 100;
      console.log(filled);
      console.log(this.productFull);
      //filled = 50;
      rating!.style.width = `${filled}px`;

    }, 100);
  }
}
