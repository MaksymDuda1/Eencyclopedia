import { Component } from '@angular/core';
import { PublisherService } from '../../../../services/publisherService';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { AuthorModel } from '../../../../models/authorModel';
import { PublisherModel } from '../../../../models/publisherModel';

@Component({
  selector: 'app-publisher-update',
  templateUrl: './publisher-update.component.html',
  styleUrl: './publisher-update.component.scss'
})
export class PublisherUpdateComponent {
  constructor(
    private publisherService: PublisherService,
    public sanitizer: DomSanitizer,
    private route: ActivatedRoute
  ) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if(id != null){
         this.getById(id);
      }
    })
  }

  publisher: PublisherModel = new PublisherModel();
  formData = new FormData();
  selectedFile: File | null = null;
  trustPath: any;
  errorMessage: string = '';

  getById(id: string){
    this.publisherService.getById(id).subscribe(data => {
      this.publisher = data;
      if(this.publisher.image)
        this.trustPath = this.sanitizer.bypassSecurityTrustUrl(this.publisher.image);
    })
  }

  onUpdate() {
    this.formData.append("Id", this.publisher.id);
    this.formData.append("Name", this.publisher.name);
    this.formData.append("Description", this.publisher.description);
    if (this.selectedFile) 
      this.formData.append('Image', this.selectedFile);

    this.publisherService.update(this.formData).subscribe((data) => {
      this.publisher = data;
      this.errorMessage = "Updated"
    },
    errroResponse => {
      this.errorMessage = errroResponse.error;
    });
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }
}
