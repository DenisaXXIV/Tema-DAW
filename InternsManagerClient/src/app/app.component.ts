import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { ActivatedRoute, Router } from '@angular/router';
import { SecurityService } from './Services/security.service';
import { TokenService } from './Services/token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit{
  title = 'InternsManagerClient';
  pics = [
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Tablet-Chart-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Smartphone-Message-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Settings-2-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Polaroid-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Record-Player-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Programming-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Paper-Plane-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Makeup-icon.png",
    "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Images-icon.png"
  ]

  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  constructor(
    private router:Router,
    private loginService: SecurityService,
    private observer: BreakpointObserver,
    private activatedRoute: ActivatedRoute,
    private tokenService:TokenService)
  {
  }

   public isAuthenticated():boolean
  {
    return this.loginService.isAuthenticated;
  }

  logOut() 
  {
    localStorage.removeItem('accessToken');

    this.router.navigate(['/login']);

    this.loginService.isAuthenticated = false;
  }

  setPic(): string{
    return this.pics[2];
   }

  ngAfterViewInit() {
    setTimeout(() => {
      this.observer
      .observe(['(min-width: 200px)'])
      .subscribe((res) => {
        if (res.matches) {
          this.sidenav.mode = 'over';
          this.sidenav.close();
        } else {
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }
      });}, 1);
   }

  }

