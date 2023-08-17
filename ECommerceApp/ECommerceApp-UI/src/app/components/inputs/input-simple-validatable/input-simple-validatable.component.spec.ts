import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputSimpleValidatableComponent } from './input-simple-validatable.component';

describe('InputSimpleValidatableComponent', () => {
  let component: InputSimpleValidatableComponent;
  let fixture: ComponentFixture<InputSimpleValidatableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputSimpleValidatableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputSimpleValidatableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
