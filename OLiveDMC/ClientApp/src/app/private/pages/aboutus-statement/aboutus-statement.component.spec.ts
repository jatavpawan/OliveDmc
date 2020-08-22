import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutusStatementComponent } from './aboutus-statement.component';

describe('AboutusStatementComponent', () => {
  let component: AboutusStatementComponent;
  let fixture: ComponentFixture<AboutusStatementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AboutusStatementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutusStatementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
