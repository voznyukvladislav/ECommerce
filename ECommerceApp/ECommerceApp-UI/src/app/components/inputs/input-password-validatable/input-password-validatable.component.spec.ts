import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputPasswordValidatableComponent } from './input-password-validatable.component';

describe('InputPasswordValidatableComponent', () => {
  let component: InputPasswordValidatableComponent;
  let fixture: ComponentFixture<InputPasswordValidatableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputPasswordValidatableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputPasswordValidatableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
