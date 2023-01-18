import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'addCardI',
  templateUrl: './add-card-i.component.html',
  styleUrls: ['./add-card-i.component.scss']
})
export class AddCardIComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this.ngOnInit();
  }

}
