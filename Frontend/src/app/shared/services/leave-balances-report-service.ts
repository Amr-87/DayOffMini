import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LeaveBalancesReportService {
  generateNiceColor(): string {
    const hue = Math.floor(Math.random() * 360);
    return `hsl(${hue}, 70%, 50%)`;
  }
}
