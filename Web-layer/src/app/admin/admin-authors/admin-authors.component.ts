import { Component, OnInit } from '@angular/core';
import { AuthorService } from '../../../services/authorService';
import { AuthorModel } from '../../../models/authorModel';

@Component({
  selector: 'app-admin-authors',
  templateUrl: './admin-authors.component.html',
  styleUrl: './admin-authors.component.scss'
})
export class AdminAuthorsComponent implements OnInit {
  constructor(private authorService: AuthorService){}

  authors: AuthorModel[] = [];

  delete(id: string){
    this.authorService.deleteAuthor(id).subscribe(() => {
      this.authorService.getAll().subscribe(data => {
        this.authors = data;
      })
    })
  }

  ngOnInit(): void {
    this.authorService.getAll().subscribe(data => {
      this.authors = data;
    })
  }
}
