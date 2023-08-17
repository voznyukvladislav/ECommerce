import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observer, Subject } from 'rxjs';
import { Constants } from 'src/app/data/constants';
import { SimpleDTO } from 'src/app/data/simpleDTO';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  private isSidebarOpened: Subject<boolean> = new Subject();
  private isOpened: boolean = false;

  openSidebar(): void {
    this.isOpened = !this.isOpened;
    this.isSidebarOpened.next(this.isOpened);
  }

  getSidebar(): Subject<boolean> {
    return this.isSidebarOpened;
  }

  getCategories() {
    return this.http.get(`${Constants.api}/${Constants.menu}/${Constants.getCategories}`);
  }

  getSubCategories(categoryId: string) {
    return this.http.get(`${Constants.api}/${Constants.menu}/${Constants.getSubCategories}?categoryId=${categoryId}`);
  }

  constructor(private http: HttpClient) {
    this.isOpened = false;
    this.isSidebarOpened.next(this.isOpened);  
  }
}
