import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FresherCareerComponent } from './fresher-career.component';

describe('FresherCareerComponent', () => {
  let component: FresherCareerComponent;
  let fixture: ComponentFixture<FresherCareerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FresherCareerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FresherCareerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
