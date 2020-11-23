import { Component, OnInit } from '@angular/core';
import { LojaService } from '../loja/loja.service';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.css']
})
export class CursoComponent implements OnInit {

  constructor(public lojaService: LojaService) { }

  ngOnInit() {
  }

}
