import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutusComponent } from './aboutus/aboutus.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { SignupComponent } from './signup/signup.component';
import { ShowadminComponent } from './showadmin/showadmin.component';
//import { AddbookingComponent } from './addbooking/addbooking.component';
 
const routes: Routes = [{path:'',redirectTo:'/home',pathMatch:'full'},
{path:'about',component:AboutusComponent},
{path:'login',component:LoginComponent},
{path:'home',component:HomeComponent},
{path:'signup',component:SignupComponent},
{path:'ShowadminComponent',component:ShowadminComponent},
//{path:'ShowadminComponent/AddbookingComponent',component:AddbookingComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
