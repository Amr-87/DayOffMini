import { HttpErrorResponse } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ErrorService {
  private _error = signal<string | null>(null);

  error = this._error.asReadonly();

  show(message: string) {
    this._error.set(message);
  }

  clear() {
    this._error.set(null);
  }

  handle(error: HttpErrorResponse) {
    // console.log(error);
    let message =
      error.error?.error ||
      error.message ||
      'Something went wrong. Please try again.';

    if (error instanceof HttpErrorResponse) {
      if (error.status === 0) {
        message = 'Network error. Please check your internet connection.';
      } else if (error.status === 401) {
        message = 'Your session has expired. Please log in again.';
      } else if (error.status === 403) {
        message = 'You do not have permission to perform this action.';
      } else if (error.error?.message) {
        message = error.error.message;
      }
    }

    this.show(message);
  }
}
