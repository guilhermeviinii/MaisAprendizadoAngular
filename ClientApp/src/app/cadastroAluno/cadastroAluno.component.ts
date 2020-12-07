import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DialogsExampleComponent } from '../cursoCriadoPerfil/cursoCriadoPerfil.component';
import { CadastroAlunoService } from './cadastroAluno.service';

@Component({
  selector: 'app-cadastroAluno',
  templateUrl: './cadastroAluno.component.html',
  styleUrls: ['./cadastroAluno.component.css']
})
export class CadastroAlunoComponent implements OnInit {
  public aluno: FormGroup;

  constructor(public fb: FormBuilder, public route: Router, private http: HttpClient, private cadastroAluno: CadastroAlunoService) { }

  ngOnInit() {
    this.aluno = this.fb.group({
      nome: [null, Validators.required],
      email: [null, Validators.required],
      dataNascimento: [null, Validators.required],
      senha: [null, Validators.required],
      telefone: [null, Validators.required],

    })
  }

  registroAluno() {
    return this.cadastroAluno.registroAluno(this.aluno.value).subscribe((retorno) => {
      this.route.navigate(['login'])
     
    });
  }
}
