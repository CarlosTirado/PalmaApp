import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lote } from '../Models/lote';
import { Palma } from '../Models/palma';

@Injectable({
	providedIn: 'root'
})
export class PalmaService {

	constructor(private _http: HttpClient) { }
	
	public ConsultarCultivoPorId(cultivoId:number): any {
		return this._http.get(`api/Lote/GetCultivo/${cultivoId}`);
	}

	public ConsultarPalmasDeUnLote(loteId:number): Observable<Palma[]> {
		return this._http.get<Palma[]>(`api/Lote/Cultivo/${loteId}`);
	}

	public RegistrarLote(lote:Lote): Observable<LoteResponse> {
		return this._http.post<LoteResponse>(`api/Lote`, lote);
	}

	public EditarLote(cultivoId:number, loteId:number, nombre:string, numeroHectareas:number, estado:string): Observable<LoteResponse> {
		return this._http.put<LoteResponse>(`api/Lote`, {cultivoId, loteId, nombre, numeroHectareas, estado});
	}

	public InactivarLote(cultivoId:number, loteId:number, nombre:string, numeroHectareas:number): Observable<LoteResponse> {
		return this._http.put<LoteResponse>(`api/Lote`, {cultivoId, loteId, nombre, numeroHectareas, estado: 'IN'});
	}
  
}

export class LoteResponse{
	public cultivoRegistradoId:number;
	public cultivoEditadoId:number;
	public mensaje:string;
}
