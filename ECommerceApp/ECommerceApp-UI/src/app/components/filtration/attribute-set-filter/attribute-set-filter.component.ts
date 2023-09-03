import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { AttributeSetFilter } from 'src/app/data/filter/attributeSetFilter';

@Component({
  selector: 'app-attribute-set-filter',
  templateUrl: './attribute-set-filter.component.html',
  styleUrls: ['./attribute-set-filter.component.css']
})
export class AttributeSetFilterComponent implements OnInit {

  @Input() attributeSetFilter: AttributeSetFilter = new AttributeSetFilter();
  
  @ViewChild("attributeFilters") attributeFilters: HTMLElement | any;

  isOpened: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  interact() {
    this.isOpened = !this.isOpened;
    if (this.isOpened) {
      this.attributeFilters.nativeElement.style.minHeight = `${this.attributeSetFilter.attributeFilters.length * Constants.attributeFilterHeight}px`;
    }
    else {
      this.attributeFilters.nativeElement.style.minHeight = "0px";
    }
  }

}
