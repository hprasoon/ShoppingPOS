import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from 'src/app/models/Product';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  constructor(private productService: ProductService, private route: ActivatedRoute) 
  { }

  product : Product; 
  id : number;

  ngOnInit() {
    this.product =new Product();
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));
    if(this.id > 0)
    {
      this.loadProduct(this.id);
    }
  }

  saveProduct() {
    let newProduct = new Product();
    newProduct = this.product;
    if (!newProduct.hasOwnProperty('product_Id')) {
      newProduct.product_Id = 0;
      this.productService.addProduct(newProduct);
    }
    else {
      this.productService.updateProduct(newProduct);
    }
  }

  loadProduct(id:number) : void
  {
    this.productService.getProduct(id).subscribe(product => {
      this.product = product;
    });
  }
}
