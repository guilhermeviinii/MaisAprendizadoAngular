/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PerfilService } from './perfil.service';

describe('Service: Perfil', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PerfilService]
    });
  });

  it('should ...', inject([PerfilService], (service: PerfilService) => {
    expect(service).toBeTruthy();
  }));
});
