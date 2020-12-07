import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ComprasService {
  baseUrl = `${environment.UrlPrincipal}/api/compras`;

constructor(private http: HttpClient) { }


comprarCurso(key){
  return this.http.post(this.baseUrl + '/comprar', key);
}

}


