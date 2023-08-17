import { Component, OnInit, Input } from '@angular/core';
import { Input as InputDTO } from 'src/app/data/input';

@Component({
  selector: 'app-input-parent',
  templateUrl: './input-parent.component.html',
  styleUrls: ['./input-parent.component.css']
})
export class InputParentComponent implements OnInit {

  @Input() input: InputDTO = new InputDTO();

  constructor() { }

  ngOnInit(): void {
  }

}
