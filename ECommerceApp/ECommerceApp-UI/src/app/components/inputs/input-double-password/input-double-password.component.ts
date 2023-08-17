import { Component, OnInit } from '@angular/core';
import { InputParentComponent } from '../input-parent/input-parent.component';

@Component({
  selector: 'app-input-double-password',
  templateUrl: './input-double-password.component.html',
  styleUrls: ['./input-double-password.component.css']
})
export class InputDoublePasswordComponent extends InputParentComponent implements OnInit {

  override ngOnInit(): void {
  }

}
