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

    getById(id: string): Observable<PublisherModel>{
        return this.client.get<PublisherModel>('api/publishers/' + id);
    }

    create(publisherModel: FormData): Observable<any>{
        return this.client.post('api/publishers/', publisherModel);
    }

    update(publisherModel: FormData): Observable<any>{
        return this.client.put('api/publishers', publisherModel);
    }

    delete(id: string): Observable<any>{
        return this.client.delete('api/publishers/' + id);
    }
}