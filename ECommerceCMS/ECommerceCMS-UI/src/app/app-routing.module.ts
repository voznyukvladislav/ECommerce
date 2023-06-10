import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TablePageComponent } from './components/main/content/table-page/table-page.component';
import { ContentComponent } from './components/main/content/content/content.component';

const routes: Routes = [
  { path: '', component: ContentComponent },
  { path: 'table', component: TablePageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
