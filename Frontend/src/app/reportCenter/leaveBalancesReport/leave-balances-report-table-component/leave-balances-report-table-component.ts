import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { EmployeesServices } from '../../../employees/employees-services';
import { EmployeeLeave } from '../LeaveBalanceModel';

@Component({
  selector: 'app-leave-balances-report-table',
  templateUrl: './leave-balances-report-table-component.html',
  styleUrls: ['./leave-balances-report-table-component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
  ],
})
export class LeaveBalancesReportTableComponent
  implements OnInit, AfterViewInit
{
  employees: EmployeeLeave[] = [];
  leaveTypes: string[] = [];
  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  itemsPerPage = 5;
  startItem = 1;
  endItem = 5;
  totalRequests = 0;

  startDate = '2026-01-01';
  endDate = '2026-01-31';

  constructor(private employeeService: EmployeesServices) {}
  ngOnInit() {
    // Optional: show placeholder or loading
    this.employeeService
      .getLeaveBalancesReport()
      .subscribe((data: EmployeeLeave[]) => {
        this.employees = data;

        // Get unique leave types
        const leaveSet = new Set<string>();
        this.employees.forEach((emp) =>
          emp.leaveBalances.forEach((lb) => leaveSet.add(lb.leaveTypeName)),
        );
        this.leaveTypes = Array.from(leaveSet);

        // Columns for table
        this.displayedColumns = [
          'employee',
          ...this.leaveTypes,
          'totalDays',
          'totalHours',
        ];

        // Pivot table data
        const tableData = this.employees.map((emp) => {
          const row: any = { employee: emp.employeeName };
          this.leaveTypes.forEach((type) => {
            const lb = emp.leaveBalances.find((l) => l.leaveTypeName === type);
            row[type] = lb
              ? `${lb.daysTaken} / ${lb.fixedDaysOffBalance}`
              : '0 / 0';
          });
          row.totalDays = emp.totalDaysOffBalance;
          row.totalHours = 0; // optional
          return row;
        });

        this.dataSource.data = tableData;
        this.totalRequests = this.employees.length;
        this.endItem = Math.min(this.itemsPerPage, this.totalRequests);

        console.log('Leave types:', this.leaveTypes);
        console.log('Displayed columns:', this.displayedColumns);
        console.log('Table data:', tableData);
      });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
