import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Palma } from '../Models/palma';
import { Cultivo } from '../Models/cultivo';
import { Lote } from '../Models/lote';

@Injectable({
	providedIn: 'root'
})
export class PalmaService {

	constructor(private _http: HttpClient) { }
	
	public ConsultarCultivoPorId(cultivoId:number): Observable<Cultivo> {
		return this._http.get<Cultivo>(`api/Palma/GetCultivo/${cultivoId}`);
	}

	public ConsultarLotePorId(loteId:number): Observable<Lote> {
		return this._http.get<Lote>(`api/Palma/GetLote/${loteId}`);
	}

	public ConsultarPalmasDeUnLote(loteId:number): Observable<Palma[]> {
		return this._http.get<Palma[]>(`api/Palma/Lote/${loteId}`);
	}

	public RegistrarPalma(palmaRequest:GestionPalmaRequest): Observable<PalmaResponse> {
		return this._http.post<PalmaResponse>(`api/Palma`, palmaRequest);
	}

	public EditarPalma(palmaRequest:GestionPalmaRequest): Observable<PalmaResponse> {
		return this._http.put<PalmaResponse>(`api/Palma`, palmaRequest);
	}

	public InactivarPalma(palmaRequest:GestionPalmaRequest): Observable<PalmaResponse> {
		palmaRequest.estado = "IN";
		return this._http.put<PalmaResponse>(`api/Palma`, palmaRequest);
	}
  
}

export class GestionPalmaRequest{
	public cultivoId?:number;
	public loteId?:number;
	public palmaId?:number;
	public altura:number;
	public descripcion:string;
	public fechaSiembra:Date;
	public estado?:string;
}
export class PalmaResponse{
	public palmaRegistradoId:number;
	public palmaEditadoId:number;
	public mensaje:string;
}
