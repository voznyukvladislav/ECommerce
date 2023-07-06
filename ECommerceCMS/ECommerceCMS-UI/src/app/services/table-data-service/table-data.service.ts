import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { InputBlockDTO } from 'src/app/data/input/input-block';
import { InputDTO } from 'src/app/data/input/input-dto';
import { InputGroupDTO } from 'src/app/data/input/input-group-dto';

@Injectable({
  providedIn: 'root'
})
export class TableDataService {

  constructor(private http: HttpClient) { }

  getTableData(tableName: string, pageNum: number, pageSize: number) {
    return this.http.get(`${Constants.url}/${Constants.tableData}?tableName=${tableName}&pageNum=${pageNum}&pageSize=${pageSize}`);
  }
  getPagesNumber(tableName: string, pageSize: number) {
    return this.http.get(`${Constants.url}/${Constants.pagesNumber}?tableName=${tableName}&pageSize=${pageSize}`);
  }
  getSearchResults(tableName: string, input: string) {
    return this.http.get(`${Constants.url}/${Constants.tableSearchResult}?tableName=${tableName}&input=${input}`);
  }

  insertData(inputBlock: InputBlockDTO) {
    let headers = new HttpHeaders();
    //headers.set('Content-Type', 'application/json');
    if(!inputBlock.inputGroupDTOs) {
      console.log("before", inputBlock);

      TableDataService.addEmptyData(inputBlock);

      inputBlock.inputGroupDTOs = new Array<InputGroupDTO>();
      inputBlock.inputGroupDTOs.push(new InputGroupDTO());

      inputBlock.inputGroupDTOs[0].commonName = "";
      inputBlock.inputGroupDTOs[0].commonValue = "";      
      inputBlock.inputGroupDTOs[0].inputDTOs = new Array<InputDTO>();
      inputBlock.inputGroupDTOs[0].inputDTOs.push(new InputDTO);

      inputBlock.inputGroupDTOs[0].inputDTOs[0].type = '';
      inputBlock.inputGroupDTOs[0].inputDTOs[0].links = new Array<string>();
      inputBlock.inputGroupDTOs[0].inputDTOs[0].names = new Array<string>();
      inputBlock.inputGroupDTOs[0].inputDTOs[0].placeholders = new Array<string>();
      inputBlock.inputGroupDTOs[0].inputDTOs[0].values = new Array<string>();

      inputBlock.inputGroupDTOs[0].inputDTOs[0].links.push("");
      inputBlock.inputGroupDTOs[0].inputDTOs[0].names.push("");
      inputBlock.inputGroupDTOs[0].inputDTOs[0].placeholders.push("");
      inputBlock.inputGroupDTOs[0].inputDTOs[0].values.push("");

      console.log("after", inputBlock);
    }
    headers.set('Accept', "application/json");
    return this.http.post(`${Constants.url}/${Constants.insertData}`, inputBlock, {headers: { 'Content-Type': 'application/json' }});
  }
  updateData(inputBlock: InputBlockDTO) {
    let headers = new HttpHeaders();
    //headers.set('Content-Type', 'application/json');
    if(!inputBlock.inputGroupDTOs) {
      console.log("before", inputBlock);

      TableDataService.addEmptyData(inputBlock);

      inputBlock.inputGroupDTOs = new Array<InputGroupDTO>();
      inputBlock.inputGroupDTOs.push(new InputGroupDTO());

      inputBlock.inputGroupDTOs[0].commonName = "";
      inputBlock.inputGroupDTOs[0].commonValue = "";      
      inputBlock.inputGroupDTOs[0].inputDTOs = new Array<InputDTO>();
      inputBlock.inputGroupDTOs[0].inputDTOs.push(new InputDTO);

      inputBlock.inputGroupDTOs[0].inputDTOs[0].type = '';
      inputBlock.inputGroupDTOs[0].inputDTOs[0].links = new Array<string>();
      inputBlock.inputGroupDTOs[0].inputDTOs[0].names = new Array<string>();
      inputBlock.inputGroupDTOs[0].inputDTOs[0].placeholders = new Array<string>();
      inputBlock.inputGroupDTOs[0].inputDTOs[0].values = new Array<string>();

      inputBlock.inputGroupDTOs[0].inputDTOs[0].links.push("");
      inputBlock.inputGroupDTOs[0].inputDTOs[0].names.push("");
      inputBlock.inputGroupDTOs[0].inputDTOs[0].placeholders.push("");
      inputBlock.inputGroupDTOs[0].inputDTOs[0].values.push("");

      console.log("after", inputBlock);
    }
    headers.set('Accept', "application/json");
    return this.http.put(`${Constants.url}/${Constants.updateData}`, inputBlock, {headers: { 'Content-Type': 'application/json' }});
  }

  deleteItem(tableName: string, id: string) {
    return this.http.delete(`${Constants.url}/${Constants.deleteData}?tableName=${tableName}&id=${id}`);
  }

  private static addEmptyData(inputBlock: InputBlockDTO) {
    inputBlock.inputDTOs.forEach(i => {
      if(i.links.length == 0) i.links.push("");
      if(i.names.length == 0) i.names.push("");
      if(i.placeholders.length == 0) i.placeholders.push("");
      if(i.values.length == 0) i.values.push("");
    });
  }
}
