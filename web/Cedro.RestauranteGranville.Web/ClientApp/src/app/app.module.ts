import { BrowserModule }     from '@angular/platform-browser';
import { NgModule }          from '@angular/core';
import { FormsModule }       from '@angular/forms';
import { HttpClientModule }  from '@angular/common/http';
import { RouterModule }      from '@angular/router';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { NgxMaskModule }     from 'ngx-mask';
import { NgxCurrencyModule } from "ngx-currency";

import { AppComponent }                  from './app.component';
import { NavMenuComponent }              from './components/nav-menu/nav-menu.component';
import { HomeComponent }                 from './components/home/home.component';
import { LoginComponent }                from './components/usuario/login/login.component';
import { ListarPratosComponent }         from './components/prato/listar/listar-pratos.component';
import { CadastrarPratoComponent }       from './components/prato/cadastrar/cadastrar-prato.component';
import { ListarRestaurantesComponent }    from './components/restaurante/listar/listar-restaurantes.component';
import { CadastrarRestauranteComponent } from './components/restaurante/cadastrar/cadastrar-restaurante.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ListarPratosComponent,
    CadastrarPratoComponent,
    ListarRestaurantesComponent,
    CadastrarRestauranteComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '',                           component: HomeComponent, pathMatch: 'full' },
      { path: 'entrar',                     component: LoginComponent },
      { path: 'pratos/listar',              component: ListarPratosComponent },
      { path: 'pratos/cadastrar',           component: CadastrarPratoComponent },
      { path: 'pratos/cadastrar/:id',       component: CadastrarPratoComponent },
      { path: 'restaurantes/listar',        component: ListarRestaurantesComponent},
      { path: 'restaurantes/cadastrar',     component: CadastrarRestauranteComponent },
      { path: 'restaurantes/cadastrar/:id', component: CadastrarRestauranteComponent },
    ]),
    SweetAlert2Module.forRoot({
        buttonsStyling: false,
        customClass: 'modal-content',
        confirmButtonClass: 'btn btn-primary',
        cancelButtonClass: 'btn'
    }),
    NgxMaskModule.forRoot(),
    NgxCurrencyModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }