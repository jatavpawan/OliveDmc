import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewInWhatsnewComponent } from './interview-in-whatsnew.component';

describe('InterviewInWhatsnewComponent', () => {
  let component: InterviewInWhatsnewComponent;
  let fixture: ComponentFixture<InterviewInWhatsnewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InterviewInWhatsnewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewInWhatsnewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
