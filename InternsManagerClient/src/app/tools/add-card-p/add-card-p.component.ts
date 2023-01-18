import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'addCardP',
  templateUrl: './add-card-p.component.html',
  styleUrls: ['./add-card-p.component.scss']
})
export class AddCardPComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this.ngOnInit();
  }

}
