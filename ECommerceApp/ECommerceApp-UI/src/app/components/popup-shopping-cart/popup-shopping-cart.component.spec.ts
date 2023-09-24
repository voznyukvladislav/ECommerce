import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopupShoppingCartComponent } from './popup-shopping-cart.component';

describe('PopupShoppingCartComponent', () => {
  let component: PopupShoppingCartComponent;
  let fixture: ComponentFixture<PopupShoppingCartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PopupShoppingCartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PopupShoppingCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
