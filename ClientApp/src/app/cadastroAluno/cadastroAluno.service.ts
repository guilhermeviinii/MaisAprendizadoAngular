import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CadastroAlunoService {
  baseUrl = `${environment.UrlPrincipal}/api/aluno`;

  constructor(private http: HttpClient) { }

  registroAluno(aluno: any): Observable<any> {
    return this.http.post(this.baseUrl + '/registroAluno', aluno);

  }
}
