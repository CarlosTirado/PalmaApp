import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private _http: HttpClient) { }

  getUserRoles(userName: string) {
    return this._http.get(`api/Account/User/${userName}/Roles`);
  }
}
