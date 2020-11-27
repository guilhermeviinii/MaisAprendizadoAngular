import { Component, Input, OnInit } from '@angular/core';
import { LojaService } from '../loja/loja.service';
import { Curso } from '../models/Curso';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.css']
})
export class CursoComponent implements OnInit {

  @Input() titulo: string;
  @Input() preco: number;
  @Input() cursos: any;
  @Input() 
  public itemCarrinho: [
    {titulo: string,
     preco: number,
    }
  ];

  constructor(public lojaService: LojaService) { }

  ngOnInit() {
    console.log(this.cursos)
  }

  adicionarCarrinho(){

  }
}
