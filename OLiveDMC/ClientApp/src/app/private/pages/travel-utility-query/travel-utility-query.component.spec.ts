import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelUtilityQueryComponent } from './travel-utility-query.component';

describe('TravelUtilityQueryComponent', () => {
  let component: TravelUtilityQueryComponent;
  let fixture: ComponentFixture<TravelUtilityQueryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TravelUtilityQueryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelUtilityQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
