import { Component } from '@angular/core';
import { LoginModel } from '../../models/loginModel';
import { AuthService } from '../../services/authService';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(private authService: AuthService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService){}

  loginModel = new LoginModel();
  errorMessage: string = '';


  onLogin(){
    this.authService.login(this.loginModel).subscribe(data => {
      this.localService.put(LocalService.AuthTokenName, data.token);

      let token = this.localService.get(LocalService.AuthTokenName);

      if(token){
        let decodedData = this.jwtHelperService.decodeToken(token);
        if(decodedData.role == "Admin")
          window.location.href = '/admin';
        else
          window.location.href = '/';
      }
    },
    errorResponse => {
      this.errorMessage = errorResponse.error;
    })
  }
}
