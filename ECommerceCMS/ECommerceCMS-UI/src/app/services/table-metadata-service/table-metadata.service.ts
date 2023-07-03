import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';

@Injectable({
  providedIn: 'root'
})
export class TableMetadataService {

  constructor(private http: HttpClient) { }

  getTableMetadata(tableName: string) {
    let tableMetaData: Array<any> = new Array<any>();
    return this.http.get(`${ Constants.url }/${ Constants.tableMetadata }?tableName=${ tableName }`);
  }
}
