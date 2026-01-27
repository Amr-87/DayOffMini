import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocationMultiSelectDropdownComponent } from './location-multi-select-dropdown-component';

describe('LocationMultiSelectDropdownComponent', () => {
  let component: LocationMultiSelectDropdownComponent;
  let fixture: ComponentFixture<LocationMultiSelectDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LocationMultiSelectDropdownComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LocationMultiSelectDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
