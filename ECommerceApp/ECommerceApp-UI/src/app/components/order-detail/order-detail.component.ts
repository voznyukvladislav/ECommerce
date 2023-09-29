import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/data/order/order';
import { OrderService } from 'src/app/services/order-service/order.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnInit {

  order: Order = new Order();

  constructor(private orderService: OrderService, private route: ActivatedRoute) {
    route.params.subscribe({
      next: param => {
        console.log(param);
        this.orderService.getOrderDetails(`${param['id']}`).subscribe({
          next: (order: any) => {
            this.order = order;
            console.log(this.order);
          }
        });
      }
    });
  }

  ngOnInit(): void {
  }

}
