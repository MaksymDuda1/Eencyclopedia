import { Component } from '@angular/core';
import { PublisherService } from '../../../../services/publisherService';
import { PublisherModel } from '../../../../models/publisherModel';

@Component({
  selector: 'app-publisher-create',
  templateUrl: './publisher-create.component.html',
  styleUrl: './publisher-create.component.scss'
})
export class PublisherCreateComponent {
  constructor(private publisherService: PublisherService){}


  publisher: PublisherModel = new PublisherModel();
  formData = new FormData();
  selectedFile: File | null = null;
  
  onCreate(){
    this.formData.append("Name", this.publisher.name);
    this.formData.append("Description", this.publisher.description);
    if (this.selectedFile) 
      this.formData.append('Image', this.selectedFile);

    this.publisherService.create(this.formData).subscribe(data => {
      this.publisher = data;
    })
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }
}
