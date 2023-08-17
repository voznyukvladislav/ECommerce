import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Message } from 'src/app/data/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  messageSubject: Subject<Message> = new Subject<Message>();

  getMessage(): Subject<Message> {
    return this.messageSubject;
  }

  addMessage(message: Message) {
    this.messageSubject.next(message);
  }
  
  constructor() { }
}
