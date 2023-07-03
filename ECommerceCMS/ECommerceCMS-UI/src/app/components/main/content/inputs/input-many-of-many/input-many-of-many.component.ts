import { Component, OnInit } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { SimpleSelectDTO } from 'src/app/data/simple-select-dto';

@Component({
  selector: 'app-input-many-of-many',
  templateUrl: './input-many-of-many.component.html',
  styleUrls: ['./input-many-of-many.component.css']
})
export class InputManyOfManyComponent extends InputComponent implements OnInit {

  title: string = this.input.placeholders[0];

  items: Array<SimpleSelectDTO> = new Array<SimpleSelectDTO>();

  pageSize: number = 20;
  pageNumber: number = 1;

  isOpened: boolean = false;

  override ngOnInit(): void {
    this.title = this.input.placeholders[0];
  }

  search(): void {
    this.isOpened = !this.isOpened;

    if(this.items.length == 0) {
      this.items = [];    
      this.http.get(this.input.links[0] + `&pageSize=${this.pageSize}&pageNumber=${this.pageNumber}`).subscribe({
        next: (data: any) => {
          data.forEach((el: any) => {
            this.items.push(new SimpleSelectDTO(el.Id, el.Name));
          });
        }
      });
    }    
  }

  select(item: SimpleSelectDTO): void {
    item.changeState();

    let value = "";
    this.items.forEach(i => {
      if(i.isSelected) value += `${i.id} `;
    });

    // Remove last space
    value = value.slice(0, value.length - 1);
    this.input.values[0] = value;
  }

}
