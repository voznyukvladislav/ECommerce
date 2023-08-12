import { Component, ElementRef, OnInit } from '@angular/core';
import { InputComponent } from '../input/input.component';

@Component({
  selector: 'app-input-boolean',
  templateUrl: './input-boolean.component.html',
  styleUrls: ['./input-boolean.component.css']
})
export class InputBooleanComponent extends InputComponent implements OnInit {

  override ngOnInit(): void {
  }

  change(block: any): void {
    block.checked = !block.checked;
    this.input.values[0] = block.checked.toString();
  }
}
