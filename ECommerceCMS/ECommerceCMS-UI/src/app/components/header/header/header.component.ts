import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Message } from 'src/app/data/message';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Output() openPopup = new EventEmitter<boolean>();
  @Output() showMessage = new EventEmitter<Message>()
  @Input() popupIsOpened: boolean | undefined;
  constructor() { }

  ngOnInit(): void {
  }

  open(object: any) {
    this.openPopup.emit(object);
  }

  showMessageToApp(message: Message) {
    this.showMessage.emit(message);
  }
}
