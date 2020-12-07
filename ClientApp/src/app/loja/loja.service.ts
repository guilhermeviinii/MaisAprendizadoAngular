import { HttpClient, HttpParams } from '@angular/common/http';
import { tap, map } from 'rxjs/operators'
import { Component, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CursoComponent } from '../curso/curso.component';
import { Curso } from '../models/Curso';
import { NavDashboardComponent } from '../nav-dashboard/nav-dashboard.component';

@Injectable({
  providedIn: 'root'
})
export class LojaService {
  public itemCarrinho = new Array();
  public total: number;
  baseUrl = `${environment.UrlPrincipal}/api/curso`;
  constructor(private http: HttpClient) { }

  buscarTodosCursos(): Observable<Curso[]> {
    return this.http.get<Curso[]>(`${this.baseUrl}/Read`).pipe(
      tap(console.log))
  }

 

  
  buscarCursoPorNome(nomeCurso: string): Observable<Curso[]>{
    let params = new HttpParams();
    params = params.set('nome', nomeCurso);
    return this.http.get<Curso[]>(`${this.baseUrl}/BuscarCursoPorNome?${params}`).pipe(
      tap(console.log))
  }

  criarCurso(formulario: any): Observable<any> {
    return this.http.post(this.baseUrl + '/criarCurso', formulario);

  }


  buscarTodosCursoPorId(pessoaId: number): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.baseUrl + '/buscarTodosCursoPorId?id=' + pessoaId);
  }
  
  

}
