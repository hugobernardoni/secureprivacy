import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BinaryStringService {

  private apiUrl = 'http://localhost:8081/api/binary';  

  constructor(private http: HttpClient) { }

  validateBinaryString(binaryString: string): Observable<{ result: boolean }> {
    return this.http.post<{ result: boolean }>(`${this.apiUrl}/isvalid`, { content: binaryString });
  }
}
