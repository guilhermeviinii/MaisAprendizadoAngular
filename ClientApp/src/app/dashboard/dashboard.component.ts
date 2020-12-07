import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgxCarousel } from 'ngx-carousel';
import { AuthService } from '../login/auth.service';
import { LojaService } from '../loja/loja.service';
import { Curso } from '../models/Curso';
import { Pessoa } from '../models/Usuario';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public carouselOne: NgxCarousel;
  public pessoa: Pessoa = new Pessoa();
  public isProfessor: boolean = false;
  public cursos: Curso;
  public cursosDisponiveis: Curso[];

  constructor(private authService: AuthService, private lojaService: LojaService) { }

  ngOnInit() {

    
    this.carouselOne = {
      grid: { xs: 1, sm: 1, md: 1, lg: 1, all: 0 },
      slide: 1,
      speed: 400,
      interval: 4000,
      load: 2,
      touch: true,
      loop: true,
      custom: 'banner'
    }
    this.lojaService.buscarTodosCursoPorId(this.authService.pessoa.pessoaId).subscribe((resp: any) => {
      this.cursos = resp["cursos"];
    }, () => { });
    this.lojaService.buscarTodosCursos().subscribe(
      arrayCursos => this.cursosDisponiveis = arrayCursos
    )
    this.pessoa = this.authService.dadosUsuarioLogado()
    this.verificacaoProfessor(this.pessoa)
  }

  verificacaoProfessor(pessoa: any) {
    this.authService.isProfessor(pessoa.pessoaId)
    console.log(this.isProfessor)

  }

 

}
