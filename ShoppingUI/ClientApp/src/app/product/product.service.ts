import { Injectable } from "@angular/core";
import { Product } from "../models/Product";
import { Observable, ReplaySubject } from "rxjs";
import {  HttpClient, HttpHeaders } from '@angular/common/http';
import { tap } from 'rxjs/operators'; 
import { JsonPipe } from "@angular/common";
import { RequestOptions } from "@angular/http";

@Injectable({
    providedIn: 'root'
  })
export class ProductService
{
    private productList = new ReplaySubject<Product[]>(1);
    productList$ = this.productList.asObservable();
    private updatedproductList: Product[] = [];
  
    constructor(private http: HttpClient){}
 
    loadProducts(): Observable<Product[]> {
        return this.http.get<Product>("http://localhost:58385/products")
          .pipe(
            tap((product: Product[]) => {  
              this.productList.next(product);
              return this.productList;
            })
          );
      }

      getProduct(id : number): Observable<Product> {
        return this.http.get<Product>("http://localhost:58385/products/" + id)
          .pipe(
            tap((product: Product[]) => {  
              return product;
            })
          );
      }

      addProduct(product: Product): void {
        let HttpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*'
          }
          )
        };

        const header = new HttpHeaders().set('content-type', 'application/json; charset=utf-8');  
        header.set('Access-Control-Allow-Origin', '*');
        var body = product;//JSON.stringify(product);
        // let options = new RequestOptions({ headers: headers })
        
        this.http.post<Product>("http://localhost:58385/products", {product:body}, HttpOptions)
          .subscribe((response: Product) => {
            response = response ? response : product;
            if(response.product_Id > 0)
            {
               this.updatedproductList.push(response);
                this.productList.next(this.updatedproductList);
            }
          });
      }

      deleteProduct(id: number): void {

        this.http.delete("http://localhost:58385/products/"+ id)
          .subscribe(() => {
            const index = this.updatedproductList.findIndex(y => y.product_Id === id);
            if (index > -1) {
              this.updatedproductList.splice(index, 1);
              this.productList.next(this.updatedproductList);
            }
          });
      }

      updateProduct(product: Product): void {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        
        this.http.put<Product>("http://localhost:58385/products" + product.product_Id, {product:product}, {headers : headers})
          .subscribe((response: Product) => {
            response = response ? response : product;
            // if(response.product_Id > 0)
            // {
            //    this.updatedproductList.push(response);
            //     this.productList.next(this.updatedproductList);
            // }
          });
      }
}  