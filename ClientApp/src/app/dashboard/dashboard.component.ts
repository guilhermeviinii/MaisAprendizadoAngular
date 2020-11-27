import { Component, OnInit } from '@angular/core';
import { AuthService } from '../login/auth.service';
import { Pessoa } from '../models/Usuario';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public pessoa: Pessoa  = new Pessoa();

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.pessoa = this.authService.dadosUsuarioLogado()
  }

}
