import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { TokenModel } from "../models/tokenModel";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { LoginModel } from "../models/loginModel";
import { RegistrationModel } from "../models/registrationModel";

@Injectable({providedIn: "root"})
export class AuthService{
    constructor(private client: HttpClient){}

    login(loginModel : LoginModel):Observable<TokenModel>{
        return this.client.post<TokenModel>("api/auth/login", loginModel);
    }

    registration(registrationModel : RegistrationModel): Observable<TokenModel>{
        return this.client.post<TokenModel>('api/auth/registration', registrationModel);
    }
}