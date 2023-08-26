import { Component, OnInit } from '@angular/core';
import { PopupService } from './services/popup-service/popup.service';
import { PopupData } from './data/popupData';
import { Message } from './data/message';
import { MessageService } from './services/message-service/message.service';
import { AuthenticationHandler } from './data/authenticationHandler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ECommerceApp-UI';
  popupData: PopupData = new PopupData();

  messages: Message[] = [];
  
  constructor(private popupService: PopupService, private messageService: MessageService) {
    this.popupService.getPopupData().subscribe({
      next: data => {
        this.popupData = data;
      }
    });

    this.messageService.getMessage().subscribe({
      next: message => {
        this.messages.push(message);
      }
    });
  }

  ngOnInit(): void {
  }
}
