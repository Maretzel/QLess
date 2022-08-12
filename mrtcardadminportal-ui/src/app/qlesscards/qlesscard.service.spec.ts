import { TestBed } from '@angular/core/testing';

import { QlesscardService } from './qlesscard.service';

describe('QlesscardService', () => {
  let service: QlesscardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QlesscardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
