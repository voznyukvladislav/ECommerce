import { Component, Input, OnInit } from '@angular/core';
import { FilterValue } from 'src/app/data/filter/filterValue';

@Component({
  selector: 'app-input-filter',
  templateUrl: './input-filter.component.html',
  styleUrls: ['./input-filter.component.css']
})
export class InputFilterComponent implements OnInit {

  @Input() filterValue: FilterValue = new FilterValue();

  constructor() { }

  ngOnInit(): void {
  }

  check() {
    this.filterValue.isChecked = !this.filterValue.isChecked;
  }
}
