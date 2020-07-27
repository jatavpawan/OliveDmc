import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelCategorySubcategoryComponent } from './travel-category-subcategory.component';

describe('TravelCategorySubcategoryComponent', () => {
  let component: TravelCategorySubcategoryComponent;
  let fixture: ComponentFixture<TravelCategorySubcategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TravelCategorySubcategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelCategorySubcategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
