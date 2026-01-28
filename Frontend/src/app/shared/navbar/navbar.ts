import { Component, signal } from '@angular/core';
import { Sidebar } from '../sidebar/sidebar';

@Component({
  selector: 'app-navbar',
  imports: [Sidebar],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class navbar {
  // userName = signal(''); // later get from JWT or API
  darkModeOn = signal(false);
  isMenuOpen = false;

  // constructor(
  //   private authService: AuthService,
  //   private router: Router,
  // ) {}
  // ngOnInit(): void {
  //   this.authService.getUserById(this.authService.getUserId()!).subscribe({
  //     next: (res: any) => {
  //       console.log(res);
  //       this.userName.set(res.name || res.email);
  //       console.log(this.userName());
  //     },
  //   });
  // }
  // logout() {
  //   this.authService.logout();
  //   this.router.navigate(['/login']);
  // }
  toggleDarkMode() {
    document.documentElement.classList.toggle('dark');
    this.darkModeOn.set(!this.darkModeOn());
  }
}
