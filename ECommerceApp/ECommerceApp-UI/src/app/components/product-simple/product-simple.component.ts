import { Component, Input, OnInit } from '@angular/core';
import { ProductSimple } from 'src/app/data/product/productSimple';

@Component({
  selector: 'app-product-simple',
  templateUrl: './product-simple.component.html',
  styleUrls: ['./product-simple.component.css']
})
export class ProductSimpleComponent implements OnInit {

  @Input() productSimple: ProductSimple = new ProductSimple();
  displayablePrice: string = "";

  constructor() { }

  ngOnInit(): void {
    
  }
}
