import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputDoublePasswordValidatableComponent } from './input-double-password-validatable.component';

describe('InputDoublePasswordValidatableComponent', () => {
  let component: InputDoublePasswordValidatableComponent;
  let fixture: ComponentFixture<InputDoublePasswordValidatableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputDoublePasswordValidatableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputDoublePasswordValidatableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
