import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { PopupShoppingCartData } from 'src/app/data/popup/popupShoppingCartData';
import { OrderService } from 'src/app/services/order-service/order.service';
import { PopupService } from 'src/app/services/popup-service/popup.service';
import { ShoppingCartService } from 'src/app/services/shopping-cart-service/shopping-cart.service';

@Component({
  selector: 'app-popup-shopping-cart',
  templateUrl: './popup-shopping-cart.component.html',
  styleUrls: ['./popup-shopping-cart.component.css']
})
export class PopupShoppingCartComponent implements OnInit, AfterViewInit {

  @ViewChild("popup") popup: HTMLElement | any;

  popupShoppingCartData: PopupShoppingCartData = new PopupShoppingCartData();

  constructor(
    private popupService: PopupService,
    private shoppingCartService: ShoppingCartService,
    private orderService: OrderService,
    private router: Router) {
    this.popupService.getPopupShoppingCartData().subscribe({
      next: data => {
        this.popupShoppingCartData = data;
      }
    });
  }

  close() {
    this.popup.nativeElement.classList.remove("opacity1");
    this.popup.nativeElement.classList.remove("scale1");
    setTimeout(() => {
      this.popupShoppingCartData.isOpened = false;
      this.popupService.callPopupShoppingCart(this.popupShoppingCartData);
    }, 500);
  }

  actionWrapper() {
    let confirmation;
    if (this.popupShoppingCartData.shoppingCartProducts.length > 1) {
      confirmation = confirm("Are you sure want to order these products?");
    }
    else if (this.popupShoppingCartData.shoppingCartProducts.length == 1) {
      confirmation = confirm("Are you sure want to order this product?");  
    }
    
    if (confirmation) {
      this.orderService.addOrder(this.popupShoppingCartData.shoppingCartProducts).subscribe({
        next: () => {
          this.close();
          this.router.navigate(['orders']);
        }
      });
    }
  }

  debug() {
    console.log(this.popupShoppingCartData);
  }

  removeProduct(index: number) {
    this.shoppingCartService.removeShoppingCartProduct(this.popupShoppingCartData.shoppingCartProducts[index].productSimple.id).subscribe({
      next: () => {
        this.shoppingCartService.getShoppingCart().subscribe({
          next: (shoppingCart: any) => {
            console.log("Shopping cart after removal: ", shoppingCart);
            this.popupShoppingCartData.shoppingCartProducts = shoppingCart;
            console.log(this.popupShoppingCartData);
          }
        })
      }
    });
  }

  increment(index: number) {
    this.popupShoppingCartData.shoppingCartProducts[index].count++;
    this.shoppingCartService.updateShoppingCartProductCount(
      this.popupShoppingCartData.shoppingCartProducts[index].productSimple.id,
      this.popupShoppingCartData.shoppingCartProducts[index].count).subscribe({});
  }

  decrement(index: number) {
    let count = this.popupShoppingCartData.shoppingCartProducts[index].count;
    if (count > 1) {
      this.popupShoppingCartData.shoppingCartProducts[index].count--;
      this.shoppingCartService.updateShoppingCartProductCount(
        this.popupShoppingCartData.shoppingCartProducts[index].productSimple.id,
        this.popupShoppingCartData.shoppingCartProducts[index].count).subscribe({});
    }
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      console.log(this.popup);
      this.popup.nativeElement.classList.add("opacity1");
      this.popup.nativeElement.classList.add("scale1");
    }, 20);
  }
}
