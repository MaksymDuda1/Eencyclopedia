import { Component, OnInit } from '@angular/core';
import { PublisherService } from '../../../services/publisherService';
import { PublisherModel } from '../../../models/publisherModel';

@Component({
  selector: 'app-admin-publishers',
  templateUrl: './admin-publishers.component.html',
  styleUrl: './admin-publishers.component.scss'
})
export class AdminPublishersComponent implements OnInit{
  constructor(private publisherService: PublisherService){}
  

  publishers: PublisherModel[] = [];

  delete(id: string){
    this.publisherService.delete(id).subscribe(() => {
      this.publisherService.getAll().subscribe(data => {
        this.publishers = data;
      })
    })
  }

  ngOnInit(): void {
    this.publisherService.getAll().subscribe(data => {
      this.publishers = data;
    })
  }

}
