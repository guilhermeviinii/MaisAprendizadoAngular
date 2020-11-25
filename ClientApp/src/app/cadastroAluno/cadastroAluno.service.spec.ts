/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CadastroAlunoService } from './cadastroAluno.service';

describe('Service: CadastroAluno', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CadastroAlunoService]
    });
  });

  it('should ...', inject([CadastroAlunoService], (service: CadastroAlunoService) => {
    expect(service).toBeTruthy();
  }));
});
