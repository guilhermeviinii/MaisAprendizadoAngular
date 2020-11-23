import { HttpClient } from '@angular/common/http';
import { Component, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CursoComponent } from '../curso/curso.component';
import { Curso } from '../models/Curso';

@Injectable({
  providedIn: 'root'
})
export class LojaService {
  baseUrl = `${environment.UrlPrincipal}/api/curso`;
  public Cursos = [];

  public curso: string;


  constructor(private http: HttpClient) { }

  buscarTodosCursos(): Observable<Curso[]> {
    return this.http.get<Curso[]>(`${this.baseUrl}/Read`)
  }
  

}
