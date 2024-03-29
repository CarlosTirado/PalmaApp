import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cultivo } from '../Models/cultivo';
import { CultivoService } from '../Services/Cultivo.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gestion-cultivos',
  templateUrl: './gestion-cultivos.component.html',
  styleUrls: ['./gestion-cultivos.component.css']
})
export class GestionCultivosComponent implements OnInit {

	public cultivos:Cultivo[];
	public cultivoForm:FormGroup;
	public visualizarFormulario: boolean = false;
	public GuardarCultivo = this.RegistrarCultivo;
	public accion:string;
	private cultivoId:number;
  private cultivoEstado: string;
  @ViewChild('bodyGestionCultivos', { static: false }) public bodyGestionCultivos: ElementRef;

	constructor(
		private _formBuilder: FormBuilder,
		private _router:Router,
		private _cultivoService: CultivoService
	) { }
	public ngOnInit() {
		this.cultivos = new Array<Cultivo>();
		this.ConsultarCultivos();
		this.cultivoForm = this.InicializarFormulario();
  }
	public IrAGestionLotes(cultivo:Cultivo){
		this._router.navigate([`/cultivos/${cultivo.id}/Lotes`]);
	}	
	private ConsultarCultivos(){
		this._cultivoService.ConsultarCultivos()
		.subscribe(response =>{
			if(!response) return;
			this.cultivos = response;
			this.cultivoForm.reset();
      this.visualizarFormulario = false;
      this.DibujarTabla();
		})
	}
	public AbrirModalNuevoCultivo(){
		this.visualizarFormulario = true;
		this.cultivoForm.reset();
		this.accion = 'Registrar';
		this.GuardarCultivo = this.RegistrarCultivo;
	}
	public AbrirModalEditarCultivo(cultivo:Cultivo){
		this.visualizarFormulario = true;
		this.accion = 'Editar';
		this.cultivoId = cultivo.id;
		this.cultivoEstado = cultivo.estado;
		this.cultivoForm.patchValue({
			nombre: cultivo.nombre,
			fechaSiembra: this.formatFecha(cultivo.fechaSiembra)
		});
		this.GuardarCultivo = this.EditarCultivo;
	}
	private formatFecha(fecha:Date):string{
		const fechaString:string = fecha.toString().split('T')[0];
		return fechaString;
	}
	private RegistrarCultivo(){
		this.ConfirmMessage('question','','',(result)=>{
			const cultivoForm = this.cultivoForm.value;
			this._cultivoService.RegistrarCultivo(cultivoForm)
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarCultivos();
				this.ShowMessage('success',response.mensaje);
			})			
		});
	}
	private EditarCultivo(){
		this.ConfirmMessage('question','','',(result)=>{
			const cultivoForm = this.cultivoForm.value;
			this._cultivoService.EditarCultivo(this.cultivoId, cultivoForm.nombre, cultivoForm.fechaSiembra, this.cultivoEstado)
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarCultivos();
				this.ShowMessage('success',response.mensaje);
			})
		})
	}
	public EliminarCultivo(cultivo:Cultivo){
		this.ConfirmMessage('warning','','',(result)=>{
			this._cultivoService.InactivarCultivo(cultivo.id, cultivo.nombre, cultivo.fechaSiembra)
			.subscribe(response =>{
				if(!response) return;
				this.ShowMessage('success',response.mensaje);
				this.ConsultarCultivos();
			})
		})
	}
	private InicializarFormulario():FormGroup{
		return this._formBuilder.group({
			nombre: [undefined, [Validators.required]],
			fechaSiembra: [undefined, [Validators.required]],
		})
	}
	private ShowMessage(type:'success'|'error'|'warning'|'info',message:string, title:string=null){
		Swal.fire({
			title: title,
			text: message,
			icon: type /**success|error|warning|info|question**/,
			showConfirmButton: false,
			timer: 2500
		  });
	}
	private ConfirmMessage(type:'warning'|'question', message:string, title:string=null, successEvent){
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
  private DibujarTabla() {
    var filasTabla = "";
    this.cultivos.forEach((cultivo,index) => {
      filasTabla =
        "<tr>" +
          "<td class='text-center'>" + index + 1 + "</td>" +
          "<td>" + cultivo.nombre + "</td>" +
          "<td class='text-center'>" + cultivo.fechaSiembra + "</td>" +
          "<td class='text-center'>" + cultivo.estado + "</td>" +
          "<td class='text-center'>Lotes - Editar - Eliminar</td>" +
        "</tr>";

    });

    this.bodyGestionCultivos.nativeElement.insertAdjacentHTML('beforeend', filasTabla);

  }
}
