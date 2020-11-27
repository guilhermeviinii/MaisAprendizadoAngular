import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {
  baseUrl = `${environment.UrlPrincipal}/api/pessoas`;
  constructor(private http: HttpClient) { }

  editarUsuario(formulario){
    return this.http.post(this.baseUrl + '/editarUsuario', formulario);
  }


}
