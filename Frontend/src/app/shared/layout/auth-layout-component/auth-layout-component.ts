import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LightNavbar } from '../light-navbar/light-navbar';

@Component({
  selector: 'app-auth-layout-component',
  imports: [RouterOutlet, LightNavbar],
  templateUrl: './auth-layout-component.html',
})
export class AuthLayoutComponent {}
