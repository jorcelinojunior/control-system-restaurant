import { Component } from "@angular/core";
import { Usuario } from "../../../models/usuario/usuario.model";
@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]

})
export class LoginComponent {
  public usuario;
  public usuarioAutenticado: boolean;
  public usuarios = ["Usuari-1","Usuari-2","Usuari-3","Usuari-4", "Usuari-5"]

  constructor() {
    this.usuario = new Usuario();
  }

  public enderecoLogo = "../../../assets/image/Logo-Granville.png";

  entrar() : void {
    if (this.usuario.email == "jorcelino@live.com" && this.usuario.senha == "123456") {
      this.usuarioAutenticado = true;
    }
    alert(this.usuario.email + " - " + this.usuario.senha);
  }
}