import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminBooksComponent } from './admin-books/admin-books.component';
import { BookUpdateComponent } from './admin-books/book-update/book-update.component';
import { BookCreateComponent } from './admin-books/book-create/book-create.component';


const routes: Routes = [
  {path: "admin", component: AdminComponent},
  {path: "admin-books", component: AdminBooksComponent},
  {path: 'admin-books/update-book/:id', component: BookUpdateComponent},
  {path: "admin-books/create-book", component: BookCreateComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
