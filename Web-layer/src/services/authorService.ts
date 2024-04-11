import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthorModel } from "../models/authorModel";

@Injectable({providedIn: "root"})
export class AuthorService{
    constructor(private client: HttpClient){}

    getAll():Observable<AuthorModel[]>
    {
        return this.client.get<AuthorModel[]>('api/authors');
    }

    getById(id:string): Observable<any>{
        return this.client.get<AuthorModel>('api/authors' + id);
    }

    createAuthor(createAuthorModel: FormData) : Observable<any>{
        return this.client.post('api/authors', createAuthorModel);
    }

    updateAuthor(updateAuthorModel: FormData) : Observable<any>{
        return this.client.put('api/auhtors', updateAuthorModel);
    }

    deleteAuthor(id: string){
        return this.client.delete('api/authors' + id);
    }
}