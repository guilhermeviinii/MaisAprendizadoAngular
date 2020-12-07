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

  public usuarioAutenticado: boolean = false;
  public pessoa: Pessoa = new Pessoa();
  public alerta: boolean = false;
  public eProfessor: boolean = false;

  constructor(private route: Router, private http: HttpClient) { }

  fazerLogion(usuario: Usuario) {
    return this.http.post(this.baseUrl + '/Get', usuario).subscribe((resp: any) => {
      if (resp.mensagem == "usuarioErrado") {
        this.alerta = true;
        return this.usuarioAutenticado = false;
      }
      this.pessoa = resp.usuario;
      this.pessoa
      this.usuarioAutenticado = true;
      this.route.navigate(['dashboard'])
    }, () => {  return this.usuarioAutenticado = false; })
  }
  isProfessor(pessoaId){
    let params = new HttpParams();
    params = params.set('pessoaId', pessoaId);
    return this.http.get<Pessoa[]>(`${this.baseUrl}/isProfessor?${params}`).subscribe((resp: any) => {
      console.log(resp)
      this.eProfessor = true;
  
  }, () => { this.eProfessor = false });
  }

  usuarioEstaAutenticado() {
    return this.usuarioAutenticado
  }
  dadosUsuarioLogado() {
    return this.pessoa
  }

  
}
