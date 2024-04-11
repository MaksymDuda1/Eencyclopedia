import { Injectable } from "@angular/core";
import { BookModel } from "../models/bookModel";
import { Observable, of } from "rxjs";
import { LocalService } from "./localService";

@Injectable({ providedIn: "root" })
export class BookDataService {
  constructor(private localService: LocalService){}

  book: BookModel = new BookModel();

  setBookData(book: BookModel) {
    this.localService.put('book', JSON.stringify(book));
  }

  getBookData(): BookModel {
    const bookData = this.localService.get('book');
    return bookData ? JSON.parse(bookData) : null;
  }
}