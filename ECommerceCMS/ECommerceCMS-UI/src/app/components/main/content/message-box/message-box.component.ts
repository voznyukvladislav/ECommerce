import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { Message } from 'src/app/data/message';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.css']
})
export class MessageBoxComponent implements OnInit, AfterViewInit {
  @Input() message: Message = new Message();

  @ViewChild("progress") progress: any;
  @ViewChild("messageBox") messageBox: any;

  statusSuccessful: string = Constants.successful;
  statusFailed: string = Constants.failed;

  timeout = setTimeout(() => {}, 0);

  constructor() { }  

  messageIsEmpty(): boolean {
    return Message.messageIsEmpty(this.message);
  }

  closeMessage(): void {
    this.messageBox.nativeElement.classList.remove("after-show");
    clearTimeout(this.timeout);
  }

  ngOnInit(): void { }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.messageBox.nativeElement.classList.add("after-show");  

      if(this.message.status == this.statusSuccessful) {
        this.progress.nativeElement.classList.add("successful-background-color");
      }        
      else if(this.message.status == this.statusFailed) {
        this.progress.nativeElement.classList.add("failed-background-color");
      }

      this.progress.nativeElement.classList.add("filled");
    }, 10);

    this.timeout = setTimeout(this.closeMessage.bind(this), 5000);
  }
}
