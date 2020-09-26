import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessionalCareerComponent } from './professional-career.component';

describe('ProfessionalCareerComponent', () => {
  let component: ProfessionalCareerComponent;
  let fixture: ComponentFixture<ProfessionalCareerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfessionalCareerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessionalCareerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
