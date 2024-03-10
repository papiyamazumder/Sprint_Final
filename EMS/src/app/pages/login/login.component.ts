import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  userId: string;
  password: string;

  constructor(private authService: AuthService, private router: Router) {
    this.userId = '';
    this.password = '';
  }

  submitFunction(userType: string) {
    const userData = {
      userId: this.userId,
      password: this.password,
      userType: userType,
    };
    console.log(userData);
    this.authService.login(userData).subscribe(
      (response: any) => {
        // console.log(response);
        if (userData.userType === 'AU') {
          // Check userType against 'SU' for Admin
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/user']);
        }
      },
      (error: any) => {
        console.error('Login failed:', error);
        // Handle login error
      }
    );
  }
}
