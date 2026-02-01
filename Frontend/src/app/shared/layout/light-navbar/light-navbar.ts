import { Component } from '@angular/core';

@Component({
  selector: 'app-light-navbar',
  imports: [],
  templateUrl: './light-navbar.html',
})
export class LightNavbar {
  toggleDarkMode() {
    document.documentElement.classList.toggle('dark');
  }
}
