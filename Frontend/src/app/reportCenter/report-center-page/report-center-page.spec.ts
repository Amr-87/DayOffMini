import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportCenterPage } from './report-center-page';

describe('ReportCenterPage', () => {
  let component: ReportCenterPage;
  let fixture: ComponentFixture<ReportCenterPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReportCenterPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportCenterPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
