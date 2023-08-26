import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { AuthenticationHandler } from 'src/app/data/authenticationHandler';
import { Constants } from 'src/app/data/constants';
import { PopupData } from 'src/app/data/popupData';
import { MessageService } from '../message-service/message.service';
import { AuthenticationHandlerService } from '../authentication-handler-service/authentication-handler.service';

@Injectable({
  providedIn: 'root'
})
export class PopupService {
  popupData: BehaviorSubject<PopupData> = new BehaviorSubject<PopupData>(new PopupData());

  getPopupData(): BehaviorSubject<PopupData> {
    return this.popupData;
  }

  callPopup(popupData: PopupData) {
    this.popupData.next(popupData);
  }

  getLoginPopup() {
    return this.http.get(`${Constants.api}/${Constants.login}/${Constants.getLoginPopup}`);
  }

  getRegistrationPopup() {
    return this.http.get(`${Constants.api}/${Constants.login}/${Constants.getRegistrationPopup}`);
  }

  static login(http: HttpClient, popupData: PopupData, messageService: MessageService, authenticationHandlerService: AuthenticationHandlerService) {
    http.post(`${Constants.api}/${Constants.login}/${Constants.login}`, popupData, { withCredentials: true }).subscribe({
      next: (data: any) => {
        AuthenticationHandler.Authenticate(data.content, localStorage);
        
        let message = data.message;
        messageService.addMessage(message);
        authenticationHandlerService.Authenticate(data.content, localStorage);
      }
    });
  }

  static register(http: HttpClient, popupData: PopupData) {
    http.post(`${Constants.api}/${Constants.login}/${Constants.register}`, popupData, { withCredentials: true }).subscribe();
  }

  constructor(private http: HttpClient) { }
}
