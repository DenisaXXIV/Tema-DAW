import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Person } from '../Model/person.model';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  readonly baseUrl = 'http://localhost:7124'
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Response-Type': 'application/json',
      'Data-Type': 'text'
    }),
  }

  constructor(private http: HttpClient) { }

  getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(this.baseUrl + "/Person", this.httpOptions);
  }

  getPerson(personID: number): Observable<Person> {
    return this.http.get<Person>(this.baseUrl + "/Person/" + personID, this.httpOptions);
  }

  addPerson(person: Person) {

    let jsonPerson = JSON.stringify(person)

    return this.http.post(this.baseUrl + "/Person/create", jsonPerson, this.httpOptions);
  }

  deletePerson(person: Person) {
    return this.http.delete(`${this.baseUrl}/Person/delete/${person.idPerson}`, this.httpOptions);
  }

  editPerson(id: number, person: Person) {
    return this.http.put(this.baseUrl + "/Person/update/" + id, person, this.httpOptions);
  }
}
