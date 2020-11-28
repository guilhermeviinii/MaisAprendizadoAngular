import { HttpClient, HttpParams } from '@angular/common/http';
import { Route } from '@angular/compiler/src/core';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Pessoa } from '../models/Usuario';
import { Usuario } from './usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = `${environment.UrlPrincipal}/api/pessoas`;

  private usuarioAutenticado: boolean = false;
  public pessoa: Pessoa = new Pessoa();

  constructor(private route: Router, private http: HttpClient) { }

  fazerLogion(usuario: Usuario) {
    return this.http.post(this.baseUrl + '/Get', usuario).subscribe((resp: any) => {
      if (resp.mensagem == "usuarioErrado") {
        return this.usuarioAutenticado = false;
      }
      this.pessoa = resp.usuario;
      console.log(this.pessoa)
      this.usuarioAutenticado = true;
      this.route.navigate(['dashboard'])
    }, () => { this.usuarioAutenticado = false })
  }
  isProfessor(pessoaId){
    let params = new HttpParams();
    {params = params.set('nome', pessoaId)};
    return this.http.get(this.baseUrl + '/isProfessor', )
  }

  usuarioEstaAutenticado() {
    return this.usuarioAutenticado
  }
  dadosUsuarioLogado() {
    return this.pessoa
  }

  
}
