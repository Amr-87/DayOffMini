import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltersBar } from './filters-bar';

describe('FiltersBar', () => {
  let component: FiltersBar;
  let fixture: ComponentFixture<FiltersBar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FiltersBar]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FiltersBar);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
