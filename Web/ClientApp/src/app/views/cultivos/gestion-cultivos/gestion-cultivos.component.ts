import { Component, OnInit } from '@angular/core';
import { Cultivo } from '../Models/cultivo';
import { CultivoService } from '../Services/Cultivo.service';

@Component({
  selector: 'app-gestion-cultivos',
  templateUrl: './gestion-cultivos.component.html',
  styleUrls: ['./gestion-cultivos.component.css']
})
export class GestionCultivosComponent implements OnInit {

	public cultivos:Cultivo[];

	constructor(
		private _cultivoService: CultivoService
	) { }

	ngOnInit() {
		this.cultivos = new Array<Cultivo>();
		this.ConsultarCultivos();
	}

	private ConsultarCultivos(){
		this._cultivoService.ConsultarCultivos()
		.subscribe(response =>{
			if(!response) return;
			this.cultivos = response;
		})
	}

	public AbrirModalNuevoCultivo(){
		this.RegistrarCultivo();
	}

	private RegistrarCultivo(){
		this._cultivoService.RegistrarCultivo({nombre:"Mi Primer Cultivo", fechaSiembra: new Date()})
		.subscribe(response =>{
			if(!response) return;
			this.ConsultarCultivos();
		})
	}


}
