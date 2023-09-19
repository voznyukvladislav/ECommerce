import { Component, Input, OnInit } from '@angular/core';
import { ProductAttributeSet } from 'src/app/data/product/productAttributeSet';

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrls: ['./properties.component.css']
})
export class PropertiesComponent implements OnInit {

  @Input() attributeSets: ProductAttributeSet[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
