import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QlesscardsComponent } from './qlesscards.component';

describe('QlesscardsComponent', () => {
  let component: QlesscardsComponent;
  let fixture: ComponentFixture<QlesscardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QlesscardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QlesscardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
