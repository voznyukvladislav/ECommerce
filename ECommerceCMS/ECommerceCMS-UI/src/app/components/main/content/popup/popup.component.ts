import { Component, EventEmitter, Output, OnInit, Input } from '@angular/core';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { TableDataService } from 'src/app/services/table-data-service/table-data.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent implements OnInit {
  @Input() inputBlockDTO: InputBlockDTO = new InputBlockDTO();

  @Input() click: Function = (inputBlock: InputBlockDTO, tableDataService: TableDataService) => {
    console.log("click");
  }

  @Output() onPopupInteraction = new EventEmitter<boolean>();
  isOpened: boolean = true;

  constructor(public tableDataService: TableDataService) { }
  
  popupInteraction() {
    this.onPopupInteraction.emit();
    this.isOpened = !this.isOpened;
  }
  
  ngOnInit(): void {
  }

}
