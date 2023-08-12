import { Injectable } from '@angular/core';
import { Observable, Subject, Subscription, of } from 'rxjs';
import { Message } from 'src/app/data/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  messages: Subject<Message> = new Subject<Message>();

  constructor() { }

  addMessage(message: Message) {
    this.messages.next(message);
  }

  getMessages() {
    return this.messages;
  }
}
