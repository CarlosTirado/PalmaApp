import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { Location } from '@angular/common';
import { Palma } from '../Models/palma';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GestionPalmaRequest, PalmaService } from '../Services/Palma.service';
import { Lote } from '../Models/lote';
import { Cultivo } from '../Models/cultivo';

@Component({
	selector: 'app-gestion-palmas',
	templateUrl: './gestion-palmas.component.html',
	styleUrls: ['./gestion-palmas.component.css']
})
export class GestionPalmasComponent implements OnInit {

	public cultivoId:number;
	public cultivo:Cultivo;
	
	public loteId:number;
	public lote:Lote;
	
	public palmas:Palma[];
	public palmaForm:FormGroup;
	public visualizarFormulario: boolean = false;
	public GuardarPalma = this.RegistrarPalma;

	public accion:string;

  	private palmaId:number;
  	private palmaEstado:string;
  
	constructor(
		private _formBuilder: FormBuilder,
		private _routerActivated: ActivatedRoute,
		private _router:Router,
		private _location: Location,
		private _palmaService: PalmaService
	) { }

	ngOnInit() {
		this.cultivoId = Number(this._routerActivated.snapshot.paramMap.get('cultivoId'));
		this.loteId = Number(this._routerActivated.snapshot.paramMap.get('loteId'));
		if(isNaN(this.cultivoId) || !this.cultivoId || isNaN(this.loteId) || !this.loteId){
			this.ShowMessage('error', "Para realizar la gestión palmas debe enviar un lote", "Ocurrió un Error");
			this.irAtras();
		}
		this.palmas = new Array<Palma>();
		this.ConsultarCultivo();
		this.ConsultarLote();

		this.palmaForm = this.InicializarFormulario();
	}

	public irAtras(){
		this._location.back();
	}

	private ConsultarCultivo(){
		this._palmaService.ConsultarCultivoPorId(this.cultivoId)
		.subscribe(response =>{
			if(!response) return;
			this.cultivo = response;
		})
	}
  
	private ConsultarLote(){
		this._palmaService.ConsultarLotePorId(this.loteId)
		.subscribe(response =>{
			if(!response) return;
			this.lote = response;
			this.ConsultarPalmas();
		})
	}
	  
  	private ConsultarPalmas(){
		this._palmaService.ConsultarPalmasDeUnLote(this.lote.id)
		.subscribe(response =>{
			if(!response) return;
			this.palmas = response;
			this.palmaForm.reset();
			this.visualizarFormulario = false;
		})
  	}

	public AbrirModalNuevaPalma(){
		this.visualizarFormulario = true;
		this.palmaForm.reset();
		this.accion = 'Registrar';
		this.GuardarPalma = this.RegistrarPalma;
	}
	public AbrirModalEditarPalma(palma:Palma){
		this.visualizarFormulario = true;
		this.accion = 'Editar';
		this.palmaId = palma.id;
		this.palmaEstado = palma.estado;
		this.palmaForm.patchValue({
			altura: palma.altura,
			descripcion: palma.descripcion,
			fechaSiembra: this.formatFecha(palma.fechaSiembra)
		});
		this.GuardarPalma = this.EditarPalma;
	}
	private formatFecha(fecha:Date):string{
		const fechaString:string = fecha.toString().split('T')[0];
		return fechaString;
	}

	private ArmarRequest():GestionPalmaRequest{
		const palmaForm = this.palmaForm.value;
		return {
			cultivoId: this.cultivoId,
			loteId: this.loteId,
			altura: palmaForm.altura,
			descripcion: palmaForm.descripcion,
			fechaSiembra: palmaForm.fechaSiembra,
			palmaId: this.palmaId,
			estado: this.palmaEstado,
		}
	}
	private RegistrarPalma(){
		this.ConfirmMessage('question','','',(result)=>{
			this._palmaService.RegistrarPalma(this.ArmarRequest())
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarPalmas();
				this.ShowMessage('success',response.mensaje);
			})			
		});
	}

	private EditarPalma(){
		this.ConfirmMessage('question','','',(result)=>{
			const loteForm = this.palmaForm.value;
			this._palmaService.EditarPalma(this.ArmarRequest())
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarPalmas();
				this.ShowMessage('success',response.mensaje);
			})
		})
	}

	public EliminarPalma(palma:Palma){
		this.ConfirmMessage('warning','','',(result)=>{
			let eliminarPalmaRequest: GestionPalmaRequest ={
				altura: palma.altura,
				descripcion: palma.descripcion,
				fechaSiembra: palma.fechaSiembra,
				palmaId: palma.id
			};
			this._palmaService.InactivarPalma(eliminarPalmaRequest)
			.subscribe(response =>{
				if(!response) return;
				this.ShowMessage('success',response.mensaje);
				this.ConsultarPalmas();
			})
		})
	}

	private InicializarFormulario():FormGroup{
		return this._formBuilder.group({
			altura:[0, [Validators.required]],
			descripcion:[undefined, [Validators.required]],
			fechaSiembra:[undefined, [Validators.required]],
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

}
