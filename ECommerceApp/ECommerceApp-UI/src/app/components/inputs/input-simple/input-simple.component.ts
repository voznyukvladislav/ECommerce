import { Component, OnInit } from '@angular/core';
import { InputParentComponent } from '../input-parent/input-parent.component';

@Component({
  selector: 'app-input-simple',
  templateUrl: './input-simple.component.html',
  styleUrls: ['./input-simple.component.css']
})
export class InputSimpleComponent extends InputParentComponent implements OnInit {

  override ngOnInit(): void {
    
  }
}
