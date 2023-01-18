import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { User } from '../Model/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly baseUrl = 'http://localhost:7124'
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Response-Type': 'application/json',
      'Data-Type': 'text'
    }),
  }

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + "/User", this.httpOptions);
  }

  getUser(userID: number): Observable<User> {
    return this.http.get<User>(this.baseUrl + "/User/" + userID, this.httpOptions);
  }

  addUser(user: User) {

    let jsonUser = JSON.stringify(user)

    return this.http.post(this.baseUrl + "/User/create", jsonUser, this.httpOptions);
  }

  deleteUser(user: User) {
    return this.http.delete(`${this.baseUrl}/User/delete/${user.idUser}`, this.httpOptions);
  }

  editUser(id: number, user: User) {
    return this.http.put(this.baseUrl + "/User/update/" + id, user, this.httpOptions);
  }
}
