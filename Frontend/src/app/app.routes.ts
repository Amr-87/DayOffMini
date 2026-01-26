import { Routes } from '@angular/router';
import { LoginPage } from './auth/login-page/login-page';
import { authGuard } from './guards/auth-guard';
import { HomeComponent } from './home-component/home-component';

export const routes: Routes = [
  { path: 'login', component: LoginPage },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [authGuard],
  },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];
