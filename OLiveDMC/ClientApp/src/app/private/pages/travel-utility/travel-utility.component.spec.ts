import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelUtilityComponent } from './travel-utility.component';

describe('TravelUtilityComponent', () => {
  let component: TravelUtilityComponent;
  let fixture: ComponentFixture<TravelUtilityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TravelUtilityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelUtilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
