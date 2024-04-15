import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminBooksComponent } from './admin-books/admin-books.component';
import { BookUpdateComponent } from './admin-books/book-update/book-update.component';
import { BookCreateComponent } from './admin-books/book-create/book-create.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { AdminPublishersComponent } from './admin-publishers/admin-publishers.component';
import { AdminAuthorsComponent } from './admin-authors/admin-authors.component';
import { PublisherUpdateComponent } from './admin-publishers/publisher-update/publisher-update.component';
import { AuthorCreateComponent } from './admin-authors/author-create/author-create.component';
import { PublisherCreateComponent } from './admin-publishers/publisher-create/publisher-create.component';
import { AuthorUpdateComponent } from './admin-authors/author-update/author-update.component';


const routes: Routes = [
  {path: "admin", component: AdminComponent},
  {path: "admin-books", component: AdminBooksComponent},
  {path: "admin-books/update-book/:id", component: BookUpdateComponent},
  {path: "admin-books/create-book", component: BookCreateComponent},
  {path: "admin-users", component: AdminUsersComponent},
  {path: "admin-authors", component: AdminAuthorsComponent},
  {path: "admin-authors/update-author/:id", component: AuthorUpdateComponent },
  {path: "admin-authors/create-author", component: AuthorCreateComponent},
  {path: "admin-publishers", component: AdminPublishersComponent},
  {path: "admin-publishers/update-publisher/:id", component: PublisherUpdateComponent},
  {path: "admin-publishers/create-publisher", component: PublisherCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
