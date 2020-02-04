import { Component, Inject } from "@angular/core"
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';

import { Prato } from "../../../models/prato/prato.model";

@Component({
  selector: "app-listarprato",
  templateUrl: "./listar-pratos.component.html",
  styleUrls: ["./listar-pratos.component.css"]
})

export class ListarPratosComponent {
  public prato;
  //public pratos = [ { "id": 1, "restauranteId": "Restaurante 1", "nome": "Macarrão", "preco": 20.00 }, { "id": 2, "restauranteId": "Restaurante 2", "nome": "Lasanha", "preco": 28.00 }, { "id": 3, "restauranteId": "Restaurante 3", "nome": "Peixe", "preco": 20.00 }, { "id": 4, "restauranteId": "Restaurante 4", "nome": "Arroz", "preco": 10.00 }, { "id": 5, "restauranteId": "Restaurante 5", "nome": "Batata Frita", "preco": 14.00 } ]
  public pratos = [];
  public URL_API: string = "";
  public okMsg = "<i class='material-icons'>delete</i> Sim, desejo deletar!";

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.prato = new Prato();
    this.URL_API = baseUrl;
    this.getPratos();
  }

  getPratos() {
    this.http.get<Prato[]>(this.URL_API + '/api/prato').subscribe(result => {
      this.pratos = result;
    }, error => console.error(error));
  }

  deletarPrato(id: number): void {
    if (window.confirm("Você deseja excluir o prato?")) {
        this.http.delete<Prato[]>(this.URL_API + '/api/prato/'+id)
          .pipe().subscribe(
            success => window.location.reload(),
            error => console.log("Error: " + JSON.stringify(error)),
            () => this.router.navigate(['/pratos/listar'])
          );
    }
  }
}
