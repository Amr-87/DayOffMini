import { CommonModule } from '@angular/common';
import {
  AfterViewInit,
  Component,
  OnInit,
  output,
  signal,
  ViewChild,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { LeaveTypeDTO } from '../../../shared/models/LeaveTypeDTO';
import { EmployeesServices } from '../../../shared/services/employees-services';
import { LeaveBalancesReportService } from '../../../shared/services/leave-balances-report-service';
import { LeaveBalancesReportDTO } from '../../models/LeaveBalancesReportDTO';

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
    FormsModule,
  ],
})
export class LeaveBalancesReportTableComponent
  implements OnInit, AfterViewInit
{
  totalRequests = 0;
  startDate = '2026-01-01';
  endDate = '2026-01-31';

  employees: LeaveBalancesReportDTO[] = [];
  leaveTypeNames: string[] = [];
  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  searchText = signal<string>('');
  leaveTypesOutput = output<LeaveTypeDTO[]>();

  constructor(
    private employeeService: EmployeesServices,
    private reportService: LeaveBalancesReportService,
  ) {}
  ngOnInit() {
    this.employeeService
      .getLeaveBalancesReport()
      .subscribe((data: LeaveBalancesReportDTO[]) => {
        this.employees = data;

        // Get unique leave types
        const leaveSet = new Set<string>();
        this.employees.forEach((emp) =>
          emp.leaveBalances.forEach((lb) => leaveSet.add(lb.leaveTypeName)),
        );
        this.leaveTypeNames = Array.from(leaveSet);

        // Columns for table
        this.displayedColumns = [
          'employee',
          ...this.leaveTypeNames,
          'totalDays',
          'totalHours',
        ];

        // Pivot table data
        const tableData = this.employees.map((emp) => {
          const row: any = { employee: emp.employeeName };
          this.leaveTypeNames.forEach((type) => {
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

        // compute leave types
        const computedLeaveTypes = this.leaveTypeNames.map((name, index) => {
          let totalTaken = 0;
          let totalBalance = 0;

          this.employees.forEach((emp) => {
            const lb = emp.leaveBalances.find((l) => l.leaveTypeName === name);
            totalTaken += lb ? lb.daysTaken : 0;
            totalBalance += emp.totalDaysOffBalance;
          });
          return {
            id: index + 1,
            name,
            color: this.reportService.generateNiceColor(),
            reportCirclePercentage:
              totalBalance > 0 ? totalTaken / totalBalance : 0,
          };
        });

        this.leaveTypesOutput.emit(computedLeaveTypes);
      });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter() {
    const filterValue = this.searchText();
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
