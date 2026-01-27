import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
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
  ],
  templateUrl: './leave-balances-report-page.html',
  styleUrl: './leave-balances-report-page.scss',
})
export class LeaveBalancesReportPage {
  leaveTypes: any[] = [];
}
