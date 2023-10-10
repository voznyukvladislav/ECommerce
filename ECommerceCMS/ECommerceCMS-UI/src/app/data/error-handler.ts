import { MessageService } from "../services/message-service/message.service";
import { AuthenticationHandler } from "./authentication-handler";
import { Message } from "./message";

export class ErrorHandler {
    public static HandleError(error: any, storage: Storage, messageService: MessageService): void {
        if (error.status == 401) {
            ErrorHandler.HandleUnauthorized(storage);
        }
        ErrorHandler.DisplayMessage(error, messageService);
    }

    private static HandleUnauthorized(storage: Storage): void {
        AuthenticationHandler.LogOut(storage);
    }

    private static DisplayMessage(error: any, messageService: MessageService): void {
        let message: Message = new Message();
        message.status = error.error.status;
        message.title = error.error.title;
        message.text = error.error.text;
        
        if (Message.messageIsFull(message)) {
            messageService.addMessage(message);
        }
    }
}