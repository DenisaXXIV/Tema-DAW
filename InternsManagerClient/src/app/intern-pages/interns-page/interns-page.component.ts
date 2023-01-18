import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interns-page',
  templateUrl: './interns-page.component.html',
  styleUrls: ['./interns-page.component.scss']
})
export class InternsPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this.ngOnInit();
  }

}
