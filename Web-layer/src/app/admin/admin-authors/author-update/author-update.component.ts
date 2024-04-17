import { Component, OnInit } from '@angular/core';
import { AuthorService } from '../../../../services/authorService';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { getGenreOptions, genreStringToValue } from '../../../../enums/genre';
import { BookModel } from '../../../../models/bookModel';
import { PublisherModel } from '../../../../models/publisherModel';
import { AuthorModel } from '../../../../models/authorModel';

@Component({
  selector: 'app-author-update',
  templateUrl: './author-update.component.html',
  styleUrl: './author-update.component.scss'
})
export class AuthorUpdateComponent {
  constructor(
    private authorService: AuthorService,
    public sanitizer: DomSanitizer,
    private route: ActivatedRoute
  ) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id != null) {
        this.getById(id);
      }
    })
  }

  author: AuthorModel = new AuthorModel();
  formData = new FormData();
  selectedFile: File | null = null;
  trustPath: any;
  errorMessage: string = '';

  getById(id: string) {
    this.authorService.getById(id).subscribe(data => {
      this.author = data;
      if (this.author.image)
        this.trustPath = this.sanitizer.bypassSecurityTrustUrl(this.author.image);
    })
  }

  onUpdate() {
    this.formData.append("Id", this.author.id);
    this.formData.append("FullName", this.author.fullName);
    this.formData.append("Description", this.author.description);
    this.formData.append("BirthDate", this.author.birthDate.toString());
    if (this.selectedFile)
      this.formData.append('Image', this.selectedFile);

    this.authorService.updateAuthor(this.formData).subscribe((data) => {
      this.author = data;
      this.errorMessage = "Updated"
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      });
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }
}
