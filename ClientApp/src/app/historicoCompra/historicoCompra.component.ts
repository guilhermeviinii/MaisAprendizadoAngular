import { Component, OnInit } from '@angular/core';
import { AuthService } from '../login/auth.service';
import { Pessoa } from '../models/Usuario';

@Component({
  selector: 'app-historicoCompra',
  templateUrl: './historicoCompra.component.html',
  styleUrls: ['./historicoCompra.component.css']
})
export class HistoricoCompraComponent implements OnInit {
  public HistCompra: any;
  public pessoa: Pessoa;
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.pessoa = this.authService.dadosUsuarioLogado()
    console.log(this.pessoa)
    this.historicoCompra(this.pessoa.pessoaId)
    
  }

  historicoCompra(pessoa: any) {
    this.authService.historicoCompra(pessoa).subscribe((resp) =>{
      this.HistCompra = resp;
    })

  }

}
