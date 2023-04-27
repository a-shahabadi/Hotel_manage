import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { LogoutComponent } from './logout/logout.component';
import { SignupComponent } from './signup/signup.component';
import { ShowadminComponent } from './showadmin/showadmin.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { AddbookingComponent } from './addbooking/addbooking.component';

//import { BindingComponent } from './binding/binding.component';



@NgModule({
  declarations: [
    AppComponent,
    AboutusComponent,
    LoginComponent,
    HomeComponent,
    LogoutComponent,
    SignupComponent,
    ShowadminComponent,
   // AddbookingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
