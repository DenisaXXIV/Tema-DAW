import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { User } from '../Model/user.model';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  readonly baseUrl = 'http://localhost:7124/Security'
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Response-Type': 'application/json',
      'Data-Type': 'text'
    }),
  }

  private _isAuthenticated:boolean;

  constructor(private http:HttpClient) 
  {
    this._isAuthenticated = false;
  }

  public Login(username:string,password:string):Observable<any>
  {
    const body =
    {
      username:username,
      parola:password
    }

    let jsonBody = JSON.stringify(body)

    return this.http.post<any>(this.baseUrl + "/login",jsonBody, this.httpOptions);
  }

  public SignUp(user:User):Observable<any>
  {
    const body = 
    {
      username:user.username,
      password:user.password,
      person:user.idPerson,
      role:user.idRole
    }

    let jsonBody = JSON.stringify(body)

    return this.http.post<any>(this.baseUrl + "/register",jsonBody, this.httpOptions);
  }

  public set isAuthenticated(value:boolean)
  {
    this._isAuthenticated = value;
  }

  public get isAuthenticated() : boolean
  {
    if(localStorage.getItem('accessToken') != null)
    {
      return this._isAuthenticated = true;
    }

    return this._isAuthenticated;
  }


}
