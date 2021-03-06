import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../login/auth.service';
import { LojaService } from '../loja/loja.service';
import { Curso } from '../models/Curso';
import { Pessoa } from '../models/Usuario';
import { PerfilService } from './perfil.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {
  public titulo: string;
  public data: any;
  public separar: any;
  public isProfessor: any;

  public formulario: FormGroup;
  public mostrarEditar: boolean;
  public mostrarMeusCursos: boolean;
  public mostrarMeusCursosCriado: boolean;
  public pessoa: Pessoa = new Pessoa();
  public cursos: Curso;
  public cursosCriado: Curso;

  constructor(private fb: FormBuilder,
     private authService: AuthService, private perfilService: PerfilService, private lojaService: LojaService) { }

  ngOnInit() {
   
    this.mostrarEditar = false;
    this.mostrarMeusCursos = false;
    this.mostrarMeusCursosCriado = false;
    this.pessoa = this.authService.dadosUsuarioLogado();
    this.lojaService.buscarTodosCursoCriadoPorId(this.pessoa.pessoaId).subscribe((resp: any) => {
      console.log(this.cursosCriado = resp["cursos"]);
    }, () => { });
    this.lojaService.buscarTodosCursoPorId(this.pessoa.pessoaId).subscribe((resp: any) => {
      this.cursos = resp["cursos"];
    }, () => { });
    this.formulario = this.fb.group({
      pessoaId: [this.pessoa.pessoaId, Validators.required],
      nome: [null, Validators.required],
      email: [null, Validators.required],
      dataNascimento: [null, Validators.required],
      telefone: [null, Validators.required]

    })
    this.verificacaoProfessor(this.pessoa)
  }
  
  @Input() email: string = this.pessoa.email;
  @Input() telefone: number = this.pessoa.telefone;
  @Input() dataNascimento: string = this.pessoa.dataNascimento;

  editarUsuario() {
    return  this.perfilService.editarUsuario(this.formulario.value).subscribe((retorno: any) => {
        this.mostrarEditar = false;
        this.authService.pessoa = retorno;
      
      this.pessoa  = retorno;
    })
  }
  verificacaoProfessor(pessoa: any) {
    this.authService.isProfessor(pessoa.pessoaId)
  }
}
