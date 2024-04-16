import { Component, NgZone, OnInit } from '@angular/core';
import { BookService } from '../../../../services/bookService';
import { BookModel } from '../../../../models/bookModel';
import { PublisherService } from '../../../../services/publisherService';
import { PublisherModel } from '../../../../models/publisherModel';
import { ActivatedRoute } from '@angular/router';
import { genreStringToValue, getGenreOptions } from '../../../../enums/genre';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-book-update',
  templateUrl: './book-update.component.html',
  styleUrl: './book-update.component.scss'
})
export class BookUpdateComponent implements OnInit {
  constructor(
    private bookService: BookService,
    private publisherService: PublisherService,
    public sanitizer: DomSanitizer,
    private route: ActivatedRoute) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if(id != null){
         this.getById(id);
      }
    })
  }

  book: BookModel = new BookModel();
  formData = new FormData();
  publishers: PublisherModel[] = [];
  selectedFile: File | null = null;
  publisherId: string = '';
  genres = getGenreOptions();
  selectedGenre: string = '';
  trustPath: any;

  getById(id: string){
    this.bookService.getById(id).subscribe(data => {
      this.book = data;
      if(this.book.image)
        this.trustPath = this.sanitizer.bypassSecurityTrustUrl(this.book.image);
    })
  }

  onUpdate() {
    this.formData.append("Id", this.book.id);
    this.formData.append("Name", this.book.name);
    this.formData.append("Path", this.book.path);
    this.formData.append("Description", this.book.description);
    this.formData.append("Genre", genreStringToValue(this.selectedGenre));
    this.formData.append("Description", this.book.description);
    this.formData.append("YearOfEdition", this.book.yearOfEdition.toString());
    this.formData.append("PageAmount", this.book.pageAmount.toString());
    if (this.selectedFile) 
      this.formData.append('Image', this.selectedFile);
    this.formData.append("PublisherId", this.publisherId);


    this.bookService.updateBook(this.formData).subscribe((data) => {
      this.book = data;
    });
  }

  ngOnInit(): void {
    this.publisherService.getAll().subscribe((data) => {
      this.publishers = data;
    });
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }
}