import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import {
  MatProgressSpinnerModule,
  ProgressSpinnerMode,
} from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSliderModule } from '@angular/material/slider';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-report-center-page',
  imports: [
    RouterLink,
    MatCardModule,
    MatRadioModule,
    FormsModule,
    MatSliderModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './report-center-page.html',
})
export class ReportCenterPage {
  mode: ProgressSpinnerMode = 'determinate';
  value = 70;
}
