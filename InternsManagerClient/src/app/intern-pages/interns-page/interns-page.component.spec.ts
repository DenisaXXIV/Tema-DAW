import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternsPageComponent } from './interns-page.component';

describe('InternsPageComponent', () => {
  let component: InternsPageComponent;
  let fixture: ComponentFixture<InternsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InternsPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InternsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
