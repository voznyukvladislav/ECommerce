import { Component, Input, OnInit } from '@angular/core';
import { SidebarSubItem } from 'src/app/data/sidebar-sub-item';

@Component({
  selector: 'app-sidebar-sub-item',
  templateUrl: './sidebar-sub-item.component.html',
  styleUrls: ['./sidebar-sub-item.component.css']
})
export class SidebarSubItemComponent implements OnInit {
  @Input() sidebarSubItem: SidebarSubItem = new SidebarSubItem();

  constructor() { }

  ngOnInit(): void {
  }

  
}
