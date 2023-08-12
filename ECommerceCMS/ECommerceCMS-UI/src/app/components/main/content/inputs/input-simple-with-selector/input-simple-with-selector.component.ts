import { Component, OnInit } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { SimpleDTO } from 'src/app/data/simple-dto';

@Component({
  selector: 'app-input-simple-with-selector',
  templateUrl: './input-simple-with-selector.component.html',
  styleUrls: ['./input-simple-with-selector.component.css']
})
export class InputSimpleWithSelectorComponent extends InputComponent implements OnInit {

  title: string = '';
  items: Array<SimpleDTO> = [];
  selectedItem: SimpleDTO = new SimpleDTO('', '');
  isOpened: boolean = false;

  override ngOnInit(): void {
    this.title = this.input.placeholders[1];
  }

  search() {
    this.isOpened = !this.isOpened;
    if(this.items.length == 0) {
      this.http.get(this.input.links[0], { withCredentials: true }).subscribe({
        next: (data: any) => {
          data.forEach((element: any) => {
            this.items.push(element);
          });
        },
        error: error => {
          console.log(error);
        }
      })
    }
  }
  select(item: SimpleDTO) {
    this.selectedItem = item;
    this.input.values[2] = this.selectedItem.id.toString();
    this.title = `${this.selectedItem.name}`;
    this.isOpened = !this.isOpened;
  }
}
