import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'home',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this.ngOnInit();
  }

  clickEvent(): void {
    this.ngOnChanges();
  }

}
