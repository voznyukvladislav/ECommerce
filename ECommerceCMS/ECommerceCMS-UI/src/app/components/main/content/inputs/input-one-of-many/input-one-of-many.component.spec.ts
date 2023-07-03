import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputOneOfManyComponent } from './input-one-of-many.component';

describe('InputOneOfManyComponent', () => {
  let component: InputOneOfManyComponent;
  let fixture: ComponentFixture<InputOneOfManyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputOneOfManyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputOneOfManyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
