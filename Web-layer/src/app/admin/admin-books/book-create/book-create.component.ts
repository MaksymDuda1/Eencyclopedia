import { Component } from '@angular/core';
import { BookService } from '../../../../services/bookService';
import { BookModel } from '../../../../models/bookModel';
import { PublisherModel } from '../../../../models/publisherModel';
import { genreStringToValue, getGenreOptions } from '../../../../enums/genre';
import { PublisherService } from '../../../../services/publisherService';
import { AuthorService } from '../../../../services/authorService';
import { AuthorModel } from '../../../../models/authorModel';

@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrl: './book-create.component.scss'
})
export class BookCreateComponent {
  constructor(private bookService: BookService,
    private publisherService: PublisherService,
    private authorService: AuthorService
  ) { }

  book: BookModel = new BookModel();
  formData = new FormData();
  publishers: PublisherModel[] = [];
  selectedFile: File | null = null;
  publisherId: string = '';
  genres = getGenreOptions();
  selectedGenre: string = '';
  trustPath: any;
  authors: AuthorModel[] = [];
  selectedAuthors: AuthorModel[] = [];
  authorsIds: string[] = [];
  errorMessage: string = "";

  onCreate() {
    this.formData = new FormData();
    this.formData.append("Name", this.book.name);
    this.formData.append("Path", this.book.path);
    this.formData.append("Description", this.book.description);
    this.formData.append("Genre", this.book.genre.toString());
    this.formData.append("YearOfEdition", this.book.yearOfEdition.toString());
    this.formData.append("PageAmount", this.book.pageAmount.toString());
    this.formData.append("PublisherId", this.publisherId?.toString() ?? "");
    
    if (this.selectedFile)
      this.formData.append('Image', this.selectedFile);
  
    for (const author of this.selectedAuthors)
      this.formData.append("Authors", author.id.toString());  
  
    this.bookService.createBook(this.formData).subscribe(
      (data) => {
        this.book = data;
        this.errorMessage = "Created";
      },
      (errorResponse) => {
        this.errorMessage = errorResponse.error;
      }
    );
  }
  
  selectAuthor(author: AuthorModel){
    if (!this.selectedAuthors.some(a => a.id === author.id)) 
      this.selectedAuthors.push(author);
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }

  ngOnInit(): void {
    this.publisherService.getAll().subscribe((data) => {
      this.publishers = data;
    });

    this.authorService.getAll().subscribe(data => {
      this.authors = data;
    })
  }
}
