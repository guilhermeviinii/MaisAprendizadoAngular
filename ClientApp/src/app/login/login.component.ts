import { Component, OnInit } from '@angular/core';
import { Pessoa } from '../models/Usuario';
import { AuthService } from './auth.service';
import { Usuario } from './usuario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  alerta: boolean;

  private usuario: Usuario = new Usuario();

  public pessoa: Pessoa = new Pessoa();



  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.alerta;
  }


  logar() {
    // console.log(this.usuario)
    var resp = this.authService.fazerLogion(this.usuario)
  }

}
