import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SidebarService } from 'src/app/services/sidebar-service/sidebar.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private sidebarService: SidebarService) { }

  ngOnInit(): void {
  }

  openSidebar() {
    this.sidebarService.openSidebar();
  }
}
