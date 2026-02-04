import { Location, NgClass } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { CreateLeaveRequestDTO } from '../../shared/models/create-leave-request-dto';
import { EmployeeDTO } from '../../shared/models/employee-dto';
import { LeaveTypeDTO } from '../../shared/models/LeaveTypeDTO';
import { EmployeesServices } from '../../shared/services/employees-services';
import { LeaveTypesService } from '../../shared/services/leave-types-service';

type MessageType = 'error' | 'success';

@Component({
  selector: 'app-create-leave-request-page',
  standalone: true,
  imports: [FormsModule, NgSelectModule, NgClass],
  templateUrl: './create-leave-request-page.html',
  styleUrl: './create-leave-request-page.scss',
})
export class CreateLeaveRequestPage implements OnInit {
  message = signal<{ type: MessageType; text: string } | null>(null);
  submitting = signal(false);
  halfDay = signal(false);
  employeeId = signal<number | undefined>(undefined);
  employees: EmployeeDTO[] = [];
  leaveTypes: LeaveTypeDTO[] = [];
  leaveRequest = signal<CreateLeaveRequestDTO>({
    leaveTypeId: 0,
    durationInDays: 1,
    startDate: this.formatDate(new Date()),
    endDate: this.formatDate(new Date()),
    reason: '',
  });

  constructor(
    private location: Location,
    private leaveTypesService: LeaveTypesService,
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
  }

  cancel(): void {
    this.location.back();
  }

  submit(form: NgForm): void {
    if (form.invalid || !this.employeeId()) {
      return;
    }
    this.submitting.set(true);
    this.clearMessage();

    // Calculate duration first
    this.calculateDuration();

    // Convert signal value to payload
    const lr = this.leaveRequest();
    const payload: CreateLeaveRequestDTO = {
      ...lr,
      startDate: new Date(lr.startDate).toISOString(),
      endDate: new Date(lr.endDate).toISOString(),
    };

    // console.log('payload :', payload);
    // console.log('employeeId :', this.employeeId());

    this.employeesService
      .createLeaveRequest(this.employeeId()!, payload)
      .subscribe({
        next: (res) => {
          this.message.set({
            type: 'success',
            text: 'Leave request created successfully',
          });

          // form.resetForm();
          this.halfDay.set(false);
          this.leaveRequest.set({
            leaveTypeId: this.leaveTypes[0]?.id ?? 0,
            durationInDays: 1,
            startDate: this.formatDate(new Date()),
            endDate: this.formatDate(new Date()),
            reason: '',
          });
        },
        error: (err: Error) => {
          this.message.set({
            type: 'error',
            text: err.message || 'Failed to create leave request',
          });
          this.submitting.set(false);
        },
        complete: () => this.submitting.set(false),
      });
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

  clearMessage(): void {
    this.message.set(null);
  }
}
