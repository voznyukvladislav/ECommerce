import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputExtensionalComponent } from './input-extensional.component';

describe('InputExtensionalComponent', () => {
  let component: InputExtensionalComponent;
  let fixture: ComponentFixture<InputExtensionalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputExtensionalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputExtensionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
