import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CadastroProfessorService } from './cadastroProfessor.service';

@Component({
  selector: 'app-cadastroProfessor',
  templateUrl: './cadastroProfessor.component.html',
  styleUrls: ['./cadastroProfessor.component.css']
})
export class CadastroProfessorComponent implements OnInit {
  public professor: FormGroup;

  constructor(public fb: FormBuilder, private http: HttpClient, private cadastroProfessor: CadastroProfessorService) { }

  ngOnInit() {
    this.professor = this.fb.group({
      nome: [null, Validators.required],
      email: [null, Validators.required],
      dataNascimento: [null, Validators.required],
      senha: [null, Validators.required],
      telefone: [null, Validators.required],

    })
  }
  registroProfessor(){
    return this.cadastroProfessor.registroProfessor(this.professor.value).subscribe((retorno) => {
      console.log(retorno);
    });
  }

}
