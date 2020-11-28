/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ComprasService } from './compras.service';

describe('Service: Compras', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ComprasService]
    });
  });

  it('should ...', inject([ComprasService], (service: ComprasService) => {
    expect(service).toBeTruthy();
  }));
});
