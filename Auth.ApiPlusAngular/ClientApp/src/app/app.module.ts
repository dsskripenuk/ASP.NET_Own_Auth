import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { RegisterComponent } from './auth/Register/Register.component';
import { LoginComponent } from './auth/Login/Login.component';
import { AppRoutingModule } from './app-routing.module';
import { NotifierModule } from 'angular-notifier';


@NgModule({
  declarations: [	
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent
   ],
  imports: [

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NotifierModule.withConfig({

      position: {

        horizontal: {

          position: 'right',

        },

        vertical: {

          position: 'top',

        }

      }

    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
