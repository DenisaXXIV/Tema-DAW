import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCardComponent } from './add-card/add-card.component';
import { FiltersComponent } from './filters/filters.component';
import { InternCardComponent } from './intern-card/intern-card.component';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { PersonCardComponent } from './person-card/person-card.component';
import { InternshipCardComponent } from './internship-card/internship-card.component';
import { AddCardPComponent } from './add-card-p/add-card-p.component';
import { AddCardIComponent } from './add-card-i/add-card-i.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatDividerModule } from '@angular/material/divider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddCardComponent,
    FiltersComponent,
    InternCardComponent,
    PersonCardComponent,
    InternshipCardComponent,
    AddCardPComponent,
    AddCardIComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    FormsModule,
    MatSelectModule,
    RouterModule,
    MatInputModule,
    MatDatepickerModule,
    MatSidenavModule,
    MatDividerModule,
    MatToolbarModule
  ],
  exports: [
    AddCardComponent,
    AddCardPComponent,
    AddCardIComponent,
    FiltersComponent,
    InternCardComponent,
    PersonCardComponent,
    InternshipCardComponent
  ]
})
export class ToolsModule { }
