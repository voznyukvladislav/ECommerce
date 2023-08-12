import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { PopupServiceItem } from 'src/app/data/popup-service-item';

@Injectable({
  providedIn: 'root'
})
export class PopupService {

  popup: BehaviorSubject<PopupServiceItem> = new BehaviorSubject<PopupServiceItem>(new PopupServiceItem());

  open(popupServiceItem: PopupServiceItem) {
    this.popup.next(popupServiceItem);
  }

  getPopup(): BehaviorSubject<PopupServiceItem> {
    return this.popup;
  }

  constructor() { 

  }
}
