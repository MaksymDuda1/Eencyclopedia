import { Component, OnInit, SecurityContext } from '@angular/core';
import { LocalService } from '../../services/localService';
import { BookService } from '../../services/bookService';
import { BookModel } from '../../models/bookModel';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}