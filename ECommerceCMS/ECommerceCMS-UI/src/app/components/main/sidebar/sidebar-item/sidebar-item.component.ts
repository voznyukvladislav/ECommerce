import { Component, Input, OnInit } from '@angular/core';
import { SidebarItem } from 'src/app/data/sidebar-item';

@Component({
  selector: 'app-sidebar-item',
  templateUrl: './sidebar-item.component.html',
  styleUrls: ['./sidebar-item.component.css']
})
export class SidebarItemComponent implements OnInit {
  @Input() sidebarItem: SidebarItem = new SidebarItem();
  @Input() isMaximized: boolean = false;

  isCollapsed: boolean = false;

  subItemsContainerHeigth = '';

  constructor() {
  }

  ngOnInit(): void {
  }

  collapse(): void {
    this.isCollapsed = !this.isCollapsed;
    this.subItemsContainerHeigth = 41 * this.sidebarItem.subItems.length + 'px';
    console.log(this.subItemsContainerHeigth);
  }
}
