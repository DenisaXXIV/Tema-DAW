import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Intern } from 'src/app/Model/intern.model';
import { Internship } from 'src/app/Model/internship.model';
import { Person } from 'src/app/Model/person.model';
import { InternService } from 'src/app/Services/intern.service';
import { InternshipService } from 'src/app/Services/internship.service';
import { PersonService } from 'src/app/Services/person.service';

@Component({
  selector: 'app-edit-intern',
  templateUrl: './edit-intern.component.html',
  styleUrls: ['./edit-intern.component.scss']
})
export class EditInternComponent implements OnInit {
  person!: Person;
  intern!: Intern;
  vacationDays!: number;
  thisInternship!: Internship;
  listPersons: Person[] = [];
  listInternships: Internship[] = [];
  getPersonsSub: Subscription = new Subscription;
  getInternshipSub: Subscription = new Subscription;
  id: number = 0;
  days: number[] = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20];

  constructor(private serviceIntern: InternService, private servicePerson: PersonService,
    private serviceInternship: InternshipService, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => this.id = params["id"]);
    this.serviceIntern.getIntern(this.id).subscribe(intern => this.intern = intern);
    this.getPersonsSub = this.servicePerson.getPersons().subscribe((listPersons) => { this.listPersons = listPersons });
    this.getInternshipSub = this.serviceInternship.getInternships().subscribe((listInternships) => { this.listInternships = listInternships });
    this.person = this.getPersonId(this.intern);
  }

  ngOnChanges(): void {
    this.ngOnInit();
  }


  editIntern() {
    let intern: Intern = {
      idIntern: 0,
      idInternship: this.thisInternship.idInternship,
      idPerson: this.person.idPerson,
      vacationDays: <number>this.vacationDays
    }

    this.serviceIntern.editIntern(this.id, intern).subscribe();
    this.ngOnChanges();
  }

  getPersonId(intern: Intern): Person{
    for (var index = 0; index < this.listPersons.length; index++) {
      if (this.listPersons[index]?.idPerson == intern?.idPerson)
        return this.listPersons[index];
    }

    return this.listPersons[0];
  }

  getInternshipId(intern: Intern): Internship{
    for (var index = 0; index < this.listInternships.length; index++) {
      if (this.listInternships[index]?.idInternship == intern?.idInternship)
        return this.listInternships[index];
    }
    return this.listInternships[0];

  }

}
