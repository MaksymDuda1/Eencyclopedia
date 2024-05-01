import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookModel } from '../../../models/bookModel';
import { BookService } from '../../../services/bookService';
import { genreValueToString } from '../../../enums/genre';
import { DomSanitizer, SafeResourceUrl, SafeUrl } from '@angular/platform-browser';
import { LocalService } from '../../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { FavoriteBookDto } from '../../../models/addBookToFavorite';
import { UserService } from '../../../services/user.service';
import { ImgSanitizerService } from '../../../services/imgSanitizerService';

@Component({
  selector: 'app-detail-book',
  templateUrl: './detail-book.component.html',
  styleUrl: './detail-book.component.scss'
})

export class DetailBookComponent implements OnInit {
  constructor(private route: ActivatedRoute,
    private bookService: BookService,
    private sanitizer: ImgSanitizerService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService,
    private userService: UserService) {
    this.route.paramMap.subscribe((params) => {
      this.bookId = params.get('id');
      if (this.bookId != null) {
        this.getById(this.bookId);
      }
    })
  }

  bookId: string | null = '';
  userId: string = '';
  book: BookModel = new BookModel();
  errorMessage: string = '';
  safeUrl: SafeResourceUrl | null = null;
  safeImage: SafeResourceUrl | null = null;
  isAuthorized: boolean = false;
  favoriteBooks: BookModel[] = [];
  isFavorite: boolean = false;


  getName(genre: number) {
    return genreValueToString(genre);
  }

  getById(id: string) {
    this.bookService.getById(id).subscribe(data => {
      this.book = data;
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }


  addToFavorite() {
    var data = new FavoriteBookDto();
    if (this.bookId)
      data.bookId = this.bookId;
    data.userId = this.userId;

    this.userService.addBookToFavorite(data).subscribe(() => {
      if (this.isFavorite)
        this.isFavorite = false;
      else
        this.isFavorite = true;
    });
  }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      this.isAuthorized = true;
      let decodedData = this.jwtHelperService.decodeToken(token);
      this.userId = decodedData.jti;
      if (this.bookId)
        this.userService.isInFavorite(this.userId, this.bookId).subscribe(data => {
          this.isFavorite = data;
        })
    }
  }
}
