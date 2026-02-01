import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { LeaveTypeDTO } from '../models/LeaveTypeDTO';

@Injectable({
  providedIn: 'root',
})
export class LeaveTypesService {
  baseUrl = environment.apiBaseUrl + '/leaveTypes';

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<LeaveTypeDTO[]>(this.baseUrl);
  }
}
