import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router
    , private apiService: ApiService) { }

  canActivate() {
    // Check to see if a user has a valid token
    if (!this.apiService.loginRequired) {
      return true;
    }

    this.router.navigate(['/']);
    return false;
  }
}
