import { OrderProduct } from "./orderProduct";

export class Order {
    id: number = 0;
    status: string = '';
    date: string = '';
    price: number = 0;
    positionsCount: number = 0;
    productsCount: number = 0;

    orderProducts: OrderProduct[] = [];
}