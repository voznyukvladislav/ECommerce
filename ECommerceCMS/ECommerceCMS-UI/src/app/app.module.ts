import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/main/sidebar/sidebar/sidebar.component';
import { ContentComponent } from './components/main/content/content/content.component';
import { MainComponent } from './components/main/main/main.component';
import { SidebarItemComponent } from './components/main/sidebar/sidebar-item/sidebar-item.component';
import { SidebarSubItemComponent } from './components/main/sidebar/sidebar-sub-item/sidebar-sub-item.component';
import { HeaderTitleComponent } from './components/header/header-title/header-title.component';
import { TablePageComponent } from './components/main/content/table-page/table-page.component';
import { InputComponent } from './components/main/content/input/input.component';
import { InputSearchComponent } from './components/main/content/input-search/input-search.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    ContentComponent,
    MainComponent,
    SidebarItemComponent,
    SidebarSubItemComponent,
    HeaderTitleComponent,
    TablePageComponent,
    InputComponent,
    InputSearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
