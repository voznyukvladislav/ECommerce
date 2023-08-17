import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputsHandlerComponent } from './inputs-handler.component';

describe('InputsHandlerComponent', () => {
  let component: InputsHandlerComponent;
  let fixture: ComponentFixture<InputsHandlerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputsHandlerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputsHandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
