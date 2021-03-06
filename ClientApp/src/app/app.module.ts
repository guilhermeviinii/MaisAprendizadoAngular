import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownConfig, BsDropdownModule } from "ngx-bootstrap/dropdown";
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { CadastroAlunoComponent } from './cadastroAluno/cadastroAluno.component';
import { CadastroProfessorComponent } from './cadastroProfessor/cadastroProfessor.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavDashboardComponent } from './nav-dashboard/nav-dashboard.component';
import { LojaComponent } from './loja/loja.component';
import { CursoComponent } from './curso/curso.component';
import { CriarCursoComponent } from './criarCurso/criarCurso.component';
import { AuthService } from './login/auth.service';
import { AuthGuard } from './guards/auth.guard';
import { PerfilComponent } from './perfil/perfil.component';
import { CursoPerfilComponent } from './cursoPerfil/cursoPerfil.component';
import { FinalizaCompraComponent } from './finalizaCompra/finalizaCompra.component';
import { CursoCriadoPerfilComponent, DialogsExampleComponent } from './cursoCriadoPerfil/cursoCriadoPerfil.component';
import { MatButton, MatButtonModule, MatNativeDateModule } from '@angular/material';
import {MatDialog, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import { HistoricoCompraComponent } from './historicoCompra/historicoCompra.component';
import { DemoMaterialModule } from './cursoCriadoPerfil/material-module';

@NgModule({
  declarations: [				
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterComponent,
    CadastroComponent,
    CadastroAlunoComponent,
    CadastroProfessorComponent,
    LoginComponent,
    DashboardComponent,
    NavDashboardComponent,
    LojaComponent,
    CursoComponent,
    CriarCursoComponent,
    PerfilComponent,
    CursoPerfilComponent,
      FinalizaCompraComponent,
      CursoCriadoPerfilComponent,
      DialogsExampleComponent,
      HistoricoCompraComponent
   ],
   entryComponents: [DialogsExampleComponent, CursoCriadoPerfilComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatDialogModule,
    DemoMaterialModule,
    MatNativeDateModule,    
    DemoMaterialModule,
    FormsModule,
    //  BsDropdownModule.forRoot(),
    //   BrowserAnimationsModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent, pathMatch: 'full'
      },
      {
        path: 'cadastro',
        component: CadastroComponent
      },
      {
        path: 'aluno',
        component: CadastroAlunoComponent
      },
      {
        path: 'professor',
        component: CadastroProfessorComponent
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'dashboard',
        canActivate: [AuthGuard],
        component: DashboardComponent
      },
      {
        path: 'loja',
        canActivate: [AuthGuard],
        component: LojaComponent
      },
      {
        path: 'criarCurso',
        canActivate: [AuthGuard],
        component: CriarCursoComponent
      },
      {
        path: 'finalizaCompra',
        canActivate: [AuthGuard],
        component: FinalizaCompraComponent
      },
      {
        path: 'perfil',
        canActivate: [AuthGuard],
        component: PerfilComponent
      },
      {
        path: 'historicoCompra',
        canActivate: [AuthGuard],
        component: HistoricoCompraComponent
      },
      {
        path: 'perfil',
        canActivate: [AuthGuard],
        component: DialogsExampleComponent
      }
    ]),
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [AuthService, AuthGuard, BsDropdownConfig, MatButton, MatDialog
  ],
  bootstrap: [AppComponent, CursoCriadoPerfilComponent]
})
export class AppModule { }
