import { Component } from '@angular/core';
import { AuthorService } from '../../../../services/authorService';
import { AuthorModel } from '../../../../models/authorModel';

@Component({
  selector: 'app-author-create',
  templateUrl: './author-create.component.html',
  styleUrl: './author-create.component.scss'
})
export class AuthorCreateComponent {
  constructor(private authorService: AuthorService){}

  author: AuthorModel = new AuthorModel();
  formData = new FormData();
  selectedFile: File | null = null;
  
  onCreate(){
    this.formData.append("FullName", this.author.fullName);
    this.formData.append("Description", this.author.description);
    this.formData.append("BirthDate", this.author.birthDate.toString());
    if (this.selectedFile) 
      this.formData.append('Image', this.selectedFile);

    this.authorService.createAuthor(this.formData).subscribe(data => {
      this.author = data;
    })
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }

}
