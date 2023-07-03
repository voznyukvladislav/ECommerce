import { Component, OnInit } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { SimpleDTO } from 'src/app/data/simple-dto';

@Component({
  selector: 'app-input-one-of-many',
  templateUrl: './input-one-of-many.component.html',
  styleUrls: ['./input-one-of-many.component.css']
})
export class InputOneOfManyComponent extends InputComponent implements OnInit {

  title: string = this.input.placeholders[0];

  items: Array<SimpleDTO> = new Array<SimpleDTO>();
  selectedItem: SimpleDTO = new SimpleDTO("", "");

  pageSize: number = 20;
  pageNumber: number = 1;

  isOpened: boolean = false;

  override ngOnInit(): void {
    this.title = this.input.placeholders[0];
  }

  search(): void {
    this.isOpened = !this.isOpened;

    this.selectedItem = new SimpleDTO("", "");
    this.items = [];
    
    this.http.get(this.input.links[0] + `&pageSize=${this.pageSize}&pageNumber=${this.pageNumber}`).subscribe({
      next: (data: any) => {
        data.forEach((el: any) => {
          this.items.push(new SimpleDTO(el.Id, el.Name));
        });
      }
    });
  }
  select(item: SimpleDTO): void {
    this.items = [];
    this.isOpened = !this.isOpened;
    this.title = `Id: ${item.id}, Name: ${item.name}`;
    this.selectedItem = item;
    this.input.values[0] = this.selectedItem.id.toString();
  }
}
