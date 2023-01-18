// import { BreakpointObserver } from '@angular/cdk/layout';
// import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
// import { MatSidenav } from '@angular/material/sidenav';
// import { Router } from '@angular/router';
// import { SecurityService } from '../Services/security.service';

// @Component({
//   selector: 'app-nav-bar',
//   templateUrl: './nav-bar.component.html',
//   styleUrls: ['./nav-bar.component.scss']
// })
// export class NavBarComponent implements AfterViewInit{
//   title = 'InternsManagerClient';

//   pics = [
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Tablet-Chart-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Smartphone-Message-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Settings-2-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Polaroid-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Record-Player-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Programming-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Paper-Plane-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Makeup-icon.png",
//     "https://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Images-icon.png"
//   ]

//   @ViewChild(MatSidenav)
//   sidenav!: MatSidenav;

//   constructor(private observer: BreakpointObserver, private router: Router,
//      private authService: SecurityService) {}

//   ngAfterViewInit() {
//     setTimeout(() => {
//       this.observer
//       .observe(['(min-width: 200px)'])
//       .subscribe((res) => {
//         if (res.matches) {
//           this.sidenav.mode = 'over';
//           this.sidenav.close();
//         } else {
//           this.sidenav.mode = 'side';
//           this.sidenav.open();
//         }
//       });}, 1);
//    }

//    logout() {

//     this.authService.logout()
//       .subscribe(res => {
//         if (!res.success) {
//           this.router.navigate(['/home']);

//         }
//       });
//   }

//    setPic(): string{
//     return this.pics[Math.floor(Math.random() * (8 - 0 + 1)) + 0];
//    }
//   }
