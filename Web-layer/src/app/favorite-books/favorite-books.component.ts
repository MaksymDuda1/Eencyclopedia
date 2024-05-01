import { Component } from '@angular/core';
import { BookService } from '../../services/bookService';
import { BookModel } from '../../models/bookModel';
import { genreValueToString } from '../../enums/genre';
import { UserService } from '../../services/user.service';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ImgSanitizerService } from '../../services/imgSanitizerService';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-favorite-books',
  templateUrl: './favorite-books.component.html',
  styleUrl: './favorite-books.component.scss'
})
export class FavoriteBooksComponent {


  constructor(private userService: UserService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService,
    private sanitizer: ImgSanitizerService) {

  }

  books: BookModel[] = [];
  errorMessage: string = '';
  searchText: string = '';

  getName(genre: number) {
    return genreValueToString(genre);
  }

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }

  ngOnInit(): void {
    var token = this.localService.get(LocalService.AuthTokenName);
    var decodedData = this.jwtHelperService.decodeToken(token);
    var userId = decodedData.jti;
    this.userService.getFavoriteBooks(userId).subscribe(data => {
      if (data.length == 0)
        this.errorMessage = "You have not added any books to your favorites yet"
      this.books = data;
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }

}

