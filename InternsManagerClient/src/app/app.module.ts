import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RouterModule } from '@angular/router';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { ToolsModule } from './tools/tools.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { HomeModule } from './home/home.module';
import { AboutModule } from './about/about.module';
import { InternPagesModule } from './intern-pages/intern-pages.module';
import { InternshipPagesModule } from './internship-pages/internship-pages.module';
import { PersonPagesModule } from './person-pages/person-pages.module';
import { ProfileModule } from './profile/profile.module';
import { FormsModule } from '@angular/forms';
import { AuthGuardService } from './Services/auth-guard.service';
import { JwtHelperService, JwtModule, JWT_OPTIONS } from '@auth0/angular-jwt'

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    JwtModule,

    ToolsModule,
    HomeModule,
    AboutModule,
    InternPagesModule,
    InternshipPagesModule,
    PersonPagesModule,
    ProfileModule,

    MatIconModule,
    MatSidenavModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    MatDatepickerModule,
    MatRadioModule,
    MatNativeDateModule,
    MatToolbarModule,
    MatListModule,
    MatDividerModule
  ],
  providers: [AuthGuardService,JwtHelperService,{provide:JWT_OPTIONS,useValue:JWT_OPTIONS}],
  bootstrap: [AppComponent]
})
export class AppModule { }
