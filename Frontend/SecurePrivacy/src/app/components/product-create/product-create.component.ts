import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  product: Product = new Product();
  successMessage: string | null = null;
  errorMessage: string | null = null;
  isEditMode = false;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const productId = this.route.snapshot.paramMap.get('id');
    if (productId) {
      this.isEditMode = true;
      this.loadProduct(productId);
    }
  }

  loadProduct(id: string): void {
    this.productService.getProductById(id).subscribe({
      next: (data) => {
        this.product = data;
      },
      error: () => {
        this.errorMessage = 'Failed to load product.';
      }
    });
  }

  saveProduct(): void {
    if (this.isEditMode) {
      this.productService.editProduct(this.product).subscribe({
        next: () => {
          this.successMessage = 'Product updated successfully!';
          this.router.navigate(['/products']);
        },
        error: () => {
          this.errorMessage = 'Failed to update product.';
        }
      });
    } else {
      this.productService.createProduct(this.product).subscribe({
        next: () => {
          this.successMessage = 'Product created successfully!';
          this.router.navigate(['/products']);
        },
        error: () => {
          this.errorMessage = 'Failed to create product.';
        }
      });
    }
  }
}
