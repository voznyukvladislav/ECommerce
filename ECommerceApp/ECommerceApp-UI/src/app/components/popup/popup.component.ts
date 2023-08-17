import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { PopupData } from 'src/app/data/popupData';
import { PopupService } from 'src/app/services/popup-service/popup.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent implements OnInit, AfterViewInit {

  @ViewChild("popup") popup: HTMLElement | any;

  popupData: PopupData = new PopupData();

  constructor(private popupService: PopupService, private http: HttpClient) {
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
                  popupData.action = PopupService.register.bind(this, this.http, popupData);
      
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
