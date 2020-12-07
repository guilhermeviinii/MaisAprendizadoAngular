import { Component, Input, OnInit } from '@angular/core';
import { Curso } from '../models/Curso';
import { tap, map } from 'rxjs/operators'
import { LojaService } from './loja.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AuthService } from '../login/auth.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.css']
})
export class LojaComponent implements OnInit {

  @Input() nomeCurso: string;

  cursos: Curso[];
  total: number;


  public itemCarrinho = new Array();

  existeCurso: boolean;

  constructor(private lojaService: LojaService, private authService: AuthService) { }

  ngOnInit() {
    this.lojaService.buscarTodosCursos().subscribe(
      arrayCursos => this.cursos = arrayCursos
    )


  }


  adicionarCarrinho(curso) {
    this.lojaService.total = 0;
    this.lojaService.itemCarrinho.push(curso)
    for (let i = 0; i < this.lojaService.itemCarrinho.length; i++) {
      this.lojaService.total = this.lojaService.total + this.lojaService.itemCarrinho[i]['preco'];
    }

  }
  comprarCurso(curso) {
    this.lojaService.itemCarrinho.push(curso)

  }

  buscarCurso() {
    this.lojaService.buscarCursoPorNome(this.nomeCurso).subscribe(
      arrayCursos => this.cursos = arrayCursos
    )
  }
  listarMaior() {
    console.log(this.cursos.sort((a, b) => a.preco < b.preco ? -1 : a.preco > b.preco ? 1 : 0))
  }
  listarMenor() {
    console.log(this.cursos.sort((a, b) => a.preco < b.preco ? 1 : a.preco > b.preco ? -1 : 0))
  }

}
