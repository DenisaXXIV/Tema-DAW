import { Component, OnInit } from '@angular/core';
import { BaseRouteReuseStrategy } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Intern } from 'src/app/Model/intern.model';
import { Internship } from 'src/app/Model/internship.model';
import { Person } from 'src/app/Model/person.model';
import { InternService } from 'src/app/Services/intern.service';
import { InternshipService } from 'src/app/Services/internship.service';
import { PersonService } from 'src/app/Services/person.service';

@Component({
  selector: 'InternCard',
  templateUrl: './intern-card.component.html',
  styleUrls: ['./intern-card.component.scss']
})
export class InternCardComponent implements OnInit {

  interns: Intern[] = [];
  persons: Person[] = [];
  internships: Internship[] = [];
  getPersonsSub: Subscription = new Subscription;
  getInternsSub: Subscription = new Subscription;
  getInternshipsSub: Subscription = new Subscription;
  sources: string[] = [];

  constructor(private internService: InternService,
    private personService: PersonService,
    private internshipService: InternshipService) { }

  ngOnChanges(): void {
    this.ngOnInit();
  }

  ngOnInit(): void {
    this.getInternsSub = this.internService.getInterns().subscribe((interns) => { this.interns = interns });
    this.getPersonsSub = this.personService.getPersons().subscribe((persons) => { this.persons = persons });
    this.getInternshipsSub = this.internshipService.getInternships().subscribe((internships) => { this.internships = internships });
  }

  deleteIntern(intern: Intern) {
    this.internService.deleteIntern(intern).subscribe();

    this.ngOnChanges();
  }

  public getAge(birthday: string): number {
    const today = new Date();
    let birthdayDate = new Date(birthday);

    return today.getFullYear() - birthdayDate.getFullYear();
  }

  public getInternshipId(intern: Intern): number {
    for (var index = 0; index < this.internships.length; index++) {
      if (this.internships[index]?.idInternship == intern?.idInternship)
        return index;
    }
    return 1;

  }

  public getPersonId(intern: Intern): number {
    for (var index = 0; index < this.persons.length; index++) {
      if (this.persons[index]?.idPerson == intern?.idPerson)
        return index;
    }
    return 1;

  }

  public getNet(brut: string): number {
    var indexForLEI = brut.indexOf('L');

    var stringBrut = brut.substring(0, indexForLEI);

    if (!isNaN(Number(stringBrut))) {
      var nrBrut = Number(stringBrut);
    } else {
      return 0;
    }

    var CAS = (10.5 / 100) * nrBrut;
    var CASS = (5.5 / 100) * nrBrut;
    var CFS = (0.5 / 100) * nrBrut;
    var taxableSalary = nrBrut - (CAS + CASS + CFS) - 300;
    var salaryTax = taxableSalary * (16 / 100);


    return nrBrut - (CAS + CASS + CFS + salaryTax);
  }

}
