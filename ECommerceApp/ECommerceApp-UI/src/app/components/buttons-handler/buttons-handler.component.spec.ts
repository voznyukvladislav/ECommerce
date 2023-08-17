import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonsHandlerComponent } from './buttons-handler.component';

describe('ButtonsHandlerComponent', () => {
  let component: ButtonsHandlerComponent;
  let fixture: ComponentFixture<ButtonsHandlerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ButtonsHandlerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ButtonsHandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
