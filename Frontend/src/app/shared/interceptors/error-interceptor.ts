import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { AuthService } from '../services/auth-service';
import { ErrorService } from '../services/error-service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const errorService = inject(ErrorService);
  const authService = inject(AuthService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      // Handle unauthorized globally
      if (error.status === 401) {
        authService.logout();
      }

      // Show modal error
      errorService.handle(error);

      return throwError(() => error);
    }),
  );
};
