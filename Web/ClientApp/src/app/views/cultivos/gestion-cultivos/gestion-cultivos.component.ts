import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cultivo } from '../Models/cultivo';
import { CultivoService } from '../Services/Cultivo.service';

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

	private cultivoId:number;
	private cultivoEstado:string;

	constructor(
		private _formBuilder: FormBuilder,
		private _cultivoService: CultivoService
	) { }

	ngOnInit() {
		this.cultivos = new Array<Cultivo>();
		this.ConsultarCultivos();
		this.cultivoForm = this.InicializarFormulario();
	}

	private ConsultarCultivos(){
		this._cultivoService.ConsultarCultivos()
		.subscribe(response =>{
			if(!response) return;
			this.cultivos = response;
			this.cultivoForm.reset();
			this.visualizarFormulario = false;
		})
	}

	public AbrirModalNuevoCultivo(){
		this.visualizarFormulario = true;
		this.GuardarCultivo = this.RegistrarCultivo;
	}
	public AbrirModalEditarCultivo(cultivo:Cultivo){
		this.visualizarFormulario = true;
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
		const cultivoForm = this.cultivoForm.value;
		this._cultivoService.RegistrarCultivo(cultivoForm)
		.subscribe(response =>{
			if(!response) return;
			this.ConsultarCultivos();
		})
	}

	private EditarCultivo(){
		const cultivoForm = this.cultivoForm.value;
		this._cultivoService.EditarCultivo(this.cultivoId, cultivoForm.nombre, cultivoForm.fechaSiembra, this.cultivoEstado)
		.subscribe(response =>{
			if(!response) return;
			this.ConsultarCultivos();
		})
	}

	public EliminarCultivo(cultivo:Cultivo){
		this._cultivoService.InactivarCultivo(cultivo.id, cultivo.nombre, cultivo.fechaSiembra)
		.subscribe(response =>{
			if(!response) return;
			this.ConsultarCultivos();
		})
	}

	private InicializarFormulario():FormGroup{
		return this._formBuilder.group({
			nombre: [undefined, [Validators.required]],
			fechaSiembra: [undefined, [Validators.required]],
		})
	}

}
