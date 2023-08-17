import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PopupData } from 'src/app/data/popupData';
import { PopupService } from 'src/app/services/popup-service/popup.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  title: string = "Log In";

  popupData: PopupData = new PopupData();

  contextMenuIsOpened: boolean = false;

  constructor(private popupService: PopupService, private http: HttpClient) { }

  ngOnInit(): void {
  }

  contextMenuInteration() {
    this.contextMenuIsOpened = !this.contextMenuIsOpened;
  }

  callPopup() {
    this.popupService.getLoginPopup().subscribe({
      next: (data: any) => {
        let popupData: PopupData = new PopupData();
        popupData.title = data.title;
        popupData.inputs = data.inputs;
        popupData.buttons = data.buttons;
        popupData.action = PopupService.login.bind(this, this.http, popupData);

        popupData.isOpened = true;
        this.popupService.callPopup(popupData);
      
        console.log("Raw data: ", data);
        console.log("Data: ", popupData);
      }
    });
  }

  
}
