import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutPageComponent } from './about/about-page/about-page.component';
import { UserTypes } from './Constants/user-types';
import { HomePageComponent } from './home/home-page/home-page.component';
import { NoPageFoundComponent } from './home/no-page-found/no-page-found.component';
import { AddInternComponent } from './intern-pages/add-intern/add-intern.component';
import { EditInternComponent } from './intern-pages/edit-intern/edit-intern.component';
import { InternsPageComponent } from './intern-pages/interns-page/interns-page.component';
import { AddInternshipComponent } from './internship-pages/add-internship/add-internship.component';
import { EditInternshipComponent } from './internship-pages/edit-internship/edit-internship.component';
import { InternshipsPageComponent } from './internship-pages/internships-page/internships-page.component';
import { AddPersonComponent } from './person-pages/add-person/add-person.component';
import { EditPersonComponent } from './person-pages/edit-person/edit-person.component';
import { PersonsPageComponent } from './person-pages/persons-page/persons-page.component';
import { LogInComponent } from './profile/log-in/log-in.component';
import { AuthGuardService } from './Services/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: '', redirectTo: 'interns-manager', pathMatch: 'full' },
      { path: 'interns-manager', component: HomePageComponent, pathMatch: 'full' },
      { path: 'internships', component: InternshipsPageComponent },
      { path: 'about', component: AboutPageComponent, pathMatch: 'full' },
      { path: 'login', component: LogInComponent, pathMatch: 'full' },

      { path: 'interns', component: InternsPageComponent },
      { path: 'persons', component: PersonsPageComponent },
      { path: 'interns/add', component: AddInternComponent },
      { path: 'interns/edit/:id', component: EditInternComponent },
      { path: 'persons/add', component: AddPersonComponent },
      { path: 'persons/edit/:id', component: EditPersonComponent },
      { path: 'internships/edit/:id', component: EditInternshipComponent },
      { path: 'internships/add', component: AddInternshipComponent },


      { path: '**', component: NoPageFoundComponent }
    ]
  },

  // {
  //   path: '',
  //   canActivateChild: [AuthGuardService],
  //   data:
  //   {
  //     role: [UserTypes.ADMIN,UserTypes.INTERN,UserTypes.EMPLOYEE]
  //   },
  //   children: [
  //     { path: 'interns', component: InternsPageComponent },
  //     { path: 'persons', component: PersonsPageComponent },
  //   ]
  // },

  // {
  //   path: '',
  //   canActivateChild: [AuthGuardService],
  //   data:
  //   {
  //     role: [UserTypes.ADMIN]
  //   },
  //   children: [
  //     { path: 'interns/add', component: AddInternComponent },
  //     { path: 'interns/edit/:id', component: EditInternComponent },
  //     { path: 'persons/add', component: AddPersonComponent },
  //     { path: 'persons/edit/:id', component: EditPersonComponent },
  //     { path: 'internships/edit/:id', component: EditInternshipComponent },
  //     { path: 'internships/add', component: AddInternshipComponent },
  //   ]
  // },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
