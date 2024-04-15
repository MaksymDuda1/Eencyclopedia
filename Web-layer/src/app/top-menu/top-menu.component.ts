import { Component, OnInit } from '@angular/core';
import { LocalService } from '../../services/localService';

@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrl: './top-menu.component.scss'
})
export class TopMenuComponent implements OnInit {
  constructor(private localService: LocalService){}

  isAuthorized: boolean = false;

  onExit() {
    this.isAuthorized = false;
    this.localService.remove(LocalService.AuthTokenName);
    window.location.href = '/login';
  }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);

    if(token)
      this.isAuthorized = true;
  }
}
