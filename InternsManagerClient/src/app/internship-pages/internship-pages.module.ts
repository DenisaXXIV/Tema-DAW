import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipsPageComponent } from './internships-page/internships-page.component';
import { AddInternshipComponent } from './add-internship/add-internship.component';
import { EditInternshipComponent } from './edit-internship/edit-internship.component';
import { ToolsModule } from '../tools/tools.module';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    InternshipsPageComponent,
    AddInternshipComponent,
    EditInternshipComponent
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
    MatDatepickerModule
  ],
  exports: [
    InternshipsPageComponent,
    AddInternshipComponent,
    EditInternshipComponent
  ]
})
export class InternshipPagesModule { }
