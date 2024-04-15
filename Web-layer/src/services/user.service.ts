import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserModel } from "../models/userModel";
import { BookModel } from "../models/bookModel";
import { FavoriteBookDto } from "../models/addBookToFavorite";

@Injectable({ providedIn: "root" })
export class UserService {
    constructor(private client: HttpClient) { }
    getAll(): Observable<UserModel[]> {
        return this.client.get<UserModel[]>('api/users');
    }

    getFavoriteBooks(id: string): Observable<BookModel[]> {
        return this.client.get<BookModel[]>('api/users/' + id);
    }

    addBookToFavorite(addBookToFavoriteModel: FavoriteBookDto): Observable<any> {
        return this.client.post('api/users/addToFavorite', addBookToFavoriteModel);
    }

    isInFavorite(userId: string, bookId: string): Observable<boolean> {
        let params = new HttpParams();
        params = params.append("userId", userId);
        params = params.append("bookId", bookId);

        return this.client.get<any>('api/users/favoriteBook', { params });
    }

    delete(id: string): Observable<any>{
        return this.client.delete('api/users/' + id);
    }
}