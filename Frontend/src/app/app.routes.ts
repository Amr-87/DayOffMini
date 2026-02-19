import { Routes } from '@angular/router';
import { LoginPage } from './auth/login-page/login-page';
import { DashboardPage } from './dashboard-page/dashboard-page';
import { InviteEmployeePage } from './employees/invite-employee-page/invite-employee-page';
import { CreateLeaveRequestPage } from './leaveRequests/create-leave-request-page/create-leave-request-page';
import { LeaveBalancesReportPage } from './reportCenter/leaveBalancesReport/leave-balances-report-page/leave-balances-report-page';
import { ReportCenterPage } from './reportCenter/report-center-page/report-center-page';
import { authGuard } from './shared/guards/auth-guard';
import { AppLayoutComponent } from './shared/layout/app-layout-component/app-layout-component';
import { AuthLayoutComponent } from './shared/layout/auth-layout-component/auth-layout-component';
import { NotFoundPage } from './shared/layout/not-found-page/not-found-page';

export const routes: Routes = [
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginPage },
    ],
  },

  {
    path: '',
    component: AppLayoutComponent,
    canActivateChild: [authGuard],
    children: [
      { path: 'dashboard', component: DashboardPage },
      {
        path: 'report-center',
        children: [
          { path: '', component: ReportCenterPage },
          { path: 'balances', component: LeaveBalancesReportPage },
        ],
      },
      { path: 'request-employee', component: CreateLeaveRequestPage },
      { path: 'invite-employees', component: InviteEmployeePage },
    ],
  },

  { path: '**', component: NotFoundPage },
];
