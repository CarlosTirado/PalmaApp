import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Usuario } from '../Models/Usuario';
import { UsuarioService } from '../Services/Usuario.service';

@Component({
  selector: 'app-gestion-usuarios',
  templateUrl: './gestion-usuarios.component.html',
  styleUrls: ['./gestion-usuarios.component.css']
})
export class GestionUsuariosComponent implements OnInit {

  public Usuario:Usuario[]

  constructor(
    private _formBuilder: FormBuilder,
    private _usuarioService: UsuarioService
  ) { }

  ngOnInit() {
    this.Usuario = new Array<Usuario>();
   // this.ConsultarCultivos();
  }

  private ConsultarCultivos() {
    this._usuarioService.ConsultarUsuarios()
      .subscribe(response => {
        if (!response) return;
        this.Usuario = response;
      })
  }

}
