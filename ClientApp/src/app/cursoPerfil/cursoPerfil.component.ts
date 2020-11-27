import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-cursoPerfil',
  templateUrl: './cursoPerfil.component.html',
  styleUrls: ['./cursoPerfil.component.css']
})
export class CursoPerfilComponent implements OnInit {

  @Input() titulo: string;

  constructor() { }

  ngOnInit() {
  }

}
