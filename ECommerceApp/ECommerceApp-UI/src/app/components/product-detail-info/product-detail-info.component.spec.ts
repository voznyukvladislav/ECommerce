import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailInfoComponent } from './product-detail-info.component';

describe('ProductDetailInfoComponent', () => {
  let component: ProductDetailInfoComponent;
  let fixture: ComponentFixture<ProductDetailInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDetailInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductDetailInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
