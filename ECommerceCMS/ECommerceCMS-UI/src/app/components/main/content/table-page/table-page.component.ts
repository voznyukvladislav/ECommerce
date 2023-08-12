import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { InputsService } from 'src/app/services/inputs-service/inputs.service';
import { TableDataService } from 'src/app/services/table-data-service/table-data.service';
import { TableMetadataService } from 'src/app/services/table-metadata-service/table-metadata.service';
import { InputDTO } from 'src/app/data/input/input-dto';
import { PopupServiceItem } from 'src/app/data/popup-service-item';
import { PopupService } from 'src/app/services/popup-service/popup.service';
import { LoginService } from 'src/app/services/login-service/login.service';
import { AuthenticationHandler } from 'src/app/data/authentication-handler';
import { MessageService } from 'src/app/services/message-service/message.service';
import { Message } from 'src/app/data/message';

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

  popupServiceItem: PopupServiceItem = new PopupServiceItem();

  inputSearch: InputDTO = new InputDTO();

  private querySub: Subscription;

  constructor(
    private route: ActivatedRoute,
    private tableMetadataService: TableMetadataService,
    private tableDataService: TableDataService,
    private inputsService: InputsService,
    private popupService: PopupService,
    private loginService: LoginService,
    private messageService: MessageService)
    {
      popupService.getPopup().subscribe({
        next: data => {
          this.popupServiceItem = data;
        }
      });

      this.querySub = route.queryParams.subscribe(
        (queryParam: any) => {
          this.tableName = queryParam['tableName'];
        }
      );
      
      route.queryParams.subscribe(
        queryParam => {
          this.loginService.isAuthorized().subscribe({
            error: error => {
              AuthenticationHandler.LogOut(localStorage);
              let message: Message = error.error;
              console.log(message);
              this.messageService.addMessage(message);
            }
          });

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
                });
                i++;
              });
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
      })
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

  openInsertion(): void {
    this.inputsService.getInputBlock(this.tableName).subscribe({
      next: (data: any) => {
        this.popupServiceItem.inputBlockDTO.title = data.title;
        this.popupServiceItem.inputBlockDTO.inputDTOs = data.inputDTOs;
        this.popupServiceItem.inputBlockDTO.inputGroupDTOs = data.inputGroupDTOs;
        this.popupServiceItem.clickFunction = this.insertData.bind(this);

        this.popupService.open(this.popupServiceItem);
      },
      error: (error: any) => {
        console.log(error);
      }
    }) 
  }

  openUpdate(id: string): void {
    this.inputsService.getUpdateInputBlock(this.tableName, id).subscribe({
      next: (data: any) => {
        this.popupServiceItem.inputBlockDTO.title = data.title;
        this.popupServiceItem.inputBlockDTO.inputDTOs = data.inputDTOs;
        this.popupServiceItem.inputBlockDTO.inputGroupDTOs = data.inputGroupDTOs;
        this.popupServiceItem.clickFunction = this.updateData.bind(this);

        this.popupService.open(this.popupServiceItem);
      },
      error: (error: any) => {
        console.log(error);
      }
    });
  }

  private insertData(): void {
  this.tableDataService.insertData(this.popupServiceItem.inputBlockDTO).subscribe({
    next: (data: any) => {
      let message = data;
      Message.registerMessage(message, sessionStorage);      

      location.reload();
    },
    error: (error: any) => {
      let message = error.error;
      this.messageService.addMessage(message);

      if(error.status == 401) {
        AuthenticationHandler.LogOut(localStorage);
        location.reload();
      }
    }
  });
  }

  private updateData(): void {
    this.tableDataService.updateData(this.popupServiceItem.inputBlockDTO).subscribe({
      next: (data: any) => {
        let message = data;
        Message.registerMessage(message, sessionStorage);

        location.reload();
      },
      error: (error: any) => {
        let message = error.error;
        this.messageService.addMessage(message);

        if(error.status == 401) {
          AuthenticationHandler.LogOut(localStorage);
          location.reload();
        }
      }
    })
  }

  deleteData(id: string) {
    let firstLetter = this.tableName[0].toUpperCase();
    let upperTableName = firstLetter + this.tableName.slice(1);
    this.tableDataService.deleteItem(upperTableName, id).subscribe({
      next: (data: any) => {
        let message = data;
        Message.registerMessage(message, sessionStorage);    
        location.reload();
      },
      error: error => {
        let message = error.error;
        this.messageService.addMessage(message);

        if(error.status == 401) {
          AuthenticationHandler.LogOut(localStorage);
          location.reload();
        }
      }
    });
  }

  ngOnInit(): void {
  }
}
