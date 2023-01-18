import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { SecurityService } from './security.service';
import { CookieService } from 'ngx-cookie-service';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate
{

 constructor(
   private securityServices: SecurityService,
   private router:Router,
   private Cookie:CookieService,
   private tokenService:TokenService) 
 { 

 }

 canActivate(activatedRoute:ActivatedRouteSnapshot) : boolean 
 {
   let role:string = this.tokenService.getTokenObject().role;

   if(!(this.securityServices.isAuthenticated && activatedRoute.data['Role'] == role))
   {
       this.router.navigate(['login']);

       return false;
   }
   return true;
 }
}