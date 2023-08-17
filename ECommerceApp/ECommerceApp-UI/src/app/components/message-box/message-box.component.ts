import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { Message, MessageStatusNames } from 'src/app/data/message';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.css']
})
export class MessageBoxComponent implements OnInit, AfterViewInit {

  @Input() message: Message = new Message();

  @ViewChild('messageBox') messageBox: HTMLElement | any;
  @ViewChild('underline') underline: HTMLElement | any;
  
  ttl: number = 5000;
  isAlive: boolean = true;

  constructor() { }

  close() {
    this.messageBox.nativeElement.classList.remove("opacity1");
    this.messageBox.nativeElement.classList.remove("scale1");
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.messageBox.nativeElement.classList.add("opacity1");
      this.messageBox.nativeElement.classList.add("scale1");

      if (this.message.status == MessageStatusNames.successful) {
        this.underline.nativeElement.classList.add("successful-color")
      }
      else {
        this.underline.nativeElement.classList.add("failed-color")
      }

      this.underline.nativeElement.classList.add('underlined');
    }, 20);

    setTimeout(() => {
      this.close();
    }, this.ttl);
  }

}
