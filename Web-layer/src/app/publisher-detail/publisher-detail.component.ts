import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PublisherService } from '../../services/publisherService';
import { PublisherModel } from '../../models/publisherModel';
import { genreValueToString } from '../../enums/genre';
import { Location } from '@angular/common';
import { ImgSanitizerService } from '../../services/imgSanitizerService';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-publisher-detail',
  templateUrl: './publisher-detail.component.html',
  styleUrl: './publisher-detail.component.scss'
})
export class PublisherDetailComponent {
  constructor(private route: ActivatedRoute,
    private publisherService: PublisherService,
    private sanitizer: ImgSanitizerService,
    private location: Location
  ) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id != null) {
        this.getById(id);
      }
    })
  }

  publisher: PublisherModel = new PublisherModel();
  errorMessage: string = '';

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }

  getName(genre: number) {
    return genreValueToString(genre);
  }

  goBack(): void {
    this.location.back();
  }

  getById(id: string) {
    this.publisherService.getById(id).subscribe(data => {
      this.publisher = data;
    },
  errorResponse =>{
    this.errorMessage = errorResponse.error;
  })
  }
}
