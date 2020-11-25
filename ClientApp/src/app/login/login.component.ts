import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';
import { Usuario } from './usuario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  alerta: boolean;

  private usuario: Usuario = new Usuario();
  
  

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.alerta = false;
  }

  
  logar(){
    // console.log(this.usuario)
    this.authService.fazerLogion(this.usuario)
  }

}
