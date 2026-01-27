import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeavePolicyMultiSelectDropdownComponent } from './leave-policy-multi-select-dropdown-component';

describe('LeavePolicyMultiSelectDropdownComponent', () => {
  let component: LeavePolicyMultiSelectDropdownComponent;
  let fixture: ComponentFixture<LeavePolicyMultiSelectDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LeavePolicyMultiSelectDropdownComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeavePolicyMultiSelectDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
