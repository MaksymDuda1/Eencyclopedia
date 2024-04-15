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

  imagePath = 'home/maksi/Studying/Eencyclopedia/Eencyclopedia.Backend/Eencyclopedia.API/Images612aee5f-4be6-4de0-b9b5-be08264b0663.png';
  safeImagePath = this.sanitizer.bypassSecurityTrustResourceUrl(this.imagePath);

  book: BookModel = new BookModel();
  safeUrl: SafeResourceUrl | null = null;

  ngOnInit(): void {
    this.bookService.getById('17a03272-941d-4c4d-ad83-0d6a7d9c5b4b').subscribe(data => {
      this.book = data;
      this.safeUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.book.path);
      this.safeImagePath = this.sanitizer.bypassSecurityTrustResourceUrl(this.imagePath);
    });
  }
}