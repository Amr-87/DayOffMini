import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { environment } from '../../../environments/environment';
import { LeaveBalancesReportDTO } from '../../reportCenter/models/LeaveBalancesReportDTO';
import { CreateLeaveRequestDTO } from '../models/create-leave-request-dto';
import { EmployeeDTO } from '../models/employee-dto';

@Injectable({
  providedIn: 'root',
})
export class EmployeesServices {
  baseUrl = environment.apiBaseUrl + '/Employees';

  constructor(private http: HttpClient) {}

  getAllEmployees() {
    return this.http.get<EmployeeDTO[]>(this.baseUrl);
  }

  getEmployeeById(id: number) {
    return this.http.get(this.baseUrl + '/' + id);
  }

  getLeaveBalancesReport() {
    return this.http.get<LeaveBalancesReportDTO[]>(
      `${this.baseUrl}/LeaveBalances/Report`,
    );
  }

  createLeaveRequest(employeeId: number, leaveRequest: CreateLeaveRequestDTO) {
    return this.http
      .post(`${this.baseUrl}/${employeeId}/LeaveRequests`, leaveRequest)
      .pipe(
        catchError((error) => {
          // Extract message or default
          // console.log(error);
          const message =
            error?.error?.error || 'Failed to create leave request';
          return throwError(() => new Error(message));
        }),
      );
  }
}
