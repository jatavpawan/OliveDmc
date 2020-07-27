import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferAdsDetailComponent } from './offer-ads-detail.component';

describe('OfferAdsDetailComponent', () => {
  let component: OfferAdsDetailComponent;
  let fixture: ComponentFixture<OfferAdsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfferAdsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfferAdsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
