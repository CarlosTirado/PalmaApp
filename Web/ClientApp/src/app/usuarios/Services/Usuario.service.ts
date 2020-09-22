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
    return this._http.get<Usuario[]>(`api/Tercero`);
  }

    //public EditarUsuario(cultivoId: number, nombre: string, fechaSiembra: Date, estado: string): Observable<UsuarioResponse> {
    //  return this._http.put<UsuarioResponse>(`api/Tercero`, { cultivoId, nombre, fechaSiembra, estado });
    //}
  }

  //export class UsuarioResponse{
  //	public usuarioRegistradoId:number;
  //	public usuarioEditadoId:number;
  //	public mensaje:string;
  //}

