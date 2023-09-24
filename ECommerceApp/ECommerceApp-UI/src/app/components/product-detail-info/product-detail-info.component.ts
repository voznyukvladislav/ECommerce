import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { Message, MessageStatusNames } from 'src/app/data/message';
import { PopupShoppingCartData } from 'src/app/data/popup/popupShoppingCartData';
import { ProductFull } from 'src/app/data/product/productFull';
import { MessageService } from 'src/app/services/message-service/message.service';
import { PopupService } from 'src/app/services/popup-service/popup.service';
import { ShoppingCartService } from 'src/app/services/shopping-cart-service/shopping-cart.service';

@Component({
  selector: 'app-product-detail-info',
  templateUrl: './product-detail-info.component.html',
  styleUrls: ['./product-detail-info.component.css']
})
export class ProductDetailInfoComponent implements OnInit, AfterViewInit {

  @Input() productFull: ProductFull = new ProductFull();

  popupShoppingCartData: PopupShoppingCartData = new PopupShoppingCartData();

  starsCounter: number[] = [1, 2, 3, 4, 5];

  constructor(private popupService: PopupService, private shoppingCartService: ShoppingCartService, private messageService: MessageService) { 
    
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      let rating = document.getElementById("rating");
      let filled = (this.productFull.rating / 5) * 100;
      console.log(filled);
      console.log(this.productFull);
      //filled = 50;
      rating!.style.width = `${filled}px`;
    }, 100);
  }

  purchase() {
    if (localStorage.getItem("userInfo.isAuthenticated") == "true") {
      this.shoppingCartService.addShoppingCartProduct(this.productFull.id).subscribe({
        next: () => {
          this.shoppingCartService.getShoppingCart().subscribe({
            next: (shoppingCartProducts: any) => {
              console.log("ShoppingCart: ", shoppingCartProducts);
  
              this.popupShoppingCartData.title = "Shopping Cart";
              this.popupShoppingCartData.shoppingCartProducts = shoppingCartProducts;
              this.popupShoppingCartData.isOpened = true;
              this.popupService.callPopupShoppingCart(this.popupShoppingCartData);
            }
          })
        }
      });
    }
    else {
      let message = new Message();
      message.status = MessageStatusNames.failed;
      message.title = "Purchasing failed";
      message.text = "You need to be authorised to perform this action!";
      this.messageService.addMessage(message);
    }
  }
}
