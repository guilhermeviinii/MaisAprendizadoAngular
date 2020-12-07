import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AuthService } from '../login/auth.service';
import { LojaService } from '../loja/loja.service';
import { Curso } from '../models/Curso';
import { PerfilService } from '../perfil/perfil.service';

@Component({
  selector: 'app-cursoCriadoPerfil',
  templateUrl: './cursoCriadoPerfil.component.html',
  styleUrls: ['./cursoCriadoPerfil.component.css']
})
export class CursoCriadoPerfilComponent implements OnInit {
  public cursosCriado: Curso;
  @Input() titulo: string;
  @Input() idCurso: string;
  
  constructor( public dialog: MatDialog, public fb: FormBuilder, private perfil: PerfilService, private authService: AuthService, private lojaService: LojaService) { }
  ngOnInit() {

  }
  openDialog() {
    const dialogRef = this.dialog.open(DialogsExampleComponent, {
      data: {idCurso: this.idCurso}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
@Component({
  selector: 'app-modal',
  templateUrl: './dialogsExample.component.html',
  styleUrls: ['./cursoCriadoPerfil.component.css']
})
export class DialogsExampleComponent  {

  public formulario: FormGroup;
  public formData: any;
  constructor(public dialogRef: MatDialogRef<DialogsExampleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {idCurso: any}, public form: FormBuilder, public dialog: MatDialog, public fb: FormBuilder, private perfil: PerfilService, private authService: AuthService, public loja: LojaService) { }
  public cursosCriado: Curso;
  ngOnInit() {
    this.formulario = this.form.group({
      pessoaId: [this.authService.pessoa.pessoaId],
      idCurso: [this.data.idCurso],
      nome: [null, Validators.required],
      preco: [null, Validators.required],
      cargaHoraria: [null, Validators.required]

    })
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  editarCurso() {
    console.log(this.formulario)    
    this.loja.editarCurso(this.formulario.value).subscribe((retorno) => {
      console.log(retorno);
    });

  }

}


