import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentNewsDetailComponent } from './current-news-detail.component';

describe('CurrentNewsDetailComponent', () => {
  let component: CurrentNewsDetailComponent;
  let fixture: ComponentFixture<CurrentNewsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentNewsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentNewsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
