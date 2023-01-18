import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Role } from '../Model/role.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  readonly baseUrl = 'http://localhost:7124'
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Response-Type': 'application/json',
      'Data-Type': 'text'
    }),
  }

  constructor(private http: HttpClient) { }

  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(this.baseUrl + "/Role", this.httpOptions);
  }

  getRole(roleID: number): Observable<Role> {
    return this.http.get<Role>(this.baseUrl + "/Role/" + roleID, this.httpOptions);
  }

  addRole(role: Role) {

    let jsonRole = JSON.stringify(role)

    return this.http.post(this.baseUrl + "/Role/create", jsonRole, this.httpOptions);
  }

  deleteRole(role: Role) {
    return this.http.delete(`${this.baseUrl}/Role/delete/${role.idRole}`, this.httpOptions);
  }

  editRole(id: number, role: Role) {
    return this.http.put(this.baseUrl + "/Role/update/" + id, role, this.httpOptions);
  }
}
