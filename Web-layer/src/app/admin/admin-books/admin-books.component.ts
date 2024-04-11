import { Component, OnInit } from '@angular/core';
import { BookService } from '../../../services/bookService';
import { BookModel } from '../../../models/bookModel';
import { concatWith } from 'rxjs';
import { BookUpdateComponent } from './book-update/book-update.component';
import { genreValueToString } from '../../../enums/genre';

@Component({
  selector: 'app-admin-books',
  templateUrl: './admin-books.component.html',
  styleUrl: './admin-books.component.scss'
})

export class AdminBooksComponent implements OnInit {
  constructor(private bookService: BookService) { }
  
  books: BookModel[] = [];
  erorrMessage: string = '';

  getName(genre: number){
    return genreValueToString(genre);
  }

  ngOnInit(): void {
    this.bookService.getAll().subscribe(data => {
      this.books = data;
    },
      errorResponser => {
        this.erorrMessage = errorResponser.error;
      })
  }
}
