import { Component } from '@angular/core';
import { CookieConsentService } from '../../services/cookie-consent.service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-cookie-consent-banner',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cookie-consent-banner.component.html',
  styleUrls: ['./cookie-consent-banner.component.css']
})
export class CookieConsentBannerComponent {
  isVisible = true;

  constructor(private cookieConsentService: CookieConsentService) {
    this.isVisible = !this.cookieConsentService.hasConsented();
  }

  acceptCookies(): void {
    this.cookieConsentService.setConsent(true);
    this.isVisible = false;
  }

  rejectCookies(): void {
    this.cookieConsentService.setConsent(false);
    this.isVisible = false;
  }
}
