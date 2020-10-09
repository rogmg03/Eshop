import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginviewComponent} from "./loginview/loginview.component";
import {HomeComponent} from "./home/home.component";
import {ContactComponent} from "./contact/contact.component"
import {ShoppingCartComponent} from "./shopping-cart/shopping-cart.component";
import {ProductsComponent} from "./products/products.component";
import {PaymentComponent} from "./payment/payment.component";
import {ConfirmComponent} from "./confirm/confirm.component";
import {ProductDetailComponent} from "./product-detail/product-detail.component";

const routes: Routes = [
  {path: "", pathMatch: "full",redirectTo: "/home"},
  {path: "contact", component: ContactComponent},
  {path: "home", component: HomeComponent},
  {path: "login", component: LoginviewComponent},
  {path: "products", component: ProductsComponent},
  {path: "shop", component: ShoppingCartComponent},
  {path: "payment", component: PaymentComponent},
  {path: "confirm", component: ConfirmComponent},
  {path: "product-detail", component: ProductDetailComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
