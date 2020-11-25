import { Component, Input, OnInit } from '@angular/core';
import { LojaService } from '../loja/loja.service';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.css']
})
export class CursoComponent implements OnInit {

  @Input() titulo: string;
  @Input() preco: number;

  constructor(public lojaService: LojaService) { }

  ngOnInit() {
  }

}
