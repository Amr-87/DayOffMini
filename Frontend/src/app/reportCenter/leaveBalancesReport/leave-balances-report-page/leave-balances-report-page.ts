import { PercentPipe } from '@angular/common';
import { Component, signal } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterLink } from '@angular/router';
import { LeaveTypeDTO } from '../../../leaveTypes/LeaveTypeDTO';
import { FiltersBar } from '../filters-bar/filters-bar';
import { LeaveBalancesReportTableComponent } from '../leave-balances-report-table-component/leave-balances-report-table-component';
import { ReportFiltersModel } from '../ReportFiltersModel';

@Component({
  selector: 'app-leave-balances-report-page',
  imports: [
    RouterLink,
    LeaveBalancesReportTableComponent,
    FiltersBar,
    MatProgressSpinnerModule,
    PercentPipe,
  ],
  templateUrl: './leave-balances-report-page.html',
  styleUrl: './leave-balances-report-page.scss',
})
export class LeaveBalancesReportPage {
  leaveTypes = signal<LeaveTypeDTO[]>([]);
  Math = Math;
  isAnalyticsOpen = true;

  onLeaveTypesChange(types: LeaveTypeDTO[]) {
    this.leaveTypes.set(types);
  }

  onFilterChange($event: ReportFiltersModel) {
    console.log($event);
  }
}
