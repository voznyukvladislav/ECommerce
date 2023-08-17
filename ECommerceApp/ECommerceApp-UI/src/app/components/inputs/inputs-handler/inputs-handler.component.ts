import { Component, Input, OnInit } from '@angular/core';
import { Input as InputDTO } from '../../../data/input';

@Component({
  selector: 'app-inputs-handler',
  templateUrl: './inputs-handler.component.html',
  styleUrls: ['./inputs-handler.component.css']
})
export class InputsHandlerComponent implements OnInit {

  @Input() inputs: InputDTO[] = []; 

  constructor() { }

  ngOnInit(): void {
  }

}
