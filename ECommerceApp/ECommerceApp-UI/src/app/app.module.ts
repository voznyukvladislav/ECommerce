import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ContentComponent } from './components/content/content.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { PopupComponent } from './components/popup/popup.component';
import { InputsHandlerComponent } from './components/inputs/inputs-handler/inputs-handler.component';
import { ButtonsHandlerComponent } from './components/buttons-handler/buttons-handler.component';
import { InputSimpleComponent } from './components/inputs/input-simple/input-simple.component';
import { InputPasswordComponent } from './components/inputs/input-password/input-password.component';
import { InputDoublePasswordComponent } from './components/inputs/input-double-password/input-double-password.component';
import { InputParentComponent } from './components/inputs/input-parent/input-parent.component';
import { InputSimpleValidatableComponent } from './components/inputs/input-simple-validatable/input-simple-validatable.component';
import { InputPasswordValidatableComponent } from './components/inputs/input-password-validatable/input-password-validatable.component';
import { InputDoublePasswordValidatableComponent } from './components/inputs/input-double-password-validatable/input-double-password-validatable.component';
import { MessageBoxComponent } from './components/message-box/message-box.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    ContentComponent,
    UserInfoComponent,
    PopupComponent,
    InputsHandlerComponent,
    ButtonsHandlerComponent,
    InputSimpleComponent,
    InputPasswordComponent,
    InputDoublePasswordComponent,
    InputParentComponent,
    InputSimpleValidatableComponent,
    InputPasswordValidatableComponent,
    InputDoublePasswordValidatableComponent,
    MessageBoxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
