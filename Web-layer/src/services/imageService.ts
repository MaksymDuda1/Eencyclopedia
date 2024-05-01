import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({providedIn: "root"})
export class ImageService{
    private apiUrl = 'http://localhost:4200/api/Images/';


    constructor(private client: HttpClient){
    }

    getImage(imgName: string): Observable<Blob>{
        return this.client.get(this.apiUrl + imgName, {responseType: 'blob'});
    }
}