import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcommingNewsComponent } from './upcomming-news.component';

describe('UpcommingNewsComponent', () => {
  let component: UpcommingNewsComponent;
  let fixture: ComponentFixture<UpcommingNewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpcommingNewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpcommingNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
