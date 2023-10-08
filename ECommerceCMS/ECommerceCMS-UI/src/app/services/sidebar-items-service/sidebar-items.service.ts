import { Injectable } from '@angular/core';
import { SidebarItem } from 'src/app/data/sidebar-item';

@Injectable({
  providedIn: 'root'
})
export class SidebarItemsService {

  constructor() { }

  getSidebarItems(): Array<SidebarItem> {
    let sidebarItems: Array<SidebarItem> = [
      { 
        title: 'Categories', link: '', iconSrc: '..\\assets\\icons\\category.png',
        subItems: [
          { title: 'Categories', link: 'categories' },
          { title: 'SubCategories', link: 'subcategories' }
        ] 
      },
      { 
        title: 'Attributes', link: '', iconSrc: '..\\assets\\icons\\attribute.png',
        subItems: [
          { title: 'Attributes', link: 'attributes' },
          { title: 'Attribute Sets', link: 'attributeSets' }
        ] 
      },
      { 
        title: 'Measurements', link: '', iconSrc: '..\\assets\\icons\\measurement.png',
        subItems: [
          { title: 'Measurements', link: 'measurements' },
          { title: 'Measurement Sets', link: 'measurementSets' }
        ] 
      },
      { 
        title: 'Products', link: '', iconSrc: '..\\assets\\icons\\product.png',
        subItems: [
          { title: 'Products', link: 'products' },
          { title: 'Photos', link: 'photos' },
          { title: 'Templates', link: 'templates' },
          { title: 'Values', link: 'values' },
          { title: 'Discounts', link: 'discounts' }
        ] 
      },
      { 
        title: 'Users', link: '', iconSrc: '..\\assets\\icons\\user.png',
        subItems: [
          { title: 'Users', link: 'users' },
          { title: 'Orders', link: 'orders' },
          { title: 'Order_Products', link: 'order_product' },
          { title: 'Shopping Carts', link: 'shoppingCarts' },
          { title: 'Reviews', link: 'reviews' },
          { title: 'Roles', link: 'roles' }
        ] 
      }
    ];

    return sidebarItems;
  }
}
