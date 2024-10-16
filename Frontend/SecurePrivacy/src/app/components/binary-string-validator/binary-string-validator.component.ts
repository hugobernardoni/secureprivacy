import { Component } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BinaryStringService } from '../../services/binary-string.service';

@Component({
  selector: 'app-binary-string-validator',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './binary-string-validator.component.html',
  styleUrl: './binary-string-validator.component.css'
})
export class BinaryStringValidatorComponent {
  binaryString: string = '';
  validationMessage: string | null = null;

  constructor(private binaryStringService: BinaryStringService) { }  

  validateBinaryString(): void {
    this.binaryStringService.validateBinaryString(this.binaryString)
      .subscribe({
        next: (response) => {
          this.validationMessage = response.result 
            ? "The binary string is good." 
            : "The binary string is bad."; 
        },
        error: () => {
          this.validationMessage = 'Failed to validate the binary string.';
        }
      });
  }
}