import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private router: Router, private http: HttpClient) {}
  login(userData: any) {
    console.log(userData);

    return this.http
      .post<any>('https://localhost:7227/api/UserMaster/login', userData)
      .pipe(
        map((response) => {
          // Assuming the response contains user data including userType
          localStorage.setItem('currentUser', JSON.stringify(response));
          return response;
        }),
        catchError((error) => {
          console.error('Login failed:', error);
          throw error;
        })
      );
  }

  logout() {
    localStorage.removeItem('currentUser');
  }

  getCurrentUser(): any {
    // Retrieve user from local storage
    return JSON.parse(localStorage.getItem('currentUser') || '{}');
  }
}
