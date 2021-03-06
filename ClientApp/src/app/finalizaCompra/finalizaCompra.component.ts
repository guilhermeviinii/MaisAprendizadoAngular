import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthService } from '../login/auth.service';
import { LojaService } from '../loja/loja.service';
import { ComprasService } from './compras.service';

@Component({
  selector: 'app-finalizaCompra',
  templateUrl: './finalizaCompra.component.html',
  styleUrls: ['./finalizaCompra.component.css']
})
export class FinalizaCompraComponent implements OnInit {
  public itemParaFinalizar = new Array();

  constructor(public route: Router,private lojaService: LojaService, private authService: AuthService, private comprasService: ComprasService, private http: HttpClient) { }

  ngOnInit() {
    console.log(this.itemParaFinalizar = this.lojaService.itemCarrinho)

  }
  apagarCarrinho() {
    this.lojaService.itemCarrinho = []
  }

  comprarCurso(cursos) {
    for (let key of cursos) {
      key.alunoid = this.authService.pessoa.pessoaId
      console.log(key)
      this.comprasService.comprarCurso(key).subscribe((retorno) => {
        console.log(retorno);
        this.apagarCarrinho()
        this.route.navigate(['dashboard'])
       
      });
      // params = params.set('IdCurso', cursos[i]["idCurso"])
      //   .set('pessoaId', cursos[i]['pessoaId'])
      //   .set('nome', cursos[i]['nome'])
      //   .set('valor', cursos[i]['preco'])
      //   ;
      //  console.log(params['updates'])

      console.log(key)


    }

  }

}
