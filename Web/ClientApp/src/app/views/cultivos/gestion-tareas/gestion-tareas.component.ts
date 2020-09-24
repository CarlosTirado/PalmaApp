import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Tarea } from '../Models/Tarea';
import { TareaService } from '../Services/Tarea.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gestion-tareas',
  templateUrl: './gestion-tareas.component.html',
  styleUrls: ['./gestion-tareas.component.css']
})
export class GestionTareasComponent implements OnInit {

  public tareas: Tarea[];
  public tareaForm: FormGroup;
  public visualizarFormulario: boolean = false;
  public GuardarTarea = this.RegistrarTarea;

  public accion: string;
  private tareaId: number;
  private tareaEstado: string;

  constructor(
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _tareaService: TareaService
  ) { }

  ngOnInit() {
    this.tareas = new Array<Tarea>();
    this.ConsultarTareas();
    this.tareaForm = this.InicializarFormulario();
  }

  private ConsultarTareas() {
    this._tareaService.ConsultarTareas()
      .subscribe(response => {
        if (!response) return;
        this.tareas = response;
        this.tareaForm.reset();
        this.visualizarFormulario = false;
      })
  }

  public AbrirModalNuevaTarea() {
    this.visualizarFormulario = true;
    this.tareaForm.reset();
    this.accion = 'Registrar';
    this.GuardarTarea = this.RegistrarTarea;
  }
  public AbrirModalEditarTarea(tarea: Tarea) {
    this.visualizarFormulario = true;
    this.accion = 'Editar';
    this.tareaId = tarea.id;
    this.tareaEstado = tarea.estado;
    this.tareaForm.patchValue({
      nombre: tarea.nombre,
      descripcion: tarea.descripcion
    });
    this.GuardarTarea = this.EditarTarea;
  }
  //private formatFecha(fecha: Date): string {
  //  const fechaString: string = fecha.toString().split('T')[0];
  //  return fechaString;
  //}

  private RegistrarTarea() {
    this.ConfirmMessage('question', '', '', (result) => {
      const tareaForm = this.tareaForm.value;
      this._tareaService.RegistrarTarea(tareaForm)
        .subscribe(response => {
          if (!response) return;
          this.ConsultarTareas();
          this.ShowMessage('success', response.mensaje);
        })
    });
  }

  private EditarTarea() {
    this.ConfirmMessage('question', '', '', (result) => {
      const tareaForm = this.tareaForm.value;
      this._tareaService.EditarTarea(this.tareaId, tareaForm.nombre, tareaForm.descripcion, this.tareaEstado)
        .subscribe(response => {
          if (!response) return;
          this.ConsultarTareas();
          this.ShowMessage('success', response.mensaje);
        })
    })
  }

  public EliminarTarea(tarea: Tarea) {
    this.ConfirmMessage('warning', '', '', (result) => {
      this._tareaService.InactivarTarea(tarea.id, tarea.nombre, tarea.descripcion)
        .subscribe(response => {
          if (!response) return;
          this.ShowMessage('success', response.mensaje);
          this.ConsultarTareas();
        })
    })
  }

  private InicializarFormulario(): FormGroup {
    return this._formBuilder.group({
      nombre: [undefined, [Validators.required]],
      descripcion: [undefined, [Validators.required]],
    })
  }

  private ShowMessage(type: 'success' | 'error' | 'warning' | 'info', message: string, title: string = null) {
    Swal.fire({
      title: title,
      text: message,
      icon: type /**success|error|warning|info|question**/,
      showConfirmButton: false,
      timer: 2500
    });
  }

  private ConfirmMessage(type: 'warning' | 'question', message: string, title: string = null, successEvent) {
    Swal.fire({
      icon: type,
      title: title ? title : "¿Está seguro de realizar esta operación?",
      text: message,
      showCancelButton: true,
      confirmButtonText: 'Si',
      cancelButtonText: 'No'
    })
      .then((result) => {
        if (result.value) { /**cuando doy clic en si */
          successEvent(result.value);
        }
      })
  }
}
