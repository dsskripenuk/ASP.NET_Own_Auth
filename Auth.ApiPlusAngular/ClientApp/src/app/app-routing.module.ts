import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { LoginComponent } from './auth/Login/Login.component';
import { RegisterComponent } from './auth/Register/Register.component';
import { HomeComponent } from './home/home.component';



const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'login', pathMatch: 'full', component: LoginComponent },
     { path: 'register', pathMatch: 'full', component: RegisterComponent },
];



@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]

})



export class AppRoutingModule { }