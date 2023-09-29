import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductPageComponent } from './components/product-page/product-page.component';
import { AppComponent } from './app.component';
import { ContentComponent } from './components/content/content.component';
import { ProductDetailPageComponent } from './components/product-detail-page/product-detail-page.component';
import { OrdersComponent } from './components/orders/orders.component';
import { OrderDetailComponent } from './components/order-detail/order-detail.component';

const routes: Routes = [
  { path: "", component: ContentComponent },
  { path: "products", component: ProductPageComponent },
  { path: "products/:id", component: ProductDetailPageComponent },
  { path: "orders", component: OrdersComponent },
  { path: "orders/:id", component: OrderDetailComponent },
  { path: "**", redirectTo: "/" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
