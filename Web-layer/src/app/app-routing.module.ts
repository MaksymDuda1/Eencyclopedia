import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { AdminBooksComponent } from './admin/admin-books/admin-books.component';
import { UpdateBookModel } from '../models/updateBookModel';
import { BookUpdateComponent } from './admin/admin-books/book-update/book-update.component';
import { BookCreateComponent } from './admin/admin-books/book-create/book-create.component';
import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { BooksComponent } from './books/books.component';
import { DetailBookComponent } from './books/detail-book/detail-book.component';
import { FavoriteBooksComponent } from './favorite-books/favorite-books.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "login", component: LoginComponent},
  {path: "registration", component: RegistrationComponent},
  {path: "books", component: BooksComponent},
  {path: "books/books-detail/:id", component: DetailBookComponent},
  {path: "favorite-books", component: FavoriteBooksComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
