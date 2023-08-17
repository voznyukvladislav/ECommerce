import { Component, OnInit } from '@angular/core';
import { InputParentComponent } from '../input-parent/input-parent.component';

@Component({
  selector: 'app-input-password',
  templateUrl: './input-password.component.html',
  styleUrls: ['./input-password.component.css']
})
export class InputPasswordComponent extends InputParentComponent implements OnInit {

  override ngOnInit(): void {
  }

}
