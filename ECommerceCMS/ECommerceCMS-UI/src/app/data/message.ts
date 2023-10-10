export class Message {
    title: string = "";
    status: string = "";
    text: string = "";

    static messageIsFull(message: Message): boolean {
        if (message.title && message.status && message.text) {
            return true;
        }
        else {
            return false;
        }
    }

    static messageIsEmpty(message: Message): boolean {
        if(message.title || message.status || message.text) {
            return true;
        } else {
            return false;
        }
    }

    static registerMessage(message: Message, storage: Storage) : void {
        storage.setItem("Message.IsRegistered", "1");
        storage.setItem("Message.Title", message.title);
        storage.setItem("Message.Status", message.status);
        storage.setItem("Message.Text", message.text);
    }

    static clearRegisteredMessage(storage: Storage) : void {
        storage.setItem("Message.IsRegistered", "0");
        storage.setItem("Message.Title", "");
        storage.setItem("Message.Status", "");
        storage.setItem("Message.Text", "");
    }

    // constructor(title: string, status: string, message: string) {
    //     this.title = title;
    //     this.status = status;
    //     this.message = message;
    // }
}