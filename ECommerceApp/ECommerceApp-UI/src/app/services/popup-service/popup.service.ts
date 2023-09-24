import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { AuthenticationHandler } from 'src/app/data/authenticationHandler';
import { Constants } from 'src/app/data/constants';
import { PopupData } from 'src/app/data/popup/popupData';
import { MessageService } from '../message-service/message.service';
import { AuthenticationHandlerService } from '../authentication-handler-service/authentication-handler.service';
import { PopupShoppingCartData } from 'src/app/data/popup/popupShoppingCartData';

@Injectable({
  providedIn: 'root'
})
export class PopupService {
  popupData: BehaviorSubject<PopupData> = new BehaviorSubject<PopupData>(new PopupData());
  popupShoppingCartData: BehaviorSubject<PopupShoppingCartData> = new BehaviorSubject<PopupShoppingCartData>(new PopupShoppingCartData());

  // Login and register popup
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
        let message = data.message;
        messageService.addMessage(message);
        authenticationHandlerService.Authenticate(data.content, localStorage);
      },
      error: (error: any) => {
        let message = error.error;
        messageService.addMessage(message);
      }
    });
  }

  static register(http: HttpClient, popupData: PopupData) {
    http.post(`${Constants.api}/${Constants.login}/${Constants.register}`, popupData, { withCredentials: true }).subscribe();
  }

  // Shopping cart popup
  getPopupShoppingCartData() {
    return this.popupShoppingCartData;
  }

  callPopupShoppingCart(popupShoppingCartData: PopupShoppingCartData) {
    this.popupShoppingCartData.next(popupShoppingCartData);
  }

  constructor(private http: HttpClient) { }
}
