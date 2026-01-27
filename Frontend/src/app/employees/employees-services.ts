import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { EmployeeLeave } from '../reportCenter/leaveBalancesReport/LeaveBalanceModel';

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
    return this.http.get<EmployeeLeave[]>(
      `${this.baseUrl}/LeaveBalances/Report`,
    );
  }
}
