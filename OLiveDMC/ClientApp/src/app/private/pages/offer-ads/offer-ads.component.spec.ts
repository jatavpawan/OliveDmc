import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferAdsComponent } from './offer-ads.component';

describe('OfferAdsComponent', () => {
  let component: OfferAdsComponent;
  let fixture: ComponentFixture<OfferAdsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfferAdsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfferAdsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
