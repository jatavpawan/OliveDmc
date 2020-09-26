import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentCareerComponent } from './student-career.component';

describe('StudentCareerComponent', () => {
  let component: StudentCareerComponent;
  let fixture: ComponentFixture<StudentCareerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentCareerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentCareerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
