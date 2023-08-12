import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputSimplePasswordComponent } from './input-simple-password.component';

describe('InputSimplePasswordComponent', () => {
  let component: InputSimplePasswordComponent;
  let fixture: ComponentFixture<InputSimplePasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputSimplePasswordComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputSimplePasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
