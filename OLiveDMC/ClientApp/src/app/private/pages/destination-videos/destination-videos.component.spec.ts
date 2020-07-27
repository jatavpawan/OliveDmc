import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinationVideosComponent } from './destination-videos.component';

describe('DestinationVideosComponent', () => {
  let component: DestinationVideosComponent;
  let fixture: ComponentFixture<DestinationVideosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DestinationVideosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DestinationVideosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
