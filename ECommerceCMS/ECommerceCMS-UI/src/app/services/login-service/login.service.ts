import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { InputBlockDTO } from 'src/app/data/input/input-block';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(inputBlockDTO: InputBlockDTO) {
    return this.http.post(`${Constants.url}/${Constants.login}`, inputBlockDTO);
  }

  logout() {
    return this.http.post(`${Constants.url}/${Constants.logout}`, {}, { withCredentials: true });
  }

  isAuthorized() {
    return this.http.post(`${Constants.url}/${Constants.isAuthorized}`, { }, { withCredentials: true });
  }
}
