import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lote } from '../Models/lote';

@Injectable({
	providedIn: 'root'
})
export class LoteService {

	constructor(private _http: HttpClient) { }
	
	public ConsultarCultivoPorId(cultivoId:number): any {
		return this._http.get(`api/Lote/GetCultivo/${cultivoId}`);
	}

	public ConsultarLotesDeUnCultivo(cultivoId:number): Observable<Lote[]> {
		return this._http.get<Lote[]>(`api/Lote/Cultivo/${cultivoId}`);
	}

	public RegistrarLote(lote:Lote): Observable<LoteResponse> {
		return this._http.post<LoteResponse>(`api/Lote`, lote);
	}

	public EditarLote(cultivoId:number, loteId:number, nombre:string, cantidadHectareas:number, estado:string): Observable<LoteResponse> {
		return this._http.put<LoteResponse>(`api/Lote`, {cultivoId, loteId, nombre, cantidadHectareas, estado});
	}

	public InactivarLote(cultivoId:number, loteId:number, nombre:string, cantidadHectareas:number): Observable<LoteResponse> {
		return this._http.put<LoteResponse>(`api/Lote`, {cultivoId, loteId, nombre, cantidadHectareas, estado: 'IN'});
	}
  
}

export class LoteResponse{
	public cultivoRegistradoId:number;
	public cultivoEditadoId:number;
	public mensaje:string;
}
