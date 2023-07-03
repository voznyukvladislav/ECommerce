import { Component, Input, OnInit } from '@angular/core';
import { InputBlockDTO } from 'src/app/data/input/input-block';

@Component({
  selector: 'app-inputs-handler',
  templateUrl: './inputs-handler.component.html',
  styleUrls: ['./inputs-handler.component.css']
})
export class InputsHandlerComponent implements OnInit {

  @Input() inputsBlock: InputBlockDTO = new InputBlockDTO();
  
  constructor() { }

  ngOnInit(): void {
  }
  output(): void {
    console.log(this.inputsBlock);
  }
}
