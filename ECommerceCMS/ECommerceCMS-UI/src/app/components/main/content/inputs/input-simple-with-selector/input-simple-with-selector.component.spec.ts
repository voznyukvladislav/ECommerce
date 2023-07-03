import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputSimpleWithSelectorComponent } from './input-simple-with-selector.component';

describe('InputSimpleWithSelectorComponent', () => {
  let component: InputSimpleWithSelectorComponent;
  let fixture: ComponentFixture<InputSimpleWithSelectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputSimpleWithSelectorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputSimpleWithSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
