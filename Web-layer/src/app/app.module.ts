import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AdminRoutingModule, } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';
import { jwtFactory } from './jwt-options';
import { LocalService } from '../services/localService';
import { AuthTokenAddInetrceptor } from '../services/inceptors/auth-token.inceptor';
import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdminComponent } from './admin/admin.component';
import { AdminUsersComponent } from './admin/admin-users/admin-users.component';
import { AdminBooksComponent } from './admin/admin-books/admin-books.component';
import { AdminPublishersComponent } from './admin/admin-publishers/admin-publishers.component';
import { BookUpdateComponent } from './admin/admin-books/book-update/book-update.component';
import { BookCreateComponent } from './admin/admin-books/book-create/book-create.component';
import { AppRoutingModule } from './admin/admin-routing.module';
import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { BooksComponent } from './books/books.component';
import { DetailBookComponent } from './books/detail-book/detail-book.component';
import { TopMenuComponent } from './top-menu/top-menu.component';
import { FavoriteBooksComponent } from './favorite-books/favorite-books.component';
import { AdminAuthorsComponent } from './admin/admin-authors/admin-authors.component';
import { AuthorCreateComponent } from './admin/admin-authors/author-create/author-create.component';
import { AuthorUpdateComponent } from './admin/admin-authors/author-update/author-update.component';
import { PublisherCreateComponent } from './admin/admin-publishers/publisher-create/publisher-create.component';
import { PublisherUpdateComponent } from './admin/admin-publishers/publisher-update/publisher-update.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';
import { PublisherDetailComponent } from './publisher-detail/publisher-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AdminComponent,
    AdminUsersComponent,
    AdminBooksComponent,
    AdminPublishersComponent,
    BookUpdateComponent,
    BookCreateComponent,
    RegistrationComponent,
    HomeComponent,
    BooksComponent,
    DetailBookComponent,
    TopMenuComponent,
    FavoriteBooksComponent,
    AdminAuthorsComponent,
    AuthorCreateComponent,
    AuthorUpdateComponent,
    PublisherCreateComponent,
    PublisherUpdateComponent,
    AuthorDetailComponent,
    PublisherDetailComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    AdminRoutingModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useFactory: jwtFactory,
        deps: [LocalService]
      }
    }),
    NgbModule
    
  ],
  providers: [{
    provide:[HTTP_INTERCEPTORS],
    useClass: AuthTokenAddInetrceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
