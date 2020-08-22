import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewdestinationsInWhatsnewComponent } from './newdestinations-in-whatsnew.component';

describe('NewdestinationsInWhatsnewComponent', () => {
  let component: NewdestinationsInWhatsnewComponent;
  let fixture: ComponentFixture<NewdestinationsInWhatsnewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewdestinationsInWhatsnewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewdestinationsInWhatsnewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
