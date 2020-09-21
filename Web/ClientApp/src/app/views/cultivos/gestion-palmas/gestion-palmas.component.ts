import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { Location } from '@angular/common';
import { Palma } from '../Models/palma';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PalmaService } from '../Services/Palma.service';
import { Lote } from '../Models/lote';

@Component({
	selector: 'app-gestion-palmas',
	templateUrl: './gestion-palmas.component.html',
	styleUrls: ['./gestion-palmas.component.css']
})
export class GestionPalmasComponent implements OnInit {

	public cultivoId:number;
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
		//this.ConsultarCultivo();
		this.palmaForm = this.InicializarFormulario();
	}

	public irAtras(){
		this._location.back();
	}

	private ConsultarCultivo(){
		this._palmaService.ConsultarCultivoPorId(this.cultivoId)
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
			this.palmaForm.reset({loteId: this.loteId});
			this.visualizarFormulario = false;
		})
  	}

	public AbrirModalNuevoLote(){
		this.visualizarFormulario = true;
		this.palmaForm.reset({cultivoId: this.cultivoId});
		this.accion = 'Registrar';
		this.GuardarPalma = this.RegistrarPalma;
	}
	public AbrirModalEditarLote(palma:Palma){
		this.visualizarFormulario = true;
		this.accion = 'Editar';
		this.palmaId = palma.id;
		this.palmaEstado = palma.estado;
		this.palmaForm.patchValue({
			loteId: palma.loteId,
			nombre: palma.nombre,
		});
		this.GuardarPalma = this.EditarLote;
	}

	private RegistrarPalma(){
		this.ConfirmMessage('question','','',(result)=>{
			const loteForm = this.palmaForm.value;
			this._palmaService.RegistrarLote(loteForm)
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarPalmas();
				this.ShowMessage('success',response.mensaje);
			})			
		});
	}

	private EditarLote(){
		this.ConfirmMessage('question','','',(result)=>{
			const loteForm = this.palmaForm.value;
			this._palmaService.EditarLote(this.cultivoId, this.loteId, loteForm.nombre, loteForm.numeroHectareas, this.palmaEstado)
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarPalmas();
				this.ShowMessage('success',response.mensaje);
			})
		})
	}

	public EliminarLote(lote:Lote){
		this.ConfirmMessage('warning','','',(result)=>{
			this._palmaService.InactivarLote(this.cultivoId, lote.id, lote.nombre, lote.numeroHectareas)
			.subscribe(response =>{
				if(!response) return;
				this.ShowMessage('success',response.mensaje);
				this.ConsultarPalmas();
			})
		})
	}

	private InicializarFormulario():FormGroup{
		return this._formBuilder.group({
			cultivoId: [this.cultivoId, [Validators.required]],
			nombre: [undefined, [Validators.required]],
			numeroHectareas: [undefined, [Validators.required]],
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
