import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  sidebarIsHovered: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  sidebarHover(): void {
    this.sidebarIsHovered = !this.sidebarIsHovered;
  }

}
