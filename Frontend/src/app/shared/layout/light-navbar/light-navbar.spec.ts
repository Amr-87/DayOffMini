import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LightNavbar } from './light-navbar';

describe('LightNavbar', () => {
  let component: LightNavbar;
  let fixture: ComponentFixture<LightNavbar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LightNavbar]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LightNavbar);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
