import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { Internship } from 'src/app/Model/internship.model';
import { InternService } from 'src/app/Services/intern.service';
import { InternshipService } from 'src/app/Services/internship.service';

@Component({
  selector: 'internshipCard',
  templateUrl: './internship-card.component.html',
  styleUrls: ['./internship-card.component.scss']
})
export class InternshipCardComponent implements OnInit {
  internships: Internship[] = [];
  getInternshipsSub: Subscription = new Subscription;
  internsNr: number[] = [];
  img: string[] = [
    "https://cdn.pixabay.com/photo/2015/01/09/11/08/startup-594090_960_720.jpg",
    "https://cdn.pixabay.com/photo/2018/03/10/12/00/teamwork-3213924_960_720.jpg",
    "https://cdn.pixabay.com/photo/2017/05/04/16/37/meeting-2284501_960_720.jpg",
    "https://cdn.pixabay.com/photo/2020/04/09/10/15/desk-5020801_960_720.jpg",
    "https://cdn.pixabay.com/photo/2020/07/08/04/12/work-5382501_960_720.jpg",
    "https://cdn.pixabay.com/photo/2015/01/08/18/27/startup-593341_960_720.jpg"
  ];

  constructor(private internshipService: InternshipService,
    private internService: InternService) { }

  ngOnChanges(): void {
    this.ngOnInit();
  }

  ngOnInit(): void {
    this.getInternshipsSub = this.internshipService.getInternships().subscribe((internships) => { this.internships = internships });
    this.internships.forEach(internship => this.internService.getNumberOfInterns().subscribe((nr) => this.internsNr.push(nr)));

  }

  pickPicture(index: number): string {
    switch (index % 6) {
      case 0:
        return this.img[0];
      case 1:
        return this.img[1];
      case 2:
        return this.img[2];
      case 3:
        return this.img[3];
      case 4:
        return this.img[4];
      case 5:
        return this.img[5];
      default:
        return this.img[4];
    }
  }

  deleteInternship(internships: Internship) {
    this.internshipService.deleteInternship(internships).subscribe();

    this.ngOnChanges();
  }

  public getNet(brut: string): number {
    var indexForLEI = brut.indexOf('L');

    var stringBrut = brut.substring(0, indexForLEI);

    if (!isNaN(Number(stringBrut))) {
      var nrBrut = Number(stringBrut);
    } else {
      return 0;
    }

    var CAS = (10.5 / 100) * nrBrut;
    var CASS = (5.5 / 100) * nrBrut;
    var CFS = (0.5 / 100) * nrBrut;
    var taxableSalary = nrBrut - (CAS + CASS + CFS) - 300;
    var salaryTax = taxableSalary * (16 / 100);


    return nrBrut - (CAS + CASS + CFS + salaryTax);
  }

}
