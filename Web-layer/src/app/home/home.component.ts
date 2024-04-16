import { Component, OnInit, SecurityContext } from '@angular/core';
import { LocalService } from '../../services/localService';
import { BookService } from '../../services/bookService';
import { BookModel } from '../../models/bookModel';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  constructor(
    private localService: LocalService,
    private bookService: BookService,
    private sanitizer: DomSanitizer
  ) { }



  book: BookModel = new BookModel();
  safeUrl: SafeResourceUrl | null = null;

  getSecureUrl(url: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  ngOnInit(): void {
    this.bookService.getById('17a03272-941d-4c4d-ad83-0d6a7d9c5b4b').subscribe(data => {
      this.book = data;
      this.safeUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.book.path);
    });
  }
}