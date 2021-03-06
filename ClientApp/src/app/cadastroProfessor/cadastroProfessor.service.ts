import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CadastroProfessorService {
  baseUrl = `${environment.UrlPrincipal}/api/professor`;

  constructor(private http: HttpClient) { }

  registroProfessor(professor: any): Observable<any> {
    return this.http.post(this.baseUrl + '/registroProfessor', professor);

  }

}

