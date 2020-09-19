import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../Models/usuario';

@Injectable({
	providedIn: 'root'
})
export class UsuarioService {

	constructor(private _http: HttpClient) { }

	public ConsultarUsuarios(): Observable<Usuario[]> {
		return this._http.get<Usuario[]>(`api/Usuario`);
	}
  
}

//export class CultivoResponse{
//	public cultivoRegistradoId:number;
//	public cultivoEditadoId:number;
//	public mensaje:string;
//}
