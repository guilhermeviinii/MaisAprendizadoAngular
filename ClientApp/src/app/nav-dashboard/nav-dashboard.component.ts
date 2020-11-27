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

  
}
