import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelGuruExpertTravelersComponent } from './travel-guru-expert-travelers.component';

describe('TravelGuruExpertTravelersComponent', () => {
  let component: TravelGuruExpertTravelersComponent;
  let fixture: ComponentFixture<TravelGuruExpertTravelersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TravelGuruExpertTravelersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelGuruExpertTravelersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
