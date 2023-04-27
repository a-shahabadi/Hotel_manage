import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
  selector: 'app-showadmin',
  templateUrl: './showadmin.component.html',
  styleUrls: ['./showadmin.component.css']
})
export class ShowadminComponent {
  hotels:any=[];
  cus:any=[];
  constructor(private http:HttpClient,private router:Router){}
  
  ngOnInit(): void {
  
  this.http.get("https://localhost:44324/api/Bookingapi/GetEmployee").subscribe(
  
  (data)=>{
   console.log(data);
   this.hotels=data;
  });
  this.http.get(" https://localhost:44324/api/Customerapi/GetCustomer").subscribe(
  
  (data)=>{
   console.log(data);
   this.cus=data;
  });

  

  }
  Del(Id:number){
    
    this.http.delete(" https://localhost:44324/api/Bookingapi/Delete/"+Id).subscribe(data=>{
      this.ngOnInit();
    })
  
  }
}
