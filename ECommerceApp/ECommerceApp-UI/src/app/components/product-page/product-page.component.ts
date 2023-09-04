import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FilterSet } from 'src/app/data/filter/filterSet';
import { ProductSimple } from 'src/app/data/productSimple';
import { Sorting } from 'src/app/data/sorting';
import { DbDataService } from 'src/app/services/db-data-service/db-data.service';
import { FilterService } from 'src/app/services/filter-service/filter.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  productsSimple: ProductSimple[] = [];

  pageSize: number = 10;

  pageNum: number = 1;

  sortings: Sorting[] = [];

  pathway: string = "";

  filterSet: FilterSet = new FilterSet();

  subCategoryId: any;

  constructor(
    private route: ActivatedRoute,
    private dbDataService: DbDataService,
    private filterService: FilterService) {
    
    // Route depending queries
    this.route.queryParams.subscribe({
      next: (params: any) => {
        let subCategoryId = params.subCategoryId;
        this.subCategoryId = subCategoryId;
        // Pathway
        this.dbDataService.getSubCategoryParent(subCategoryId).subscribe({
          next: (category: any) => {
            this.dbDataService.getSubCategory(subCategoryId).subscribe({
              next: (subCategory: any) => {
                this.pathway = `${category.name} / ${subCategory.name}`;
                console.log(this.pathway);
              }
            });
          }
        });

        // Receiving filter set
        this.filterService.getFilters(subCategoryId).subscribe({
          next: (data: any) => {
            this.filterSet = data;
            console.log(this.filterSet);
            this.filterService.getProducts(this.filterSet, subCategoryId, this.pageNum, this.pageSize).subscribe({
              next: (data: any) => {
                this.productsSimple = data;
                console.log(this.productsSimple);
              }
            });
          }
        });
      }
    });

    this.filterService.getSortings().subscribe({
      next: (sortings: any) => {
        this.sortings = sortings;
        console.log(this.sortings);
      }
    })
  }

  selectSorting(index: number) {
    this.sortings.forEach(s => {
      s.isSelected = false;
    });

    this.filterSet.sortingType = this.sortings[index].name;
    this.sortings[index].isSelected = true;

    this.pageNum = 1;

    this.getProducts();
  }

  getProducts() {
    this.pageNum = 1;
    this.filterService.getProducts(this.filterSet, this.subCategoryId, this.pageNum, this.pageSize).subscribe({
      next: (data: any) => {
        this.productsSimple = data;
        console.log(this.productsSimple);
      }
    });
  }

  load() {
    this.pageNum++;
    this.filterService.getProducts(this.filterSet, this.subCategoryId, this.pageNum, this.pageSize).subscribe({
      next: (data: any) => {
        this.productsSimple = this.productsSimple.concat(data);
        console.log(this.productsSimple);
      }
    });
  }

  debug() {
    console.log(this.filterSet);
  }

  ngOnInit(): void {
  }
}
