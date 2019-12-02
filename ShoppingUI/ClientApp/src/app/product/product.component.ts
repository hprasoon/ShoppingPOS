import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(    private productService: ProductService  ) 
  { }

  products : Product[]; 
  
  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.loadProducts().subscribe(products => {
      this.products = products;
    });
  }

  deleteProduct(id:number) {
    this.productService.deleteProduct(id);
  }

  editProduct(product:Product)
  {
    
  }
}
