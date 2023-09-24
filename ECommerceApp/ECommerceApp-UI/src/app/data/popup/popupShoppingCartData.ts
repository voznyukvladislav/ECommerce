import { ShoppingCart_Product } from "../shoppingCart_product";

export class PopupShoppingCartData {
    action: Function = () => {}
    shoppingCartProducts: ShoppingCart_Product[] = [];
    isOpened: boolean = false;
    title: string = "";
}