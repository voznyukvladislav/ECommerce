import { Component, OnInit, ViewChild } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { SimpleSelectDTO } from 'src/app/data/simple-select-dto';

@Component({
  selector: 'app-input-many-of-many',
  templateUrl: './input-many-of-many.component.html',
  styleUrls: ['./input-many-of-many.component.css']
})
export class InputManyOfManyComponent extends InputComponent implements OnInit {

  @ViewChild("scrollableBlock") scrollableBlock: any;
  currentScrollableItem: any;

  title: string = this.input.placeholders[0];

  items: Array<SimpleSelectDTO> = new Array<SimpleSelectDTO>();

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
      this.load();
    }

    // if(this.items.length == 0) {
    //   this.items = [];    
    //   this.http.get(this.input.links[0] + `&pageNum=${this.pageNumber}&pageSize=${this.pageSize}`, { withCredentials: true }).subscribe({
    //     next: (data: any) => {
    //       data.forEach((el: any) => {
    //         this.items.push(new SimpleSelectDTO(el.Id, el.Name));
    //       });
    //     }
    //   });
    // }    
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
          this.items.push(new SimpleSelectDTO(el.Id, el.Name));
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
