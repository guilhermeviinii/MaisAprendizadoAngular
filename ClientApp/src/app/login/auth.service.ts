import { Route } from '@angular/compiler/src/core';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from './usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private usuarioAutenticado: boolean = false;

  constructor(private route: Router) { }

  fazerLogion(usuario: Usuario){
    if(usuario.nome === "usuario@gmail.com" && usuario.senha === '123'){
      this.usuarioAutenticado = true;
      this.route.navigate(['dashboard'])
    }else{
      this.usuarioAutenticado = false;
    }

  }
}
