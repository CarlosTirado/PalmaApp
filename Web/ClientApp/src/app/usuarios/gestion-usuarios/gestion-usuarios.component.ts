import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule  } from '@angular/forms';
import { Usuario } from '../Models/Usuario';
import { UsuarioService } from '../Services/Usuario.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';

@Component({
  selector: 'app-gestion-usuarios',
  templateUrl: './gestion-usuarios.component.html',
  styleUrls: ['./gestion-usuarios.component.css']
})


export class GestionUsuariosComponent implements OnInit {

  public Usuario: Usuario[];
  public usuarioForm: FormGroup;
  //public visualizarFormulario: boolean = false;
  //public GuardarUsuario = this.EditarUsuario;
  //public accion: string;
  //private usuarioId: number;
  //private usuarioEstado: string;

  constructor(
    private _formBuilder: FormBuilder,
    private _usuarioService: UsuarioService

  ) { }

  ngOnInit() {
    this.Usuario = new Array<Usuario>();
    this.ConsultarUsuario();
    //this.usuarioForm = this.InicializarFormulario();
  }

  private ConsultarUsuario() {
    this._usuarioService.ConsultarUsuarios()
      .subscribe(response => {
        if (!response) return;
        this.Usuario = response;
        //this.usuarioForm.reset();
        //this.visualizarFormulario = false;
      })
  }

  //public AbrirModalEditarUsuario(usuario: Usuario) {
  //  this.visualizarFormulario = true;
  //  this.accion = 'Editar';
  //  this.usuarioId = usuario.identificacion;
  //  this.usuarioEstado = usuario.estado;
  //  this.usuarioForm.patchValue({
  //    nombre: usuario.nombres,
  //    apellidos: usuario.apellidos,
  //    fechaNacimiento: this.formatFecha(usuario.fechaNacimiento),
  //    telefono: usuario.telefono,
  //    email: usuario.email,
  //  });
  //  this.GuardarUsuario = this.EditarUsuario;
  //}
  //private formatFecha(fecha: Date): string {
  //  const fechaString: string = fecha.toString().split('T')[0];
  //  return fechaString;
  //}

  //private EditarUsuario() {
  //  this.ConfirmMessage('question', '', '', (result) => {
  //    const usuarioForm = this.usuarioForm.value;
  //    this._usuarioService.EditarUsuario(this.usuarioId, usuarioForm.nombre, usuarioForm.apellido, usuarioForm.fechaNacimiento, this.usuarioEstado)
  //      .subscribe(response => {
  //        if (!response) return;
  //        this.ConsultarUsuario();
  //        this.ShowMessage('success', response.mensaje);
  //      })
  //  })
  //}
  //private InicializarFormulario(): FormGroup {
  //  return this._formBuilder.group({
  //    nombre: [undefined, [Validators.required]],
  //    fechaNacimiento: [undefined, [Validators.required]],
  //  })
  //}

  //private ShowMessage(type: 'success' | 'error' | 'warning' | 'info', message: string, title: string = null) {
  //  Swal.fire({
  //    title: title,
  //    text: message,
  //    icon: type /**success|error|warning|info|question**/,
  //    showConfirmButton: false,
  //    timer: 2500
  //  });
  //}

  //private ConfirmMessage(type: 'warning' | 'question', message: string, title: string = null, successEvent) {
  //  Swal.fire({
  //    icon: type,
  //    title: title ? title : "¿Está seguro de realizar esta operación?",
  //    text: message,
  //    showCancelButton: true,
  //    confirmButtonText: 'Si',
  //    cancelButtonText: 'No'
  //  })
  //    .then((result) => {
  //      if (result.value) { /**cuando doy clic en si */
  //        successEvent(result.value);
  //      }
  //    })
  //}
}
