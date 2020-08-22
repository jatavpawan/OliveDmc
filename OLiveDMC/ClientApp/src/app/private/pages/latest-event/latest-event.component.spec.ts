import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LatestEventComponent } from './latest-event.component';

describe('LatestEventComponent', () => {
  let component: LatestEventComponent;
  let fixture: ComponentFixture<LatestEventComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LatestEventComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LatestEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
