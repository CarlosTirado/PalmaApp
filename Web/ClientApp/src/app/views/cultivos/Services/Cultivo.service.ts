import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cultivo } from '../Models/cultivo';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class CultivoService {

	constructor(private _http: HttpClient) { }

	public ConsultarCultivos(): Observable<Cultivo[]> {
		return this._http.get<Cultivo[]>(`api/Cultivo`);
	}

	public ConsultarCultivoPorId(cultivoId:number): any {
		return this._http.get(`api/Cultivo/${cultivoId}`);
	}

	public RegistrarCultivo(cultivo:Cultivo): Observable<CultivoResponse> {
		return this._http.post<CultivoResponse>(`api/Cultivo`, cultivo);
	}

	public EditarCultivo(cultivoId:number, nombre:string, fechaSiembra:Date, estado:string): Observable<CultivoResponse> {
		return this._http.put<CultivoResponse>(`api/Cultivo`, {cultivoId, nombre, fechaSiembra, estado});
	}

	public InactivarCultivo(cultivoId:number, nombre:string, fechaSiembra:Date): Observable<CultivoResponse> {
		return this._http.put<CultivoResponse>(`api/Cultivo`, {cultivoId, nombre, fechaSiembra, estado: 'IN'});
	}
  
}

export class CultivoResponse{
	public cultivoRegistradoId:number;
	public cultivoEditadoId:number;
	public mensaje:string;
}
