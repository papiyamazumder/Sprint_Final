import { TestBed } from '@angular/core/testing';

import { GradeMasterService } from './grade-master.service';

describe('GradeMasterService', () => {
  let service: GradeMasterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GradeMasterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
