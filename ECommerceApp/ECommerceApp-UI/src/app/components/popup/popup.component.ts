import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PopupData } from 'src/app/data/popup/popupData';
import { PopupService } from 'src/app/services/popup-service/popup.service';
import { InputsHandlerComponent } from '../inputs/inputs-handler/inputs-handler.component';
import { MessageService } from 'src/app/services/message-service/message.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent implements OnInit, AfterViewInit {

  @ViewChild("popup") popup: HTMLElement | any;

  popupData: PopupData = new PopupData();

  constructor(
    private popupService: PopupService,
    private http: HttpClient,
    private messageService: MessageService) {
    this.popupService.getPopupData().subscribe({
      next: data => {
        this.popupData = data;

        this.popupData.buttons.forEach(el => {
          if (el.name == "Registration") {
            el.action = () => {
              this.popupService.getRegistrationPopup().subscribe({
                next: (data: any) => {
                  let popupData: PopupData = new PopupData();
                  popupData.title = data.title;
                  popupData.inputs = data.inputs;
                  popupData.buttons = data.buttons;
                  popupData.action = PopupService.register.bind(this, this.http, popupData, this.messageService);
      
                  popupData.isOpened = true;
                  this.popupService.callPopup(popupData);
                
                  console.log("Raw data: ", data);
                  console.log("Data: ", popupData);
                }
              });
            }
          }
          else if (el.name == "Log In") {
            el.action = () => {
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
        });
      }
    });
  }

  close() {
    this.popup.nativeElement.classList.remove("opacity1");
    this.popup.nativeElement.classList.remove("scale1");
    setTimeout(() => {
      this.popupData.isOpened = false;
      this.popupService.callPopup(this.popupData);
    }, 500);
  }

  actionWrapper() {
    let isFormValid = this.isFormValid();

    if(isFormValid) {
      this.popupData.action();
      this.close();
    }
  }

  private isFormValid(): boolean {
    let form = document.getElementById("form");
    let inputs = [];
    for(let i = 0; i < form?.children.length!; i++) {
      inputs.push(form?.children[i].children[0].children[0]);

      if(form?.children[i].children[0].children[1]) {
        inputs.push(form?.children[i].children[0].children[1]);
      }      
    }
    console.log(inputs);

    let formIsValid = true;
    for(let i = 0; i < inputs.length; i++) {
      if (!inputs[i]?.classList.contains("ng-valid")) {
        formIsValid = false;
        break;
      }
    }

    return formIsValid;
  }

  debug() {
    console.log(this.popupData);
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      console.log(this.popup);
      this.popup.nativeElement.classList.add("opacity1");
      this.popup.nativeElement.classList.add("scale1");
    }, 20);
  }
}
