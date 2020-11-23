/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LojaService } from './loja.service';

describe('Service: Loja', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LojaService]
    });
  });

  it('should ...', inject([LojaService], (service: LojaService) => {
    expect(service).toBeTruthy();
  }));
});
