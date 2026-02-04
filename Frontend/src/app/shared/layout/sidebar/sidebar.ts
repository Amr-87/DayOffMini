import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { ClickOutsideDirective } from '../../directives/click-outside-directive';
import { AddNewModalComponent } from '../add-new-modal-component/add-new-modal-component';

@Component({
  selector: 'app-sidebar',
  imports: [
    RouterLink,
    RouterLinkActive,
    AddNewModalComponent,
    ClickOutsideDirective,
  ],
  templateUrl: './sidebar.html',
})
export class Sidebar {
  isPopupOpen = false;

  togglePopup() {
    this.isPopupOpen = !this.isPopupOpen;
  }

  closePopup() {
    this.isPopupOpen = false;
  }
}
