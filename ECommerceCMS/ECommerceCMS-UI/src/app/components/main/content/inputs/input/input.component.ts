import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { InputDTO } from 'src/app/data/input/input-dto';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent implements OnInit {
  
  @Input() input: InputDTO = new InputDTO();
  http: HttpClient;

  constructor(http: HttpClient) { 
    this.http = http;
  }

  ngOnInit(): void {
  }

}
