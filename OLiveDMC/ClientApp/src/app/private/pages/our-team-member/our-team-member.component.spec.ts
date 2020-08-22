import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OurTeamMemberComponent } from './our-team-member.component';

describe('OurTeamMemberComponent', () => {
  let component: OurTeamMemberComponent;
  let fixture: ComponentFixture<OurTeamMemberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OurTeamMemberComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OurTeamMemberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
