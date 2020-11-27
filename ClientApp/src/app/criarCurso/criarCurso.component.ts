import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LojaService } from '../loja/loja.service';

@Component({
  selector: 'app-criarCurso',
  templateUrl: './criarCurso.component.html',
  styleUrls: ['./criarCurso.component.css']
})
export class CriarCursoComponent implements OnInit {
  baseUrl = `${environment.UrlPrincipal}/api/curso`;

  public formulario: FormGroup;
  public formData: any;

  constructor(public fb: FormBuilder, private http: HttpClient, private lojaService: LojaService) { }

  ngOnInit() {
    this.formulario = this.fb.group({
      nome: [null, Validators.required],
      preco: [null, Validators.required],
      cargaHoraria: [null, Validators.required]

    })
  }
  inputFileChange(evento){
    if(evento.target.files && evento.target.files[0]){
      const foto = evento.target.files[0];
       this.formData = new FormData();
      this.formData.append('foto', foto)
    }
  }

  criarCurso() {
    
    return this.lojaService.criarCurso(this.formulario.value, this.formData).subscribe((retorno) => {
      console.log(retorno);
    });

  }
}
