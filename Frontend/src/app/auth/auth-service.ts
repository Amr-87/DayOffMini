import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.apiBaseUrl + '/Auth';
  private readonly TOKEN_KEY = 'auth_token';

  constructor(private http: HttpClient) {}

  login(email: string, password: string) {
    return this.http.post(this.baseUrl + '/login', {
      email,
      password,
    });
  }

  getUserById(userId: number) {
    return this.http.get(this.baseUrl + `/user/${userId}`);
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem(this.TOKEN_KEY);
  }

  saveToken(token: string) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  getUserId(): number | null {
    const decoded = this.decodeToken();
    if (!decoded) return null;

    // ASP.NET Core default
    if (decoded.nameid) {
      return Number(decoded.nameid);
    }
    return null;
  }

  logout() {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  private decodeToken(): any | null {
    const token = localStorage.getItem(this.TOKEN_KEY);
    if (!token) return null;

    try {
      const payload = token.split('.')[1];
      const decodedPayload = atob(payload);
      return JSON.parse(decodedPayload);
    } catch {
      return null;
    }
  }
}
