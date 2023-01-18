import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCardPComponent } from './add-card-p.component';

describe('AddCardPComponent', () => {
  let component: AddCardPComponent;
  let fixture: ComponentFixture<AddCardPComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCardPComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCardPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
