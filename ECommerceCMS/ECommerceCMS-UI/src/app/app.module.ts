import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

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
import { InputComponent } from './components/main/content/inputs/input/input.component';
import { InputSearchComponent } from './components/main/content/inputs/input-search/input-search.component';
import { FirstToUpperPipe } from './pipes/first-to-upper.pipe';
import { PopupComponent } from './components/main/content/popup/popup.component';
import { InputsHandlerComponent } from './components/main/content/inputs/inputs-handler/inputs-handler.component';
import { InputSimpleComponent } from './components/main/content/inputs/input-simple/input-simple.component';
import { InputOneOfManyComponent } from './components/main/content/inputs/input-one-of-many/input-one-of-many.component';
import { InputManyOfManyComponent } from './components/main/content/inputs/input-many-of-many/input-many-of-many.component';
import { InputSimpleWithSelectorComponent } from './components/main/content/inputs/input-simple-with-selector/input-simple-with-selector.component';
import { InputExtensionalComponent } from './components/main/content/inputs/input-extensional/input-extensional.component';

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
    InputSearchComponent,
    FirstToUpperPipe,
    PopupComponent,
    InputsHandlerComponent,
    InputSimpleComponent,
    InputOneOfManyComponent,
    InputManyOfManyComponent,
    InputSimpleWithSelectorComponent,
    InputExtensionalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
