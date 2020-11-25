import { Component, Input, OnInit } from '@angular/core';
import { Curso } from '../models/Curso';
import { tap, map } from 'rxjs/operators'
import { LojaService } from './loja.service';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.css']
})
export class LojaComponent implements OnInit {

  @Input() nomeCurso: string;

  cursos: Curso[];

  existeCurso: boolean;

  constructor(private lojaService: LojaService) { }

  ngOnInit() {
    this.carregarCursos();
    this.lojaService.buscarTodosCursos().subscribe(
      arrayCursos => this.cursos = arrayCursos
    )
  }

  carregarCursos() {

  }

  buscarCurso() {
    this.lojaService.buscarCursoPorNome(this.nomeCurso).subscribe(
      arrayCursos => this.cursos = arrayCursos
    )
  }

}
