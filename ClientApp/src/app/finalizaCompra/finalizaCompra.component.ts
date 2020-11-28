import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LojaService } from '../loja/loja.service';
import { ComprasService } from './compras.service';

@Component({
  selector: 'app-finalizaCompra',
  templateUrl: './finalizaCompra.component.html',
  styleUrls: ['./finalizaCompra.component.css']
})
export class FinalizaCompraComponent implements OnInit {
  public itemParaFinalizar = new Array();

  constructor(private lojaService: LojaService, private comprasService: ComprasService, private http: HttpClient) { }

  ngOnInit() {
    console.log(this.itemParaFinalizar = this.lojaService.itemCarrinho)

  }
  apagarCarrinho() {
    this.lojaService.itemCarrinho = []
  }

  comprarCurso(cursos) {
    var params = new HttpParams();
    for (let key of cursos) {
      key
        params = params
          .set('IdCurso', key["idCurso"])
          .set('PessoaId', key["pessoaId"])
          .set('Nome', key["nome"])
          .set('Valor', key["preco"])
      ;
      this.comprasService.comprarCurso({params: params}).subscribe((retorno) => {
        console.log(retorno);
      });
      // params = params.set('IdCurso', cursos[i]["idCurso"])
      //   .set('pessoaId', cursos[i]['pessoaId'])
      //   .set('nome', cursos[i]['nome'])
      //   .set('valor', cursos[i]['preco'])
      //   ;
      //  console.log(params['updates'])

      console.log(params)


    }

  }

}
