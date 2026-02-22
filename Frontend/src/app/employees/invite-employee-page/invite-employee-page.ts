import { Location, NgClass } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { EmployeeDTO } from '../../shared/models/employee-dto';
import { EmployeesServices } from '../../shared/services/employees-services';

@Component({
  selector: 'app-invite-employee-page',
  imports: [FormsModule, NgClass],
  templateUrl: './invite-employee-page.html',
})
export class InviteEmployeePage {
  employeee: EmployeeDTO = { id: 0, email: '', name: '' };

  constructor(
    private service: EmployeesServices,
    private location: Location,
  ) {}

  onSubmit(form: NgForm) {
    this.service.addEmployee(form.value).subscribe({
      complete: () => form.resetForm(),
    });
  }

  cancel() {
    this.location.back();
  }
}
