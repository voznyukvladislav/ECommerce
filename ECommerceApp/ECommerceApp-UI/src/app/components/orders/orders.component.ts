import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/data/order/order';
import { OrderService } from 'src/app/services/order-service/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  orders: Order[] = [];

  constructor(private orderService: OrderService) { 
    this.orderService.getOrders().subscribe({
      next: (orders: any) => {
        this.orders = orders;
      }
    })
  }

  ngOnInit(): void {
  }

}
