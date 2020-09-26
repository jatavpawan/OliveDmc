import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaOfExpertiseComponent } from './area-of-expertise.component';

describe('AreaOfExpertiseComponent', () => {
  let component: AreaOfExpertiseComponent;
  let fixture: ComponentFixture<AreaOfExpertiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaOfExpertiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaOfExpertiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
