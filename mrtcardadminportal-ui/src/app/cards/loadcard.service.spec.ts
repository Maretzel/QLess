import { TestBed } from '@angular/core/testing';

import { LoadCardService } from './loadcard.service';

describe('CardsService', () => {
  let service: LoadCardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoadCardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
