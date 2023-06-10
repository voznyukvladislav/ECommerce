import { Component, OnInit, Input } from '@angular/core';
import { SidebarItem } from 'src/app/data/sidebar-item';
import { SidebarItemsService } from 'src/app/services/sidebar-items-service/sidebar-items.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  @Input() isMaximized: boolean = false;
  sidebarItems: Array<SidebarItem> = [];

  constructor(private sidebarItemsSevice: SidebarItemsService) { 
    this.sidebarItems = sidebarItemsSevice.getSidebarItems();
    console.log(this.sidebarItems);
  }

  ngOnInit(): void {
  }

}
