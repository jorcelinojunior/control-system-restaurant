import { Component, Inject } from "@angular/core"
import { Router, ActivatedRoute } from "@angular/router"
import { Subscription } from "rxjs"
import { HttpClient } from '@angular/common/http';
import { SelectControlValueAccessor } from '@angular/forms';

import { Prato } from "./../../../models/prato/prato.model"
import { Restaurante } from "./../../../models/restaurante/restaurante.model"

@Component({
  selector: "app-cadastrarprato",
  templateUrl: "./cadastrar-prato.component.html",
  styleUrls: ["./cadastrar-prato.component.css"]
})

export class CadastrarPratoComponent {
  public prato;
  public pratos = [];
  public restaurantes = [];

  public title: string = "Cadastro de Prato";
  public ehEdicao: boolean = false;

  public okMsg = "<i class='material-icons'>undo</i> Sim, desejo cancelar!";
  public id: number = -1;
  public inscricao: Subscription;
  public URL_API: string = "";

  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.prato = new Prato();
    this.URL_API = baseUrl;
    this.carregaRestaurantes();
  }

  ngOnInit() {
    this.route.params.subscribe(
      (params: any) => {
        if (params['id'] != null) {
          this.id = Number(params['id']);
          this.ehEdicao = true;
          this.title = "Editar Prato"
          this.getPrato(this.id);
        }
      }
    );
  }
  carregaRestaurantes() {
    this.http.get<Restaurante[]>(this.URL_API + '/api/restaurante').subscribe(result => {
      this.restaurantes = result;
      //console.log("Restaurantes: "+JSON.stringify(result));
    }, error => console.error(error));
  }
  getPrato(id: number) {
    this.http.get<Prato[]>(this.URL_API + '/api/prato/' + id).subscribe(result => {
      this.prato.id = Number(result["id"]);
      this.prato.nome = result["nome"];
      this.prato.restauranteId = Number(result["restauranteId"]);
      this.prato.preco = Number(result["preco"]);
    }, error => console.error(error));
  }

  cadastrarPrato() {
    if (!this.ehEdicao) {
      this.http.post<Prato>(this.URL_API + '/api/prato', this.prato)
        .pipe().subscribe(
          success => console.log("Prato cadastrado com sucesso."),
          error => console.log("Error: " + JSON.stringify(error)),
          () => this.router.navigate(['/pratos/listar'])
        );
    } else {
      this.http.put<Prato>(this.URL_API + '/api/prato', this.prato)
        .pipe().subscribe(
          success => console.log("Prato editado com sucesso."),
          error => console.log("Error: " + JSON.stringify(error)),
          () => this.router.navigate(['/pratos/listar'])
        );
    }
  }

  cancelarPrato(): void {
    this.prato.restauranteId = -1;
    this.prato.nome = "";
    this.prato.preco = 0.0;
    this.router.navigate(['/pratos/listar']);
  }

}

