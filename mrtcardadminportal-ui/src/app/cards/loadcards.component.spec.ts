import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadCardsComponent } from './loadcards.component';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';


describe('CardtypeComponent', () => {
  let component: LoadCardsComponent;
  let fixture: ComponentFixture<LoadCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoadCardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoadCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
