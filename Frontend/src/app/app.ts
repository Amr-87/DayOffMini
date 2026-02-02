import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ErrorModalComponent } from './shared/layout/error-modal-component/error-modal-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ErrorModalComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected readonly title = signal('DayOffMiniFE');
}
