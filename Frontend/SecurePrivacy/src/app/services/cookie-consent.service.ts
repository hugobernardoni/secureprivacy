import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CookieConsentService {
  private cookieConsentKey = 'cookie_consent';
  private apiUrl = 'http://localhost:8081/api/cookie';  

  constructor(private http: HttpClient) { }

  setConsent(consent: boolean): void {
    localStorage.setItem(this.cookieConsentKey, JSON.stringify(consent));
    this.sendConsentToApi(consent).subscribe();
  }

  hasConsented(): boolean {
    const consent = localStorage.getItem(this.cookieConsentKey);
    return consent ? JSON.parse(consent) : false;
  }

  sendConsentToApi(consent: boolean): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/set-consent`, consent);
}
}
