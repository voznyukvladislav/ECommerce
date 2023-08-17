import { Component, OnInit } from '@angular/core';
import { InputParentComponent } from '../input-parent/input-parent.component';

@Component({
  selector: 'app-input-simple-validatable',
  templateUrl: './input-simple-validatable.component.html',
  styleUrls: ['./input-simple-validatable.component.css']
})
export class InputSimpleValidatableComponent extends InputParentComponent implements OnInit {

  override ngOnInit(): void {
  }

}
