import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/bookService';
import { BookModel } from '../../models/bookModel';
import { Genre, genreValueToString } from '../../enums/genre';
import { SearchService } from '../../services/searchService';
import { empty } from 'rxjs';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss'
})

export class BooksComponent implements OnInit {

  constructor(private bookService: BookService,
    private searchService: SearchService
  ) {

  }

  books: BookModel[] = [];
  errorMessage: string = '';
  searchText: string = '';

  getName(genre: number) {
    return genreValueToString(genre);
  }

  getByGenre(genre: number){
    console.log(genre);
    this.bookService.getByGenre(genre).subscribe(data => {
      this.books = data;
    })
  }

  searchBooks() {
    if (this.searchText.trim() === '') {
      this.bookService.getAll().subscribe(data => {
        this.books = data;
      });
    } else {
      this.searchService.searchBooks(this.searchText).subscribe(
        data => {
          this.books = data;
        },
        errorResponse => {
          this.errorMessage = errorResponse;
        }
      );
    }
  }

  ngOnInit(): void {
    this.bookService.getAll().subscribe(data => {
      this.books = data;
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }

}
