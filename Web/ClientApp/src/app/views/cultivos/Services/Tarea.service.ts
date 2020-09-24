import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tarea } from '../Models/Tarea';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class TareaService {

	constructor(private _http: HttpClient) { }

  public ConsultarTareas(): Observable<Tarea[]> {
    return this._http.get<Tarea[]>(`api/Tarea`);
	}

	public ConsultarTareaPorId(tareaId:number): any {
    return this._http.get(`api/Tarea/${tareaId}`);
	}

  public RegistrarTarea(tarea: Tarea): Observable<TareaResponse> {
    return this._http.post<TareaResponse>(`api/Tarea`, tarea);
	}

  public EditarTarea(tareaId: number, nombre: string,descripcion:string, estado: string): Observable<TareaResponse> {
    return this._http.put<TareaResponse>(`api/Tarea`, { tareaId, nombre, descripcion, estado});
	}

  public InactivarTarea(tareaId: number, nombre: string, descripcion: string): Observable<TareaResponse> {
    return this._http.put<TareaResponse>(`api/Tarea`, { tareaId, nombre, descripcion, estado: 'IN'});
	}
  
}

export class TareaResponse{
	public tareaRegistradaId:number;
  public tareaEditadoId:number;
	public mensaje:string;
}
