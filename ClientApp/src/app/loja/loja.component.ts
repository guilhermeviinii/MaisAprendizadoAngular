import { Component, Input, OnInit } from '@angular/core';
import { Curso } from '../models/Curso';
import { LojaService } from './loja.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.css']
})
export class LojaComponent implements OnInit {

  public cursos: Curso[];

  constructor(public lojaService: LojaService) { }

  ngOnInit() {
    this.lojaService.curso;
    this.carregarCursos();
  }

  carregarCursos(){
     this.lojaService.buscarTodosCursos().subscribe(
       (curso: Curso[]) => {
        this.cursos = curso
        console.log(this.cursos)
       },
       (erro: any) => {console.error(erro)}
     );
  }

  buscarCurso(): void{
    window.alert(this.lojaService.curso)
  }

}
