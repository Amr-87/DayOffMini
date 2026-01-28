import { Routes } from '@angular/router';
import { LoginPage } from './auth/login-page/login-page';
import { DashboardPage } from './dashboard-page/dashboard-page';
import { authGuard } from './guards/auth-guard';
import { LeaveBalancesReportPage } from './reportCenter/leaveBalancesReport/leave-balances-report-page/leave-balances-report-page';
import { ReportCenterPage } from './reportCenter/report-center-page/report-center-page';
import { NotFoundPage } from './shared/not-found-page/not-found-page';

export const routes: Routes = [
  { path: 'login', component: LoginPage },
  {
    path: 'dashboard',
    component: DashboardPage,
    canActivate: [authGuard],
  },
  {
    path: 'report-center',
    children: [
      { path: '', component: ReportCenterPage },
      { path: 'balances', component: LeaveBalancesReportPage },
    ],
  },
  { path: '', redirectTo: 'login', pathMatch: 'full' },

  { path: '**', component: NotFoundPage },
];
