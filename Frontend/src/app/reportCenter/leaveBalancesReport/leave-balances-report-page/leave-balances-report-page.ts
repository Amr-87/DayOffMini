import { PercentPipe } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterLink } from '@angular/router';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgSelectIconDirective } from '../../../shared/directives/ng-select-icon-directive';
import { LeaveTypeDTO } from '../../../shared/models/LeaveTypeDTO';
import { ReportFiltersModel } from '../../models/ReportFiltersModel';
import { FiltersBar } from '../filters-bar/filters-bar';
import { LeaveBalancesReportTableComponent } from '../leave-balances-report-table-component/leave-balances-report-table-component';

@Component({
  selector: 'app-leave-balances-report-page',
  imports: [
    RouterLink,
    LeaveBalancesReportTableComponent,
    FiltersBar,
    MatProgressSpinnerModule,
    PercentPipe,
    NgSelectModule,
    FormsModule,
    NgSelectIconDirective,
  ],
  templateUrl: './leave-balances-report-page.html',
  styleUrl: './leave-balances-report-page.scss',
})
export class LeaveBalancesReportPage {
  leaveTypes = signal<LeaveTypeDTO[]>([]);
  Math = Math;
  isAnalyticsOpen = true;

  years = ['Last Year', 'This Year', 'Next Year'];
  selectedYear = 'This Year';

  onLeaveTypesChange(types: LeaveTypeDTO[]) {
    this.leaveTypes.set(types);
  }

  onFilterChange($event: ReportFiltersModel) {
    console.log($event);
  }

  onYearChange(year: string) {
    console.log('Selected year:', year);
  }
}
