import { TestBed } from '@angular/core/testing';

import { TableMetadataService } from './table-metadata.service';

describe('TableMetadataService', () => {
  let service: TableMetadataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TableMetadataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
