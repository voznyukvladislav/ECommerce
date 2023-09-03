import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';

@Injectable({
  providedIn: 'root'
})
export class DbDataService {

  constructor(private http: HttpClient) { }

  getSubCategoryParent(subCategoryId: number) {
    return this.http.get(`${Constants.api}/${Constants.data}/${Constants.getSubCategoryParent}?subCategoryId=${subCategoryId}`)
  }

  getSubCategory(subCategoryId: number) {
    return this.http.get(`${Constants.api}/${Constants.data}/${Constants.getSubCategory}?subCategoryId=${subCategoryId}`)
  }
}
