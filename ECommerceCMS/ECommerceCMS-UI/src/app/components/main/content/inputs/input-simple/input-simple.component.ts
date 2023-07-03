import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { InputComponent } from '../input/input.component';

@Component({
  selector: 'app-input-simple',
  templateUrl: './input-simple.component.html',
  styleUrls: ['./input-simple.component.css']
})
export class InputSimpleComponent extends InputComponent implements OnInit {
  
  override ngOnInit(): void {
  }

}
