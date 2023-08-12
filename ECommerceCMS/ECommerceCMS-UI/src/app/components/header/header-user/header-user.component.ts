import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthenticationHandler } from 'src/app/data/authentication-handler';
import { Constants } from 'src/app/data/constants';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { Message } from 'src/app/data/message';
import { PopupServiceItem } from 'src/app/data/popup-service-item';
import { InputsService } from 'src/app/services/inputs-service/inputs.service';
import { LoginService } from 'src/app/services/login-service/login.service';
import { MessageService } from 'src/app/services/message-service/message.service';
import { PopupService } from 'src/app/services/popup-service/popup.service';

@Component({
  selector: 'app-header-user',
  templateUrl: './header-user.component.html',
  styleUrls: ['./header-user.component.css']
})
export class HeaderUserComponent implements OnInit {
  inputBlockDTO: InputBlockDTO = new InputBlockDTO();

  storage: Storage = localStorage;

  isLoginHovered: boolean = false;

  constructor(
    private inputsService: InputsService,
    private loginService: LoginService,
    private messageService: MessageService,
    private popupService: PopupService) { }

  ngOnInit(): void {
  }

  open() {
    this.inputsService.getInputLoginBlock().subscribe({
      next: (data: any) => {
        this.inputBlockDTO = data;
        let popupServiceItem = new PopupServiceItem();
        popupServiceItem.inputBlockDTO = this.inputBlockDTO;
        popupServiceItem.clickFunction = this.loginRequest.bind(this);
        this.popupService.open(popupServiceItem);
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }

  loginRequest(inputBlockDTO: InputBlockDTO, http: HttpClient, eventEmitter: EventEmitter<Message>) {
    http.post(`${Constants.url}/${Constants.login}`, inputBlockDTO, { withCredentials: true }).subscribe({
      next: (data: any) => {
        AuthenticationHandler.Authenticate(data.userDTO, localStorage);
        let message: Message = data.message;
        this.messageService.addMessage(message);
      },
      error: (error: any) => {
        let message: Message = error.error;
        this.messageService.addMessage(message);

        // If user is not authenticated
        if(error.status == 401) {
          AuthenticationHandler.LogOut(localStorage);
        }
      }
    })
  }

  logoutRequest() {
    this.loginService.logout().subscribe({
      next: (data: any) => {
        AuthenticationHandler.LogOut(localStorage);
        let message: Message = data;
        this.messageService.addMessage(message);        
      }, 
      error: (error: any) => {

        // If user session has been expired
        if(error.status == 401) {
          AuthenticationHandler.LogOut(localStorage);
        }
      }
    });
  }

  loginHover(): void {
    this.isLoginHovered = !this.isLoginHovered;
  }
}
