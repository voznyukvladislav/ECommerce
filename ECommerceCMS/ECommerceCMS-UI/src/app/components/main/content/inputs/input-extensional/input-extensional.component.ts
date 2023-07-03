import { Component, Input, OnInit } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { SimpleDTO } from 'src/app/data/simple-dto';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { Constants } from 'src/app/data/constants';

@Component({
  selector: 'app-input-extensional',
  templateUrl: './input-extensional.component.html',
  styleUrls: ['./input-extensional.component.css']
})
export class InputExtensionalComponent extends InputComponent implements OnInit {

  @Input() inputBlockDTO: InputBlockDTO = new InputBlockDTO();

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

    this.http.get(`${Constants.url}/${Constants.getInputGroups}?templateId=${this.input.values[0]}`).subscribe({
      next: (data: any) => {
        this.inputBlockDTO.inputGroupDTOs = data;
        console.log(this.inputBlockDTO);
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }
}
