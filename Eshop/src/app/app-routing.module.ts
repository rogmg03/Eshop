import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginviewComponent} from "./loginview/loginview.component";
import {HomeComponent} from "./home/home.component";

const routes: Routes = [
  {path: "", pathMatch: "full",redirectTo: "/home"},
  {path: "home", component: HomeComponent},
  {path: "login", component: LoginviewComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
