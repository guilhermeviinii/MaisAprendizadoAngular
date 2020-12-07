import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-cursoCriadoPerfil',
  templateUrl: './cursoCriadoPerfil.component.html',
  styleUrls: ['./cursoCriadoPerfil.component.css']
})
export class CursoCriadoPerfilComponent implements OnInit {

  @Input() titulo: string;
  constructor() { }

  ngOnInit() {
  }

}
