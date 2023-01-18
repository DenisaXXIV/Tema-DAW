import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './home-page/home-page.component';
import { NoPageFoundComponent } from './no-page-found/no-page-found.component';
import { InternCardComponent } from '../tools/intern-card/intern-card.component';
import { ToolsModule } from '../tools/tools.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    HomePageComponent,
    NoPageFoundComponent
  ],
  imports: [
    CommonModule,
    ToolsModule,
    RouterModule
  ],
  exports: [
    HomePageComponent,
    NoPageFoundComponent
  ]
})
export class HomeModule { }
