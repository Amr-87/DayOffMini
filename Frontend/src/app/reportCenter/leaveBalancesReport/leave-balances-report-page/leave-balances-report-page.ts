import { PercentPipe } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterLink } from '@angular/router';
import { LeaveTypeDTO } from '../../../leaveTypes/LeaveTypeDTO';
import { LeaveBalancesReportService } from '../../_services/leave-balances-report-service';
import { LeaveBalancesReportTableComponent } from '../leave-balances-report-table-component/leave-balances-report-table-component';
import { LeavePolicyMultiSelectDropdownComponent } from '../leave-policy-multi-select-dropdown-component/leave-policy-multi-select-dropdown-component';
import { LocationMultiSelectDropdownComponent } from '../location-multi-select-dropdown-component/location-multi-select-dropdown-component';
import { TeamDropdownComponent } from '../team-dropdown-component/team-dropdown-component';

@Component({
  selector: 'app-leave-balances-report-page',
  imports: [
    RouterLink,
    LeaveBalancesReportTableComponent,
    TeamDropdownComponent,
    LocationMultiSelectDropdownComponent,
    LeavePolicyMultiSelectDropdownComponent,
    MatProgressSpinnerModule,
    PercentPipe,
  ],
  templateUrl: './leave-balances-report-page.html',
  styleUrl: './leave-balances-report-page.scss',
})
export class LeaveBalancesReportPage implements OnInit {
  reportService = inject(LeaveBalancesReportService);
  leaveTypes = signal<LeaveTypeDTO[]>([]);
  Math = Math;
  isAnalyticsOpen = true;

  ngOnInit(): void {
    this.leaveTypes = this.reportService.leaveTypes;
  }
}
