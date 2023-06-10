import { Component, OnInit, Input } from '@angular/core';
import { InputComponent } from '../input/input.component';

@Component({
  selector: 'app-input-search',
  templateUrl: './input-search.component.html',
  styleUrls: ['./input-search.component.css']
})
export class InputSearchComponent extends InputComponent implements OnInit {

  @Input() link: string = '';

  items: Array<any> = new Array<any>();

  constructor() {
    super();
   }

  override ngOnInit(): void {
    
  }

}
