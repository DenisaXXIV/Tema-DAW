import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Internship } from '../Model/internship.model';

@Injectable({
  providedIn: 'root'
})
export class InternshipService {

  readonly baseUrl = 'http://localhost:7124'
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Response-Type': 'application/json',
      'Data-Type': 'text'
    }),
  }

  constructor(private http: HttpClient) { }

  getInternships(): Observable<Internship[]> {
    return this.http.get<Internship[]>(this.baseUrl + "/Internship", this.httpOptions);
  }

  getInternship(internshipID: number): Observable<Internship> {
    return this.http.get<Internship>(this.baseUrl + "/Internship/" + internshipID, this.httpOptions);
  }

  addInternship(internship: Internship) {

    let jsonInternship = JSON.stringify(internship)

    return this.http.post(this.baseUrl + "/Internship/create", jsonInternship, this.httpOptions);
  }

  deleteInternship(internship: Internship) {
    return this.http.delete(`${this.baseUrl}/Internship/delete/${internship.idInternship}`, this.httpOptions);
  }

  editInternship(id: number, internship: Internship) {
    return this.http.put(this.baseUrl + "/Internship/update/" + id, internship, this.httpOptions);
  }
}
