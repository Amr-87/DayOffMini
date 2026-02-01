import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/services/auth-service';

@Component({
  selector: 'app-login-component',
  imports: [FormsModule],
  templateUrl: './login-component.html',
  styleUrl: './login-component.scss',
})
export class LoginComponent {
  model = {
    email: '',
    password: '',
  };

  isLoading = signal(false);
  showPassword = false;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  togglePassword() {
    this.showPassword = !this.showPassword;
  }

  onSubmit(form: any) {
    if (form.invalid) {
      return;
    }

    this.isLoading.set(true);
    this.authService.login(this.model.email, this.model.password).subscribe({
      next: (response) => {
        this.isLoading.set(false);
        this.authService.saveToken((response as any).token);
        this.router.navigate(['/dashboard']);

        alert('Logged in successfully');
      },
      error: (error) => {
        // console.error('Login error:', error);
        this.isLoading.set(false);
        alert(`Login failed: ${error.error.message}`);
      },
    });
  }
}
