import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { Constants } from 'src/app/data/constants';
import { PopupData } from 'src/app/data/popupData';

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

  static login(http: HttpClient, popupData: PopupData) {
    http.post(`${Constants.api}/${Constants.login}/${Constants.login}`, popupData, { withCredentials: true }).subscribe();
  }

  static register(http: HttpClient, popupData: PopupData) {
    http.post(`${Constants.api}/${Constants.login}/${Constants.register}`, popupData, { withCredentials: true }).subscribe();
  }

  constructor(private http: HttpClient) { }
}
