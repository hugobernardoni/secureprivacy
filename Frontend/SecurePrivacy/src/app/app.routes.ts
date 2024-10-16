import { Routes } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductCreateComponent } from './components/product-create/product-create.component';
import { BinaryStringValidatorComponent } from './components/binary-string-validator/binary-string-validator.component';


export const routes: Routes = [
    { path: 'products', component: ProductListComponent },
    { path: 'binary', component: BinaryStringValidatorComponent },
    { path: 'products/create', component: ProductCreateComponent },
    { path: 'products/edit/:id', component: ProductCreateComponent },
    { path: '', redirectTo: '/products', pathMatch: 'full' }
    
  ];