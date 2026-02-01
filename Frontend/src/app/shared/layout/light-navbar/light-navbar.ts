import { Component } from '@angular/core';

@Component({
  selector: 'app-light-navbar',
  imports: [],
  templateUrl: './light-navbar.html',
  styleUrl: './light-navbar.scss',
})
export class LightNavbar {
  toggleDarkMode() {
    document.documentElement.classList.toggle('dark');
  }
}
