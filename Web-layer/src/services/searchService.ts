import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({ providedIn: "root" })
export class SearchService {

    constructor(private client: HttpClient) { }

    public searchBooks(searchParams: string): Observable<any> {
        let params = new HttpParams();
        Object.keys(searchParams).forEach(key => {
            if (searchParams !== null && searchParams !== undefined) {
                params = params.append("SearchQuery", searchParams);
            }
        });
        return this.client.get<any>('api/search', { params });
    }
}