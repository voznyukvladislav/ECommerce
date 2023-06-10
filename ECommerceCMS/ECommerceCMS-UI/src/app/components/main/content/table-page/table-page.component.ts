import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-table-page',
  templateUrl: './table-page.component.html',
  styleUrls: ['./table-page.component.css']
})
export class TablePageComponent implements OnInit {

  tableName: string = '';
  private querySub: Subscription;
  constructor(private route: ActivatedRoute) {
    this.querySub = route.queryParams.subscribe(
      (queryParam: any) => {
        this.tableName = queryParam['tableName'];
      }
    )

    console.log(route);
   }

  ngOnInit(): void {
  }

}
