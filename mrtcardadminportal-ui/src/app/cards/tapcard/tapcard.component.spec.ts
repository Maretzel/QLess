import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TapcardComponent } from './tapcard.component';

describe('TapcardComponent', () => {
  let component: TapcardComponent;
  let fixture: ComponentFixture<TapcardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TapcardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TapcardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
