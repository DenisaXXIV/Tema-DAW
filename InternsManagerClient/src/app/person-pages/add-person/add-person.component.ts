import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/Model/person.model';
import { PersonService } from 'src/app/Services/person.service';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.scss']
})
export class AddPersonComponent implements OnInit {

  inputName: string = '';
  inputDateOfBirth: string = '';
  inputGender: string = '';
  inputPicPath: string = '';
  
  constructor(private service: PersonService) { }

  ngOnChanges(): void {
    this.ngOnInit();
  }

  ngOnInit(): void {
  }

  addPerson() {
    let person: Person = {
      idPerson: 0,
      name: this.inputName,
      dateOfBirth: this.inputDateOfBirth,
      gender: this.inputGender,
      picPath: this.inputPicPath
    }
    this.service.addPerson(person).subscribe();
    this.ngOnChanges();
  }

}
