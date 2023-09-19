import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {

  @Input() sources: string[] = [];
  selectedItemIndex: number = 0;

  ngOnInit(): void {
  }
  
  left(): void {
    if (this.selectedItemIndex > 0) this.selectedItemIndex--;
    else this.selectedItemIndex = this.sources.length - 1;
  }
  right(): void {
    if (this.selectedItemIndex < this.sources.length - 1) this.selectedItemIndex++;
    else this.selectedItemIndex = 0;
  }
  select(index: number): void {
    this.selectedItemIndex = index;
  }
}
