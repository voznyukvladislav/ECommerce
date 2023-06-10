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
        title: 'Kek', link: '', iconSrc: '..\\assets\\icons\\home.png',
        subItems: [
          { title: 'SubKek', link: 'kek' },
          { title: 'SubKek', link: 'kekus' },
          { title: 'SubKek', link: '' } 
        ] 
      },
      { 
        title: 'Kek', link: '', iconSrc: '..\\assets\\icons\\home.png',
        subItems: [
          { title: 'SubKek', link: '' },
          { title: 'SubKek', link: '' },
          { title: 'SubKek', link: '' } 
        ] 
      },{ 
        title: 'Kek', link: '', iconSrc: '..\\assets\\icons\\home.png',
        subItems: [
          { title: 'SubKek', link: '' },
          { title: 'SubKek', link: '' },
          { title: 'SubKek', link: '' } 
        ] 
      }
    ];

    return sidebarItems;
  }
}
