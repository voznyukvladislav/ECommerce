import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subject, from } from 'rxjs';
import { Constants } from 'src/app/data/constants';
import { PopupData } from 'src/app/data/popupData';
import { UserInfo } from 'src/app/data/userInfo';
import { AuthenticationHandlerService } from 'src/app/services/authentication-handler-service/authentication-handler.service';
import { MessageService } from 'src/app/services/message-service/message.service';
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

  isAuthenticated = false;
  userInfo: UserInfo = new UserInfo();

  constructor(
    private popupService: PopupService,
    private http: HttpClient,
    private messageService: MessageService,
    private authenticationHandlerService: AuthenticationHandlerService) {
      this.userInfo = AuthenticationHandlerService.getUserInfo(localStorage);
      this.isAuthenticated = AuthenticationHandlerService.getAuthenticationStatus(localStorage);

      this.authenticationHandlerService.getUserInfo().subscribe({
        next: data => {
          this.userInfo = data;
        }
      });

      this.authenticationHandlerService.getAuthenticationStatus().subscribe({
        next: data => {
          this.isAuthenticated = data;
        }
      });
    }

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
        popupData.action = PopupService.login.bind(this, this.http, popupData, this.messageService, this.authenticationHandlerService);

        popupData.isOpened = true;
        this.popupService.callPopup(popupData);
      
        console.log("Raw data: ", data);
        console.log("Data: ", popupData);
      }
    });
  }

  logOut() {
    this.http.get(`${Constants.api}/${Constants.login}/${Constants.logOut}`, { withCredentials: true }).subscribe({
      next: (data: any) => {
        this.authenticationHandlerService.logOut(localStorage);
        
        let message = data;
        this.messageService.addMessage(message);
      }
    })
  }
}
