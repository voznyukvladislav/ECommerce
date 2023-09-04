import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { FilterSet } from 'src/app/data/filter/filterSet';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor(private http: HttpClient) { }

  getSortings() {
    return this.http.get(`${Constants.api}/${Constants.filter}/${Constants.getSortings}`);
  }

  getFilters(subCategoryId: number) {
    return this.http.get(`${Constants.api}/${Constants.filter}/${Constants.getFilters}?subCategoryId=${subCategoryId}`);
  }

  getProducts(filterSet: FilterSet, subCategoryId: number, pageNum: number, pageSize: number) {
    return this.http.post(`${Constants.api}/${Constants.filter}/${Constants.getProducts}?subCategoryId=${subCategoryId}&pageNum=${pageNum}&pageSize=${pageSize}`, filterSet);
  }
}
