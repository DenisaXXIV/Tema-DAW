import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SecurityService } from 'src/app/Services/security.service';
import { CookieService } from 'ngx-cookie-service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'logIn',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  private _username:string|undefined;
  private _password:string|undefined;
  private _httpResponse:HttpResponse<string> | null;
  private _LoggedFailed:boolean | null;

  constructor(
    private router:Router,
    private securityService:SecurityService,
    private Cookies:CookieService
    ) 
  {
    this._httpResponse = null;
    this._LoggedFailed = false;
  }
  
  ngOnInit(): void 
  {
  }

  ngOnDestroy():void
  {
    this._username = '';
    this._password = '';
    this._LoggedFailed = false;
  }
  

  public set username(value:string)
  {
    this._username = value;
  }

  public set password(value:string)
  {
    this._password = value;
  }

  public signIn() : void
  {
    if(this._username != undefined && this._password != undefined)
    {
      this.securityService.Login(this._username,this._password)
      .subscribe(res=>
        {
            if(res.value != null)
            {
              let token:string = res.value;

              localStorage.setItem('accessToken',token);

              this.router.navigate(['']);

              this.securityService.isAuthenticated = true;

              
            }
        });
      }

  }

  public LoggedIn():boolean|null
  {
    return this._LoggedFailed;
  }

  public checkFields():boolean
  {
    return true;
  }

  public forgotPassword():void 
  {

  }
}
