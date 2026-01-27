import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaveBalancesReportTableComponent } from './leave-balances-report-table-component';

describe('LeaveBalancesReportTableComponent', () => {
  let component: LeaveBalancesReportTableComponent;
  let fixture: ComponentFixture<LeaveBalancesReportTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LeaveBalancesReportTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaveBalancesReportTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
