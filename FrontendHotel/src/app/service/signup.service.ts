import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Register } from '../Model/signup.model';

@Injectable({
providedIn: 'root'
})

export class SignupService {

 baseUrl:string="http://localhost:44324";

 constructor(private http:HttpClient) { }

 registerCustomer(registerCustomerRequest:any){

 return this.http.post(this.baseUrl+'/api/Customerapi/AddCustomer',registerCustomerRequest as []);
}
}