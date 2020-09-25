import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cultivo } from '../Models/cultivo';
import { LoteService } from '../Services/Lote.service';
import { Lote } from '../Models/lote';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { Location } from '@angular/common';

@Component({
  selector: 'app-gestion-lotes',
  templateUrl: './gestion-lotes.component.html',
  styleUrls: ['./gestion-lotes.component.css']
})
export class GestionLotesComponent implements OnInit {

	public cultivoId:number;
	public cultivo:Cultivo;
	
	public lotes:Lote[];
	public loteId:number;
	public loteForm:FormGroup;
	public visualizarFormulario: boolean = false;
	public GuardarLote = this.RegistrarLote;

	public accion:string;
  	private loteEstado:string;
  
	constructor(
		private _formBuilder: FormBuilder,
		private _routerActivated: ActivatedRoute,
		private _router:Router,
		private _location: Location,
		private _loteService: LoteService
	) { }

	ngOnInit() {
		this.cultivoId = Number(this._routerActivated.snapshot.paramMap.get('cultivoId'));
		if(isNaN(this.cultivoId) || !this.cultivoId){
			this.ShowMessage('error', "Para realizar la gestión de lotes debe enviar un cultivo", "Ocurrió un Error");
			this.irAtras();
		}
		this.lotes = new Array<Lote>();
		this.ConsultarCultivo();
		this.loteForm = this.InicializarFormulario();
	}

	public irAtras(){
		this._location.back();
	}

  public IrAGestionPalmas(lote: Lote) {
		this._router.navigate([`/cultivos/${this.cultivoId}/Lotes/${lote.id}/Palmas`]);
	}	

	private ConsultarCultivo(){
		this._loteService.ConsultarCultivoPorId(this.cultivoId)
		.subscribe(response =>{
			if(!response) return;
			this.cultivo = response;
			this.ConsultarLotes();
		})
	}
  
  	private ConsultarLotes(){
		this._loteService.ConsultarLotesDeUnCultivo(this.cultivo.id)
		.subscribe(response =>{
			if(!response) return;
			this.lotes = response;
			this.loteForm.reset({cultivoId: this.cultivoId});
			this.visualizarFormulario = false;
		})
  	}

	public AbrirModalNuevoLote(){
		this.visualizarFormulario = true;
		this.loteForm.reset({cultivoId: this.cultivoId});
		this.accion = 'Registrar';
		this.GuardarLote = this.RegistrarLote;
	}
	public AbrirModalEditarLote(lote:Lote){
		this.visualizarFormulario = true;
		this.accion = 'Editar';
		this.loteId = lote.id;
		this.loteEstado = lote.estado;
		this.loteForm.patchValue({
			cultivoId: lote.cultivoId,
			nombre: lote.nombre,
			numeroHectareas: lote.numeroHectareas
		});
		this.GuardarLote = this.EditarLote;
	}

	private RegistrarLote(){
		this.ConfirmMessage('question','','',(result)=>{
			const loteForm = this.loteForm.value;
			this._loteService.RegistrarLote(loteForm)
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarLotes();
				this.ShowMessage('success',response.mensaje);
			})			
		});
	}

	private EditarLote(){
		this.ConfirmMessage('question','','',(result)=>{
			const loteForm = this.loteForm.value;
			this._loteService.EditarLote(this.cultivoId, this.loteId, loteForm.nombre, loteForm.numeroHectareas, this.loteEstado)
			.subscribe(response =>{
				if(!response) return;
				this.ConsultarLotes();
				this.ShowMessage('success',response.mensaje);
			})
		})
	}

	public EliminarLote(lote:Lote){
		this.ConfirmMessage('warning','','',(result)=>{
			this._loteService.InactivarLote(this.cultivoId, lote.id, lote.nombre, lote.numeroHectareas)
			.subscribe(response =>{
				if(!response) return;
				this.ShowMessage('success',response.mensaje);
				this.ConsultarLotes();
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
