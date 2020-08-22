import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutusIntroductionComponent } from './aboutus-introduction.component';

describe('AboutusIntroductionComponent', () => {
  let component: AboutusIntroductionComponent;
  let fixture: ComponentFixture<AboutusIntroductionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AboutusIntroductionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutusIntroductionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
