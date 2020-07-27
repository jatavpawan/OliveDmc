import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogPriorityComponent } from './blog-priority.component';

describe('BlogPriorityComponent', () => {
  let component: BlogPriorityComponent;
  let fixture: ComponentFixture<BlogPriorityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogPriorityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogPriorityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
