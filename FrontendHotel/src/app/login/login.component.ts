import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  Username:string="";
  password:string="";
  admin:number=0;
  user:number=0;
  userdata:any;
  invalid=false;
  constructor(private http:HttpClient,private router:Router){}
  Login(){
    if(this.admin==1){
      this.http.get("https://localhost:44324/api/Adminapi/GetAdmin").subscribe(data=>{
        console.log(data as [])
        this.userdata=data as []
        var loggedIn=0;
        for(var admins of this.userdata){
          if(admins.adminName== this.Username && admins.password==this.password){
              this.router.navigate(['/ShowadminComponent'])
              loggedIn=1;
              break;
          }

        }
        if(loggedIn==0){
          console.log("Login Failed");
          this.invalid=true;
        }
      })
    }
    else if(this.user==1){

    }
    else{
      
    }
  }
}
