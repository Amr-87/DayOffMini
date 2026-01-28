import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { navbar } from './shared/navbar/navbar';
import { Sidebar } from './shared/sidebar/sidebar';
import { TrialBar } from './shared/trial-bar/trial-bar';

@Component({
  selector: 'app-root',
  imports: [navbar, RouterOutlet, Sidebar, TrialBar],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected readonly title = signal('DayOffMiniFE');
}
