import { Component, OnInit, ViewChild } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { SimpleDTO } from 'src/app/data/simple-dto';

@Component({
  selector: 'app-input-one-of-many',
  templateUrl: './input-one-of-many.component.html',
  styleUrls: ['./input-one-of-many.component.css']
})
export class InputOneOfManyComponent extends InputComponent implements OnInit {

  @ViewChild("scrollableBlock") scrollableBlock: any;
  currentScrollableItem: any;

  title: string = this.input.placeholders[0];

  items: Array<SimpleDTO> = new Array<SimpleDTO>();
  selectedItem: SimpleDTO = new SimpleDTO("", "");

  pageSize: number = 8;
  pageNumber: number = 1;

  isOpened: boolean = false;

  scrollable: boolean = true;

  override ngOnInit(): void {
    this.title = this.input.placeholders[0];
  }

  search(): void {
    this.isOpened = !this.isOpened;

    if(this.isOpened && this.scrollable) {
      this.selectedItem = new SimpleDTO("", "");
      this.load();
    }
  }

  select(item: SimpleDTO): void {
    // this.items = [];
    this.isOpened = !this.isOpened;
    this.title = `Id: ${item.id}, Name: ${item.name}`;
    this.selectedItem = item;
    this.input.values[0] = this.selectedItem.id.toString();
  }

  scroll(): void {
    if(this.scrollable && this.isElementVisible(this.currentScrollableItem, this.scrollableBlock.nativeElement)) {
      this.currentScrollableItem = undefined;
      this.load();
    }
  }

  isElementVisible(element: any, container: any): boolean {
    let elRect = element.getBoundingClientRect();
    let conRect = container.getBoundingClientRect();

    return (
      elRect.top >= conRect.top &&
      elRect.bottom <= conRect.bottom &&
      elRect.left >= conRect.left &&
      elRect.right <= conRect.right
    );
  }

  load(): void {
    this.http.get(this.input.links[0] + `&pageNum=${this.pageNumber}&pageSize=${this.pageSize}`, { withCredentials: true }).subscribe({
      next: (data: any) => {
        data.forEach((el: any) => {
          this.items.push(new SimpleDTO(el.Id, el.Name));
        });

        if(data.length == this.pageSize) {
          this.scrollable = true;
          this.pageNumber++;
        }
        else {
          this.scrollable = false;  
        }

        setTimeout(() => {
          let lastChild = this.scrollableBlock.nativeElement.lastElementChild;
          lastChild.setAttribute("scrollable", "true");
          this.currentScrollableItem = lastChild;
        }, 10);
      }
    });
  }
}
