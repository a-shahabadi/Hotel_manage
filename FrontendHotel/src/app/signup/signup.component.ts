import { Component,OnInit } from '@angular/core';
import {Register} from '../Model/signup.model';
import { SignupService } from '../service/signup.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{
  signupCustomerRequest={
    "customerId": 0,
    "customerName": "string",
    "customerDob": "2023-03-27T19:18:08.546Z",
    "customerAddress": "string",
    "customerContact": 0,
    "customerEmail": "string",
    "age": 0,
    "custpass": "string"
  };
  
   constructor(private registerservice:SignupService,private router:Router,private http:HttpClient){}
   ngOnInit():void{
  
   }
  
   registerUser(){
    console.log(this.signupCustomerRequest)
   console.log(this.signupCustomerRequest)
   this.http.post(this.registerservice.baseUrl+'/api/Customerapi/AddCustomer',this.signupCustomerRequest).subscribe(data=>{console.log(data)})
   this.registerservice.registerCustomer(this.signupCustomerRequest)
   .subscribe(
    data=>{console.log(data)}
    );
  }
    
}
//required [(ngModel)]="signupCustomerRequest.CustomerDob"