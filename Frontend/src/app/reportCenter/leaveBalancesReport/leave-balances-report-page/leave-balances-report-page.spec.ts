import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaveBalancesReportPage } from './leave-balances-report-page';

describe('LeaveBalancesReportPage', () => {
  let component: LeaveBalancesReportPage;
  let fixture: ComponentFixture<LeaveBalancesReportPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LeaveBalancesReportPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaveBalancesReportPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
