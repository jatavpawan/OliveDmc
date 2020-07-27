import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcommingNewsDetailComponent } from './upcomming-news-detail.component';

describe('UpcommingNewsDetailComponent', () => {
  let component: UpcommingNewsDetailComponent;
  let fixture: ComponentFixture<UpcommingNewsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpcommingNewsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpcommingNewsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
