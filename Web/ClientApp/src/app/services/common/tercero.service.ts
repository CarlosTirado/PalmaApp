import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TerceroService {

  constructor(private _http: HttpClient) { }

  getTercero(identificacion: string): any {
    return this._http.get(`api/Tercero/Identificacion/${identificacion}`);
  }
  getTerceroPorCorreo(correo: string): any { 
    return this._http.get(`api/Tercero/Correo/${correo}`);
  }
}
