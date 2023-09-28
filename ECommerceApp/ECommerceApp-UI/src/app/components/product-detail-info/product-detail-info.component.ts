import { AfterViewInit, Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Message, MessageStatusNames } from 'src/app/data/message';
import { PopupShoppingCartData } from 'src/app/data/popup/popupShoppingCartData';
import { ProductFull } from 'src/app/data/product/productFull';
import { MessageService } from 'src/app/services/message-service/message.service';
import { PopupService } from 'src/app/services/popup-service/popup.service';
import { RatingService } from 'src/app/services/rating-service/rating.service';
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

  constructor(
    private popupService: PopupService,
    private shoppingCartService: ShoppingCartService,
    private messageService: MessageService,
    private ratingService: RatingService) { 
    
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.ratingService.getRating().subscribe({
        next: rating => {
          let ratingBlock = document.getElementById("rating");
          let filled = (rating / 5) * 100;
          ratingBlock!.style.width = `${filled}px`;
        }
      });
    }, 200);
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
