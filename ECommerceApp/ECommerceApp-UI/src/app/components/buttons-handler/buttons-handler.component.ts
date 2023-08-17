import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { Button } from 'src/app/data/button';
import { PopupData } from 'src/app/data/popupData';
import { PopupService } from 'src/app/services/popup-service/popup.service';

@Component({
  selector: 'app-buttons-handler',
  templateUrl: './buttons-handler.component.html',
  styleUrls: ['./buttons-handler.component.css']
})
export class ButtonsHandlerComponent implements OnInit {

  @Input() buttons: Button[] = [];

  constructor(private popupService: PopupService, private http: HttpClient) {
    
  }

  ngOnInit(): void {
  }
}
