import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header-title',
  templateUrl: './header-title.component.html',
  styleUrls: ['./header-title.component.css']
})
export class HeaderTitleComponent implements OnInit {
  @Input() headerTitle = '';
  isUnderlined: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  underline(): void {
    this.isUnderlined = !this.isUnderlined;
  }
}
