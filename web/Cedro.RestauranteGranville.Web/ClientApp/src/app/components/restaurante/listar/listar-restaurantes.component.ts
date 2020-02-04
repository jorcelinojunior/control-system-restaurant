import { Component, Inject } from "@angular/core"
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';

import { Restaurante } from "../../../models/restaurante/restaurante.model";

@Component({
  selector: "app-listarrestaurante",
  templateUrl: "./listar-restaurantes.component.html",
  styleUrls: ["./listar-restaurantes.component.css"]
})

export class ListarRestaurantesComponent {
  public restaurante;
  public restaurantes = [];
  public okMsg = "<i class='material-icons'>delete</i> Sim, desejo deletar!";
  public URL_API: string = "";
  public chave: string = "";

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.restaurante = new Restaurante();
    this.URL_API = baseUrl;
    this.getRestaurantes();
  }

  getRestaurantes() {
    this.http.get<Restaurante[]>(this.URL_API + '/api/restaurante').subscribe(result => {
      this.restaurantes = result;
    }, error => console.error(error));
  }

  pesquisarRestaurantes(_chave: string): void {
    this.http.get<Restaurante[]>(this.URL_API + '/api/restaurante/pesquisar/' + _chave).subscribe(result => {
      this.restaurantes = result;
    }, error => console.error(error));
  }

  deletarRestaurante(id: number): void {
    if (window.confirm("Você deseja excluir o restaurante e todos os pratos associados a ele?")) {
      this.http.delete<Restaurante[]>(this.URL_API + '/api/restaurante/' + id)
        .pipe().subscribe(
          success => window.location.reload(),
          error => console.log("Error: " + JSON.stringify(error)),
          () => this.router.navigate(['/restaurantes/listar'])
        );
    }
  }
}
