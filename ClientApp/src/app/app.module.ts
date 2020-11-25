import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupName, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
      CriarCursoComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'cadastro', component: CadastroComponent },
      { path: 'aluno', component: CadastroAlunoComponent },
      { path: 'professor', component: CadastroProfessorComponent },
      { path: 'login', component: LoginComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'loja', component: LojaComponent },
      { path: 'criarCurso', component: CriarCursoComponent }
    ])
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
