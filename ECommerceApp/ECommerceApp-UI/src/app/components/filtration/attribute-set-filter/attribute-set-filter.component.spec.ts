import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttributeSetFilterComponent } from './attribute-set-filter.component';

describe('AttributeSetFilterComponent', () => {
  let component: AttributeSetFilterComponent;
  let fixture: ComponentFixture<AttributeSetFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttributeSetFilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AttributeSetFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
