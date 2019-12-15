import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable, ReplaySubject } from "rxjs";
import { tap } from 'rxjs/operators';
import { Product } from "../models/Product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private productList = new ReplaySubject<Product[]>(1);
  productList$ = this.productList.asObservable();
  private updatedproductList: Product[] = [];

  constructor(private http: HttpClient) { }

  loadProducts(): Observable<Product[]> {
    return this.http.get<Product>("http://localhost:58385/products")
      .pipe(
        tap((product: Product[]) => {
          this.productList.next(product);
          return this.productList;
        })
      );
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>("http://localhost:58385/products/" + id)
      .pipe(
        tap((product: Product[]) => {
          return product;
        })
      );
  }

  addProduct(product: Product): void {
    this.http.post<Product>("http://localhost:58385/products", product)
      .subscribe((response: Product) => {
        response = response ? response : product;
        if (response.product_Id > 0) {
          this.updatedproductList.push(response);
          this.productList.next(this.updatedproductList);
        }
      });
  }

  deleteProduct(id: number): void {

    this.http.delete("http://localhost:58385/products/" + id)
      .subscribe(() => {
        const index = this.updatedproductList.findIndex(y => y.product_Id === id);
        if (index > -1) {
          this.updatedproductList.splice(index, 1);
          this.productList.next(this.updatedproductList);
        }
      });
  }

  updateProduct(product: Product): void {
    this.http.put<Product>("http://localhost:58385/products/" + product.product_Id, product)
      .subscribe((response: Product) => {
        response = response ? response : product;
        this.updatedproductList.find(x=>x.product_Id == response.product_Id)[0];
        // if(response.product_Id > 0)
        // {
        //    this.updatedproductList.push(response);
        //     this.productList.next(this.updatedproductList);
        // }
      });
  }
}  
