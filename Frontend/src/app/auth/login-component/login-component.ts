import { Component, signal } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';
import { AuthService } from '../../shared/services/auth-service';

@Component({
  selector: 'app-login-component',
  imports: [FormsModule],
  templateUrl: './login-component.html',
})
export class LoginComponent {
  model = {
    email: '',
    password: '',
  };
  isLoading = signal(false);
  errorMessage = signal<string | null>(null);
  showPassword = false;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  togglePassword() {
    this.showPassword = !this.showPassword;
  }
  clearError(): void {
    this.errorMessage.set(null);
  }
  onSubmit(form: NgForm) {
    if (form.invalid || this.isLoading()) return;
    this.isLoading.set(true);
    this.errorMessage.set(null);

    this.authService
      .login(this.model.email, this.model.password)
      .pipe(finalize(() => this.isLoading.set(false)))
      .subscribe({
        next: (response: any) => {
          this.authService.saveToken(response.token);
          this.router.navigate(['/dashboard']);

          // alert('Logged in successfully');
        },
        error: (err: any) => {
          this.errorMessage.set(
            err.error.message || 'Invalid email or password',
          );
          // console.error('Login error:', err.message);
          // alert(`Login failed: ${error.error.message}`);
        },
      });
  }
}
