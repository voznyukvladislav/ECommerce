import { Component, OnInit, Input } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { TableDataService } from 'src/app/services/table-data-service/table-data.service';
import { SimpleDTO } from 'src/app/data/simple-dto';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-input-search',
  templateUrl: './input-search.component.html',
  styleUrls: ['./input-search.component.css']
})
export class InputSearchComponent extends InputComponent implements OnInit {

  items: Array<SimpleDTO> = new Array<SimpleDTO>();
  selectedItem: SimpleDTO = new SimpleDTO("", "");

  override ngOnInit(): void {}

  search(): void {
    console.log(this.input);

    this.selectedItem = new SimpleDTO("", "");
    this.items = [];
    if(this.input.values[0] && !isNaN(Number(this.input.values[0]))) {
      this.http.get(this.input.links[0] + `&input=${this.input.values[0]}`).subscribe({
        next: (data: any) => {
          data.forEach((el: any) => {
            this.items.push(new SimpleDTO(el.Id, el.Name));
          });
        }
      });
    }
  }
  select(item: SimpleDTO): void {
    this.items = [];
    this.selectedItem = item;
    this.input.values[0] = this.selectedItem.output();
  }
}
