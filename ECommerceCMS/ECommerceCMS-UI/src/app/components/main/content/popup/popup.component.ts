import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Output, OnInit, Input } from '@angular/core';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { Message } from 'src/app/data/message';
import { PopupServiceItem } from 'src/app/data/popup-service-item';
import { TableDataService } from 'src/app/services/table-data-service/table-data.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css'],
})
export class PopupComponent implements OnInit {  
  @Input() popupServiceItem: PopupServiceItem = new PopupServiceItem();

  @Output() onPopupInteraction = new EventEmitter<boolean>();
  isOpened: boolean = true;

  @Output() showMessage = new EventEmitter<Message>();

  constructor(public http: HttpClient) { }
  
  popupInteraction() {
    this.isOpened = !this.isOpened;
    this.onPopupInteraction.emit(this.isOpened);
  }
  
  ngOnInit(): void {
    //console.log(this.inputBlockDTO);
  }
}
