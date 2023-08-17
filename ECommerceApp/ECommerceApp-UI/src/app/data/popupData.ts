import { Button } from "./button";
import { Input } from "./input";

export class PopupData {
    action: Function = () => {}
    inputs: Input[] = [];
    buttons: Button[] = [];
    isOpened: boolean = false;
    title: string = "";
}