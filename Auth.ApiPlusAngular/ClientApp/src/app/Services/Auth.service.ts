import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.response';
import { LoginModel } from '../Models/login.model';
import { RegisterModel } from '../Models/register.model';

 @Injectable({
   providedIn: 'root'
 })
 export class AuthService {


 constructor(private http: HttpClient) { }

 baseUrl="/api/Account";

 register(model: RegisterModel): Observable<ApiResponse> {
  return this.http.post<ApiResponse>(this.baseUrl + "/register", model)
 }

 login(model: LoginModel): Observable<ApiResponse> {
  return this.http.post<ApiResponse>(this.baseUrl + "/login", model)
}
}



