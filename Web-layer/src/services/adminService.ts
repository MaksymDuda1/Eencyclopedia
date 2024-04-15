import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ChangeRoleModel } from "../models/changeRoleModel";

@Injectable({providedIn: "root"})
export class AdminService{
    constructor(private client: HttpClient){}

    changeRole(changeRole: ChangeRoleModel ): Observable<any>{
        return this.client.put('api/admin', changeRole);
    }
}