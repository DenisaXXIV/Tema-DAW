import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutPageComponent } from './about-page/about-page.component';
import { MatCardImage, MatCardModule } from '@angular/material/card';



@NgModule({
  declarations: [
    AboutPageComponent
  ],
  imports: [
    CommonModule,
    MatCardModule
  ],
  exports: [
    AboutPageComponent
  ]
})
export class AboutModule { }
