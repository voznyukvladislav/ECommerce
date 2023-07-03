import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputManyOfManyComponent } from './input-many-of-many.component';

describe('InputManyOfManyComponent', () => {
  let component: InputManyOfManyComponent;
  let fixture: ComponentFixture<InputManyOfManyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InputManyOfManyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputManyOfManyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
