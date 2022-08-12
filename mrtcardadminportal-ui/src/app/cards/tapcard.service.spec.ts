import { TestBed } from '@angular/core/testing';

import { TapcardService } from './tapcard.service';

describe('TapcardService', () => {
  let service: TapcardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TapcardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
