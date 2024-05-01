import { Component, OnInit } from '@angular/core';
import { BookService } from '../../../services/bookService';
import { BookModel } from '../../../models/bookModel';

import { genreValueToString } from '../../../enums/genre';
import { ImgSanitizerService } from '../../../services/imgSanitizerService';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-admin-books',
  templateUrl: './admin-books.component.html',
  styleUrl: './admin-books.component.scss'
})

export class AdminBooksComponent implements OnInit {
  constructor(private bookService: BookService,
    private sanitizer: ImgSanitizerService
  ) { }
  
  books: BookModel[] = [];
  erorrMessage: string = '';

  getName(genre: number){
    return genreValueToString(genre);
  }

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }

  delete(id: string) {
    this.bookService.deleteBook(id).subscribe(
      () => {
        console.log('Book deleted successfully');
        this.bookService.getAll().subscribe(data => {
          this.books = data;
        });
      },
      (error) => {
        console.error('Error deleting book:', error);
      }
    );
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
