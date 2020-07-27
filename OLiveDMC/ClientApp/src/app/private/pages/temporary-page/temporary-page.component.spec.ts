import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemporaryPageComponent } from './temporary-page.component';

describe('TemporaryPageComponent', () => {
  let component: TemporaryPageComponent;
  let fixture: ComponentFixture<TemporaryPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemporaryPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemporaryPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
