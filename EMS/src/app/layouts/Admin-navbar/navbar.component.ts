import { Component } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  constructor(private authService: AuthService, private router: Router) {}
  logout() {
    console.log('Helllo');
    // Call the logout method from AuthService
    this.authService.logout();
    // Navigate to the login page
    this.router.navigate(['/login']);
  }
}
