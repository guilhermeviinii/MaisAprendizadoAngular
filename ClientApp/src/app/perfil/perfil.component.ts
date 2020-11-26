import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from '../login/auth.service';
import { Pessoa } from '../models/Usuario';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {
  
  public pessoa: Pessoa = new Pessoa();

  constructor(private authService: AuthService) { }

  ngOnInit() {
    console.log(this.pessoa = this.authService.dadosUsuarioLogado());
  }
  @Input() email: string = this.pessoa.email;
  @Input() telefone: number = this.pessoa.telefone;
  @Input() dataNascimento: string = this.pessoa.dataNascimeno;
  
}
