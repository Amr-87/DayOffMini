import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LeaveBalancesReportDTO } from '../reportCenter/leaveBalancesReport/LeaveBalancesReportDTO';

@Injectable({
  providedIn: 'root',
})
export class EmployeesServices {
  baseUrl = environment.apiBaseUrl + '/employees';

  constructor(private http: HttpClient) {}

  getEmployeeById(id: number) {
    return this.http.get(this.baseUrl + '/' + id);
  }

  getLeaveBalancesReport() {
    return this.http.get<LeaveBalancesReportDTO[]>(
      `${this.baseUrl}/LeaveBalances/Report`,
    );
  }
}
