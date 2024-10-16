import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  errorMessage: string = '';

  constructor(private productService: ProductService, private router: Router) {} 
  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getProducts()
      .pipe(
        catchError(error => {
          this.errorMessage = 'Failed to load products.';
          console.error('Error loading products:', error);
          return of([]); 
        })
      )
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }

  editProduct(product: Product): void {
    this.router.navigate(['/products/edit', product.id]); 
  }

  deleteProduct(product: Product): void {
    if (confirm(`Are you sure you want to delete the product "${product.name}"?`)) {
      if (!product.id) {
        console.error('Product ID is missing.');
        return;
      }
      this.productService.deleteProduct(product.id).subscribe({
        next: () => {
          this.loadProducts(); 
          console.log('Product deleted successfully.');
        },
        error: (error) => {
          console.error('Error deleting product:', error);
        }
      });
    }
  }
}
