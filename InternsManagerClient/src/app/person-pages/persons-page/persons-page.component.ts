import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-persons-page',
  templateUrl: './persons-page.component.html',
  styleUrls: ['./persons-page.component.scss']
})
export class PersonsPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this.ngOnInit();
  }

}
