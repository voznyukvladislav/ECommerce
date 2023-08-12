import { Component, OnInit } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { HttpClient } from '@angular/common/http';
import { InputDTO } from 'src/app/data/input/input-dto';

@Component({
  selector: 'app-input-simple-password',
  templateUrl: './input-simple-password.component.html',
  styleUrls: ['./input-simple-password.component.css']
})
export class InputSimplePasswordComponent extends InputComponent implements OnInit {

  override ngOnInit(): void {
  }

}
