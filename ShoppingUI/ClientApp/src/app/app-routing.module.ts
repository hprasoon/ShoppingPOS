import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProductComponent } from './product/product.component';
import { AddProductComponent } from './product/add-product/add-product.component';

const routes: Routes =
  [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: 'products', component: ProductComponent },
    { path:'addproduct', component: AddProductComponent },
    { path:'editProduct/:id', component: AddProductComponent },    
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
