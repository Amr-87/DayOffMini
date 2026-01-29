import { LeaveBalanceRowDTO } from './LeaveBalanceRowDTO';

export interface LeaveBalancesReportDTO {
  employeeId: number;
  employeeName: string;
  totalDaysOffRemaining: number;
  totalDaysOffBalance: number;
  leaveBalances: LeaveBalanceRowDTO[];
}
