import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { User } from 'src/app/Model/user.model';
import { Person } from 'src/app/Model/person.model';
import { UserService } from 'src/app/Services/user.service';
import { PersonService } from 'src/app/Services/person.service';

@Component({
  selector: 'personCard',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.scss']
})
export class PersonCardComponent implements OnInit {
  persons: Person[] = [];
  users: User[] = [];
  getPersonsSub: Subscription = new Subscription;
  getUsersSub: Subscription = new Subscription;
  sources: string[] = [];

  constructor(private personService: PersonService, private userService: UserService) { }

  ngOnChanges(): void {
    this.ngOnInit();
  }

  ngOnInit(): void {
    this.getPersonsSub = this.personService.getPersons().subscribe((persons) => { this.persons = persons });
    this.getUsersSub = this.userService.getUsers().subscribe((users) => { this.users = users});
  }

  deletePerson(person: Person) {
    this.personService.deletePerson(person).subscribe();
    this.ngOnChanges();
  }

  public getAge(birthday: string): number {
    const today = new Date();
    let birthdayDate = new Date(birthday);

    return today.getFullYear() - birthdayDate.getFullYear();
  }

}
