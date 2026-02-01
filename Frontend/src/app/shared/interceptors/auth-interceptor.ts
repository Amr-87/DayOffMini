import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // Read the token from local storage
  const token = localStorage.getItem('auth_token');

  // If token exists, clone the request and add Authorization header
  const authReq = token
    ? req.clone({
        headers: req.headers.set('Authorization', `Bearer ${token}`),
      })
    : req;

  // Pass the request to the next handler
  return next(authReq);
};
