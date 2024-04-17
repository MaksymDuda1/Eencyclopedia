import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthorService } from '../../services/authorService';
import { AuthorModel } from '../../models/authorModel';
import { genreValueToString } from '../../enums/genre';
import { Location } from '@angular/common';

@Component({
  selector: 'app-author-detail',
  templateUrl: './author-detail.component.html',
  styleUrl: './author-detail.component.scss'
})
export class AuthorDetailComponent {
  constructor(private route: ActivatedRoute,
    private authorService: AuthorService,
    private location: Location
  ) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id != null) {
        this.getById(id);
      }
    })
  }

  author: AuthorModel = new AuthorModel();
  errorMessage: string = '';

  getName(genre: number) {
    return genreValueToString(genre);
  }

  goBack(): void {
    this.location.back();
  }

  getById(id: string) {
    this.authorService.getById(id).subscribe(data => {
      this.author = data;
    },
  errorResponse =>{
    this.errorMessage = errorResponse.error;
  })
  }
}
