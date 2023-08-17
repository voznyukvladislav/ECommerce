import { Component, OnInit } from '@angular/core';
import { InputParentComponent } from '../input-parent/input-parent.component';

@Component({
  selector: 'app-input-password-validatable',
  templateUrl: './input-password-validatable.component.html',
  styleUrls: ['./input-password-validatable.component.css']
})
export class InputPasswordValidatableComponent extends InputParentComponent implements OnInit {

  override ngOnInit(): void {
  }

}
