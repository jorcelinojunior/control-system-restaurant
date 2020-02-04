import { Component, Inject } from "@angular/core"
import { Router, ActivatedRoute } from "@angular/router"
import { Subscription } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { Restaurante } from "../../../models/restaurante/restaurante.model";

@Component({
  selector: "app-cadastrarrestaurante",
  templateUrl: "./cadastrar-restaurante.component.html",
  styleUrls: ["./cadastrar-restaurante.component.css"]
})

export class CadastrarRestauranteComponent {
  public restaurante;
  public restaurantes = [{ "id": 1, "nome": "Restaurante 1" }, { "id": 2, "nome": "Restaurante 2" }, { "id": 3, "nome": "Restaurante 3" }, { "id": 4, "nome": "Restaurante 4" }, { "id": 5, "nome": "Restaurante 5" }];
  public title: string = "Cadastro de Restaurante";
  public ehEdicao: boolean = false;

  public okMsg = "<i class='material-icons'>undo</i> Sim, desejo cancelar!";
  public id: number = -1;
  public URL_API: string = "";

  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.restaurante = new Restaurante();
    this.restaurante.pratos = [];
    this.URL_API = baseUrl;
  }

  ngOnInit() {
    this.route.params.subscribe(
      (params: any) => {
        if (params['id'] != null) {
          this.id = Number(params['id']);
          this.ehEdicao = true;
          this.title = "Editar Restaurante"
          this.getRestaurante(this.id);
        }
      }
    );
  }

  getRestaurante(id: number) {
    this.http.get<Restaurante[]>(this.URL_API + '/api/restaurante/' + id).subscribe(result => {
      this.restaurante.id = Number(result["id"]);
      this.restaurante.nome = result["nome"];
    }, error => console.error(error));
  }

  salvarRestaurante() {
    if (!this.ehEdicao) {
      this.http.post<Restaurante>(this.URL_API + '/api/restaurante', this.restaurante)
        .pipe().subscribe(
          success => console.log("Restaurante cadastrado com sucesso."),
          error => console.log("Error: " + JSON.stringify(error)),
          () => this.router.navigate(['/restaurantes/listar'])
        );
    } else {
      this.http.put<Restaurante>(this.URL_API + '/api/restaurante', this.restaurante)
        .pipe().subscribe(
          success => console.log("Restaurante cadastrado com sucesso."),
          error => console.log("Error: " + JSON.stringify(error)),
          () => this.router.navigate(['/restaurantes/listar'])
        );


    }
  }

  cancelarRestaurante(): void {
    this.restaurante.nome = "";
    this.router.navigate(['/restaurantes/listar']);
  }

}