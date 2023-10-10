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
import { ErrorHandler } from 'src/app/data/error-handler';

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
        ErrorHandler.HandleError(error, this.storage, this.messageService);
      }
    })
  }

  loginRequest() {
    console.log(this.inputBlockDTO);
    this.loginService.login(this.inputBlockDTO).subscribe({
      next: (data: any) => {
        AuthenticationHandler.Authenticate(data.userDTO, localStorage);
        let message: Message = data.message;
        this.messageService.addMessage(message);
      },
      error: (error: any) => {
        ErrorHandler.HandleError(error, this.storage, this.messageService);
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
        ErrorHandler.HandleError(error, this.storage, this.messageService);
      }
    });
  }

  loginHover(): void {
    this.isLoginHovered = !this.isLoginHovered;
  }
}
