import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PublisherModel } from "../models/publisherModel";

@Injectable({providedIn: "root"})
export class PublisherService{
    constructor(private client: HttpClient){}

    getAll(): Observable<PublisherModel[]>
    {
        return this.client.get<PublisherModel[]>('api/publishers');
    }
}