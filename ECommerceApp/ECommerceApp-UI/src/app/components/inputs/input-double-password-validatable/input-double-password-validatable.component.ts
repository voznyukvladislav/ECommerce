import { Component, OnInit } from '@angular/core';
import { InputParentComponent } from '../input-parent/input-parent.component';

@Component({
  selector: 'app-input-double-password-validatable',
  templateUrl: './input-double-password-validatable.component.html',
  styleUrls: ['./input-double-password-validatable.component.css']
})
export class InputDoublePasswordValidatableComponent extends InputParentComponent implements OnInit {

  value2: string = "";

  override ngOnInit(): void {
  }

}
