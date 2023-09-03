import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { AttributeFilter } from 'src/app/data/filter/attributeFilter';

@Component({
  selector: 'app-attribute-filter',
  templateUrl: './attribute-filter.component.html',
  styleUrls: ['./attribute-filter.component.css']
})
export class AttributeFilterComponent implements OnInit {

  @Input() attributeFilter: AttributeFilter = new AttributeFilter();

  @ViewChild("values") values: HTMLElement | any;

  isOpened: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  interact(): void {
    this.isOpened = !this.isOpened;
    if (this.isOpened) {
      this.values.nativeElement.style.height = `${Constants.inputFilterHeight * this.attributeFilter.values.length}px`;
    }
    else {
      this.values.nativeElement.style.height = "0px";
    }
  }
}
