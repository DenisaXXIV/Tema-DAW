import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddInternComponent } from './add-intern/add-intern.component';
import { EditInternComponent } from './edit-intern/edit-intern.component';
import { InternsPageComponent } from './interns-page/interns-page.component';
import { ToolsModule } from '../tools/tools.module';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddInternComponent,
    EditInternComponent,
    InternsPageComponent
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
    AddInternComponent,
    EditInternComponent,
    InternsPageComponent
  ]
})
export class InternPagesModule { }
