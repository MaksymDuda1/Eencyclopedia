import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BookModel } from "../models/bookModel";
import { CreateBookModel } from "../models/createBookModel";
import { UpdateBookModel } from "../models/updateBookModel";
import { Genre } from "../enums/genre";

@Injectable({providedIn: "root"})
export class BookService{
    constructor(private client: HttpClient){}

    getAll(): Observable<BookModel[]>{
        return this.client.get<BookModel[]>('api/books');
    }

    getById(id: string): Observable<any>{
        return this.client.get<BookModel>('api/books/' + id);
    }

    getByGenre(genre: number): Observable<any> {
        return this.client.get<any>('api/books/genre/'+ genre);
    }

    createBook(createBookModel: FormData) : Observable<any>{
        return this.client.post('api/books', createBookModel);
    }

    updateBook(updateBookModel: FormData): Observable<any>{
        return this.client.put('api/books', updateBookModel);
    }

    deleteBook(id: string){
        this.client.delete('api/books' + id);
    }
}