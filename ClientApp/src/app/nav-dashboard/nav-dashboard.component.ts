import { Component, OnInit } from '@angular/core';
import { LojaService } from '../loja/loja.service';

@Component({
  selector: 'app-nav-dashboard',
  templateUrl: './nav-dashboard.component.html',
  styleUrls: ['./nav-dashboard.component.css']
})
export class NavDashboardComponent implements OnInit {
  public total: number;
  public itemCarrinho = new Array();

  constructor(
    private lojaService: LojaService
  ) { }

  ngOnInit() {
    this.lojaService.total;
    console.log(this.itemCarrinho = this.lojaService.itemCarrinho)

  }

  removerItem(index) {
    // for (let i of this.lojaService.itemCarrinho) {
    //   if(i == this.lojaService.itemCarrinho[index]){
    //     this.lojaService.total = this.lojaService.total - this.lojaService.itemCarrinho[index]['preco']
    //     this.lojaService.itemCarrinho.splice(index, 1);
    //   }
    for (var i in this.lojaService.itemCarrinho) {
      if (i == index) {
        this.lojaService.total = this.lojaService.total - this.lojaService.itemCarrinho[index]['preco']
        this.lojaService.itemCarrinho.splice(index, 1);
      }
      console.log(this.lojaService.itemCarrinho)

    }
  }


}
