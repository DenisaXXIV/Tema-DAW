import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCardIComponent } from './add-card-i.component';

describe('AddCardIComponent', () => {
  let component: AddCardIComponent;
  let fixture: ComponentFixture<AddCardIComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCardIComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCardIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
