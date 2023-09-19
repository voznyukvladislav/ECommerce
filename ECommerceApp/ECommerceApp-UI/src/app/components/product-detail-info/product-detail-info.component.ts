import { Component, Input, OnInit } from '@angular/core';
import { ProductFull } from 'src/app/data/product/productFull';

@Component({
  selector: 'app-product-detail-info',
  templateUrl: './product-detail-info.component.html',
  styleUrls: ['./product-detail-info.component.css']
})
export class ProductDetailInfoComponent implements OnInit {

  @Input() productFull: ProductFull = new ProductFull();

  constructor() { }

  ngOnInit(): void {
  }

}
