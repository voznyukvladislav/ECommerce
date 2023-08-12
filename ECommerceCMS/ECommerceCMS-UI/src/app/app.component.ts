import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { InputBlockDTO } from './data/input/input-block';
import { LoginService } from './services/login-service/login.service';
import { AuthenticationHandler } from './data/authentication-handler';
import { Message } from './data/message';
import { MessageService } from './services/message-service/message.service';
import { Observable, Observer, Subscription, of } from 'rxjs';
import { PopupService } from './services/popup-service/popup.service';
import { PopupServiceItem } from './data/popup-service-item';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ECommerceCMS-UI';
  popupIsOpened: boolean = false;

  popupServiceItem: PopupServiceItem = new PopupServiceItem();

  messagesArr: Message[] = [];
  messagesIsShownArr: boolean[] = [];

  constructor(
    private loginService: LoginService,
    private messageService: MessageService,
    private popupService: PopupService)
  {
      messageService.getMessages().subscribe({
        next: data => {
          this.messagesArr.push(data);
          this.messagesIsShownArr.push(true);
        }
      });

      popupService.getPopup().subscribe({
        next: data => {
          this.popupServiceItem = data;
          console.log("kek", this.popupServiceItem);
          
          if(InputBlockDTO.isEmpty(this.popupServiceItem.inputBlockDTO)) {
            this.open({popupIsOpened: true});
          }
        }
      });
  }

  ngOnInit(): void {
    this.loginService.isAuthorized().subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        AuthenticationHandler.LogOut(localStorage);
        console.log(error);
      }
    });

    if (sessionStorage.getItem("Message.IsRegistered") == "1") {
      let message = new Message();
      message.title = sessionStorage.getItem("Message.Title")!;
      message.status = sessionStorage.getItem("Message.Status")!;
      message.text = sessionStorage.getItem("Message.Text")!;

      this.messageService.addMessage(message);

      Message.clearRegisteredMessage(sessionStorage);
    }
  }

  open(object: any) {
    this.popupIsOpened = object.popupIsOpened;
  }
}
