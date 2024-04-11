import { Injectable } from "@angular/core";
import { TokenModel } from "../models/tokenModel";

@Injectable({providedIn: "root"})
export class LocalService{
     public static AuthTokenName = "auth-token";

     put(name: string, value: string){
        localStorage.setItem(name, value);
     }

     get(name: string) : any{
        return localStorage.getItem(name);
     }

     remove(name: string){
        localStorage.removeItem(name)
     }
}