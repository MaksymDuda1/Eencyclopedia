import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PublisherService } from '../../services/publisherService';
import { PublisherModel } from '../../models/publisherModel';
import { genreValueToString } from '../../enums/genre';
import { Location } from '@angular/common';

@Component({
  selector: 'app-publisher-detail',
  templateUrl: './publisher-detail.component.html',
  styleUrl: './publisher-detail.component.scss'
})
export class PublisherDetailComponent {
  constructor(private route: ActivatedRoute,
    private publisherService: PublisherService,
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
