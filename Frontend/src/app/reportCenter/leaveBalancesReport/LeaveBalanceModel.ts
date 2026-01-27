export interface LeaveBalance {
  leaveTypeId: number;
  leaveTypeName: string;
  fixedDaysOffBalance: number;
  daysTaken: number;
  daysOffRemaining: number;
}

export interface EmployeeLeave {
  employeeId: number;
  employeeName: string;
  totalDaysOffRemaining: number;
  totalDaysOffBalance: number;
  leaveBalances: LeaveBalance[];
}
