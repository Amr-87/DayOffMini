import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { navbar } from '../navbar/navbar';
import { Sidebar } from '../sidebar/sidebar';
import { TrialBar } from '../trial-bar/trial-bar';

@Component({
  selector: 'app-app-layout-component',
  imports: [RouterOutlet, Sidebar, navbar, TrialBar],
  templateUrl: './app-layout-component.html',
})
export class AppLayoutComponent {}
