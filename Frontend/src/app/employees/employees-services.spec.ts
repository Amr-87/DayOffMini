import { TestBed } from '@angular/core/testing';

import { EmployeesServices } from './employees-services';

describe('EmployeesServices', () => {
  let service: EmployeesServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeesServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
