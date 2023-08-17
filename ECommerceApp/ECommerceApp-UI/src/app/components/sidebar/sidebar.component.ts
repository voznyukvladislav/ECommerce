import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SimpleDTO } from 'src/app/data/simpleDTO';
import { SidebarService } from 'src/app/services/sidebar-service/sidebar.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  isSidebarOpened: Subject<boolean> = new Subject();
  isOpened: boolean = false;

  categories: SimpleDTO[] = [];
  subCategories: SimpleDTO[] = [];

  displayable: string = "categories";

  constructor(private sidebarService: SidebarService) {
    this.isSidebarOpened = this.sidebarService.getSidebar();
    this.isSidebarOpened.subscribe({
      next: isOpened => {
        this.isOpened = isOpened;
      }
    });
  }

  ngOnInit(): void {
    this.sidebarService.getCategories().subscribe({
      next: (data: any) => {
        data.forEach((el: any) => {
          this.categories.push(el);
        });
      }
    });
  }

  toSubCategories(categoryId: string) {
    this.sidebarService.getSubCategories(categoryId).subscribe({
      next: (data: any) => {
        data.forEach((el: any) => {
          this.subCategories.push(el);
        });
        
        this.displayable = "subCategories";
      }
    });
  }

  toCategories() {
    this.displayable = "categories";
    this.subCategories = [];
  }
}
