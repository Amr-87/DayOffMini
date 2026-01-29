import { Injectable, signal } from '@angular/core';
import { LeaveTypeDTO } from '../../leaveTypes/LeaveTypeDTO';

@Injectable({
  providedIn: 'root',
})
export class LeaveBalancesReportService {
  leaveTypes = signal<LeaveTypeDTO[]>([
    { id: 1, name: 'Casual', isDefault: true, color: '#FF5733' },
    { id: 2, name: 'Schedule', isDefault: false, color: '#33FF57' },
    { id: 3, name: 'Mission', isDefault: false, color: '#5733FF' },
  ]);

  generateNiceColor(): string {
    const hue = Math.floor(Math.random() * 360);
    return `hsl(${hue}, 70%, 50%)`;
  }
}
