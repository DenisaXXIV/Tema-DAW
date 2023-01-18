import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddPersonComponent } from './add-person/add-person.component';
import { EditPersonComponent } from './edit-person/edit-person.component';
import { PersonsPageComponent } from './persons-page/persons-page.component';
import { ToolsModule } from '../tools/tools.module';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatRadioModule } from '@angular/material/radio';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddPersonComponent,
    EditPersonComponent,
    PersonsPageComponent
  ],
  imports: [
    CommonModule,
    ToolsModule,

    RouterModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    FormsModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatRadioModule
  ],
  exports: [
    AddPersonComponent,
    EditPersonComponent,
    PersonsPageComponent
  ]
})
export class PersonPagesModule { }
