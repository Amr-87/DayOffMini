import { Location } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { CreateLeaveRequestDTO } from '../../shared/models/create-leave-request-dto';
import { EmployeeDTO } from '../../shared/models/employee-dto';
import { LeaveTypeDTO } from '../../shared/models/LeaveTypeDTO';
import { AuthService } from '../../shared/services/auth-service';
import { EmployeesServices } from '../../shared/services/employees-services';
import { LeaveTypesService } from '../../shared/services/leave-types-service';

@Component({
  selector: 'app-create-leave-request-page',
  standalone: true,
  imports: [FormsModule, NgSelectModule],
  templateUrl: './create-leave-request-page.html',
  styleUrl: './create-leave-request-page.scss',
})
export class CreateLeaveRequestPage implements OnInit {
  // userId: number | null = null;
  employees: EmployeeDTO[] = [];
  leaveTypes: LeaveTypeDTO[] = [];
  employeeId = signal<number | undefined>(undefined);

  // Signals
  leaveRequest = signal<CreateLeaveRequestDTO>({
    leaveTypeId: 0,
    durationInDays: 0,
    startDate: this.formatDate(new Date()),
    endDate: this.formatDate(new Date()),
    reason: '',
  });

  halfDay = signal(false);
  errorMessage = signal<string | undefined>(undefined);

  constructor(
    private location: Location,
    private leaveTypesService: LeaveTypesService,
    private authService: AuthService,
    private employeesService: EmployeesServices,
  ) {}

  ngOnInit(): void {
    this.employeesService
      .getAllEmployees()
      .subscribe((emps) => (this.employees = emps));

    this.leaveTypesService.getAll().subscribe((types) => {
      this.leaveTypes = types;

      // Set default leaveTypeId safely
      if (this.leaveTypes.length > 0) {
        this.leaveRequest.update((lr) => ({
          ...lr,
          leaveTypeId: this.leaveTypes[0].id,
        }));
      }
    });

    // this.userId = this.authService.getUserId();
  }

  cancel(): void {
    this.location.back();
  }

  submit(): void {
    // Calculate duration first
    this.calculateDuration();

    // Convert signal value to payload
    const lr = this.leaveRequest();
    const payload: CreateLeaveRequestDTO = {
      ...lr,
      startDate: new Date(lr.startDate).toISOString(),
      endDate: new Date(lr.endDate).toISOString(),
    };

    console.log('payload :', payload);
    console.log('employeeId :', this.employeeId());

    if (this.employeeId()) {
      this.employeesService
        .createLeaveRequest(this.employeeId()!, payload)
        .subscribe({
          next: (res) => {
            console.log('Leave request submitted successfully:', res);
          },
          error: (err: Error) => {
            this.errorMessage.set(err.message);
          },
          complete: () => console.log('Request completed'),
        });
    }
  }

  setHalfDay(value: boolean): void {
    this.halfDay.set(value);
    this.calculateDuration();
  }

  calculateDuration(): void {
    const lr = this.leaveRequest();
    const isHalf = this.halfDay();

    if (!lr.startDate) {
      this.leaveRequest.update((r) => ({ ...r, durationInDays: 0 }));
      return;
    }

    if (isHalf) {
      this.leaveRequest.update((r) => ({ ...r, durationInDays: 0.5 }));
      return;
    }

    if (!lr.endDate) {
      this.leaveRequest.update((r) => ({ ...r, durationInDays: 0 }));
      return;
    }

    const start = new Date(lr.startDate);
    const end = new Date(lr.endDate);
    const diffTime = end.getTime() - start.getTime();
    const diffDays = Math.floor(diffTime / (1000 * 60 * 60 * 24)) + 1;

    this.leaveRequest.update((r) => ({
      ...r,
      durationInDays: diffDays > 0 ? diffDays : 0,
    }));
  }

  private formatDate(date: Date): string {
    return date.toISOString().split('T')[0];
  }
}
