import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { InputsService } from 'src/app/services/inputs-service/inputs.service';
import { TableDataService } from 'src/app/services/table-data-service/table-data.service';
import { TableMetadataService } from 'src/app/services/table-metadata-service/table-metadata.service';
import { InputDTO } from 'src/app/data/input/input-dto';

@Component({
  selector: 'app-table-page',
  templateUrl: './table-page.component.html',
  styleUrls: ['./table-page.component.css']
})
export class TablePageComponent implements OnInit {

  tableName: string = '';
  tableMetadata: Array<string> = new Array<string>();
  tableData: Array<Array<string>> = new Array<Array<string>>();

  pageSize: number = 20;
  pageNum: number = 1;
  pagesNum: number = 1;

  inputBlock: InputBlockDTO = new InputBlockDTO();

  inputSearch: InputDTO = new InputDTO();

  insertionPopupIsOpened: boolean = false;
  updatePopupIsOpened: boolean = false;

  private querySub: Subscription;
  constructor(
    private route: ActivatedRoute,
    private tableMetadataService: TableMetadataService,
    private tableDataService: TableDataService,
    private inputsService: InputsService)
    {
      this.querySub = route.queryParams.subscribe(
        (queryParam: any) => {
          this.tableName = queryParam['tableName'];
        }
      );
      
      route.queryParams.subscribe(
        queryParam => {
          let tableName = queryParam['tableName'];
          this.tableMetadataService.getTableMetadata(tableName).subscribe({
            next: data => {
              this.tableMetadata = Object.keys(data);
            }
          });
          this.tableDataService.getTableData(tableName, this.pageNum, this.pageSize).subscribe({
            next: (data: any) => {
              this.tableData = new Array<Array<string>>();
              let i = 0;
              data.forEach((element: any) => {
                this.tableData.push(new Array<string>());
                Object.values(element).forEach((field: any) => {
                  this.tableData[i].push(field);
                })
                i++;
              });

              console.log(this.tableData);
            }
          });
          this.tableDataService.getPagesNumber(tableName, this.pageSize).subscribe({
            next: (data: any) => {
              this.pagesNum = data;
            }
          });
          this.inputSearch = InputDTO.CreateSearch('Name', 'Search something...', this.tableName);
        }
      );
   }

   getLeftPage(): void {
    if(this.pageNum > 1) {
      this.pageNum--;      

      this.tableDataService.getPagesNumber(this.tableName, this.pageSize).subscribe({
        next: (data: any) => {
          this.pagesNum = data;
        }
      });
      this.tableDataService.getTableData(this.tableName, this.pageNum, this.pageSize).subscribe({
        next: (data: any) => {
          this.tableData = new Array<Array<string>>();
              let i = 0;
              data.forEach((element: any) => {
                this.tableData.push(new Array<string>());
                Object.values(element).forEach((field: any) => {
                  this.tableData[i].push(field);
                })
                i++;
              });
        }
      });
    }
   }
   getRightPage(): void {
    if(this.pageNum < this.pagesNum) {
      this.pageNum++;

      this.tableDataService.getPagesNumber(this.tableName, this.pageSize).subscribe({
        next: (data: any) => {
          this.pagesNum = data;
        }
      });      
      this.tableDataService.getTableData(this.tableName, this.pageNum, this.pageSize).subscribe({
        next: (data: any) => {
          this.tableData = new Array<Array<string>>();
              let i = 0;
              data.forEach((element: any) => {
                this.tableData.push(new Array<string>());
                Object.values(element).forEach((field: any) => {
                  this.tableData[i].push(field);
                })
                i++;
              });
          }
      });
    }
   }
   load(): void {
    if(this.pageNum < this.pagesNum) {
      this.pageNum++;

      this.tableDataService.getPagesNumber(this.tableName, this.pageSize).subscribe({
        next: (data: any) => {
          this.pagesNum = data;
        }
      });
  
      this.tableDataService.getTableData(this.tableName, this.pageNum, this.pageSize).subscribe({
        next: (data: any) => {
          //this.tableData = new Array<Array<string>>();
          let i = this.tableData.length;
          data.forEach((element: any) => {
            this.tableData.push(new Array<string>());
            Object.values(element).forEach((field: any) => {
              this.tableData[i].push(field);
            })
            i++;
          });
        }
      });
    }
   }
   insertionPopupInteraction(): void {
    this.insertionPopupIsOpened = !this.insertionPopupIsOpened;
    if(this.insertionPopupIsOpened) {
      this.inputsService.getInputBlock(this.tableName).subscribe({
        next: (data: any) => {
          //console.log(data);
          this.inputBlock.title = data.title;
          this.inputBlock.inputGroupDTOs = data.inputGroupDTOs;
          this.inputBlock.inputDTOs = data.inputDTOs;
          //console.log(this.inputBlock);
        },
        error: (error: any) => {
          console.log(error);
        }
      });
    }    
   }
   updatePopupInteraction(): void {
    this.updatePopupIsOpened = !this.updatePopupIsOpened;
    if(this.updatePopupIsOpened) {
      this.inputsService.getInputBlock(this.tableName).subscribe({
        next: (data: any) => {
          //console.log(data);
          this.inputBlock.title = data.title;
          this.inputBlock.inputGroupDTOs = data.inputGroupDTOs;
          this.inputBlock.inputDTOs = data.inputDTOs;
          //console.log(this.inputBlock);
        },
        error: (error: any) => {
          console.log(error);
        }
      });
    }    
   }

   insertData(inputBlockDTO: InputBlockDTO, tableDataService: TableDataService): void {
    tableDataService.insertData(inputBlockDTO).subscribe({
      next: (response: any) => {
        console.log(response);
        location.reload();
      },
      error: (error: any) => {
        console.log(error);
      }
    });
   }
   updateData(inputBlockDTO: InputBlockDTO, tableDataService: TableDataService): void {
    tableDataService.updateData(inputBlockDTO).subscribe({
      next: (response: any) => {
        console.log(response);
        location.reload();
      },
      error: (error: any) => {
        console.log(error);
      }
    })
   }

   deleteItem(data: string[]) {
    let firstLetter = this.tableName[0].toUpperCase();
    let upperTableName = firstLetter + this.tableName.slice(1);
    this.tableDataService.deleteItem(upperTableName, data[0]).subscribe({
      next: (data: any) => {
        location.reload();
      }
    });
   }
   editItem(data: string[]) {
    this.updatePopupIsOpened = !this.updatePopupIsOpened;
    if(this.updatePopupIsOpened) {
      this.inputsService.getUpdateInputBlock(this.tableName, data[0]).subscribe({
        next: (data: any) => {
          //console.log(data);
          this.inputBlock.title = data.title;
          this.inputBlock.inputGroupDTOs = data.inputGroupDTOs;
          this.inputBlock.inputDTOs = data.inputDTOs;
          //console.log(this.inputBlock);
        },
        error: (error: any) => {
          console.log(error);
        }
      });
    }    
   }
  ngOnInit(): void {
  }
}
