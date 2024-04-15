import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { UserModel } from '../../../models/userModel';
import { AdminService } from '../../../services/adminService';
import { ChangeRoleModel } from '../../../models/changeRoleModel';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalService } from '../../../services/localService';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrl: './admin-users.component.scss'
})
export class AdminUsersComponent implements OnInit {
  constructor(private userService: UserService,
    private adminService: AdminService,
    private jwtHeplerService: JwtHelperService,
    private localService: LocalService
  ) { }

  users: UserModel[] = [];
  isAdmin: boolean = false;
  errorMessage: string = '';
  currentUserId: string = '';

  changeRole(id: string) {
    let changeRole = new ChangeRoleModel();
    changeRole.userId = id;
    this.adminService.changeRole(changeRole).subscribe(() => {
      this.userService.getAll().subscribe(data => {
        this.users = data;
      })
    });
  }

  delete(id: string) {
    this.userService.delete(id).subscribe(() => {
      this.userService.getAll().subscribe(data => {
        this.users = data;
      })
    })
  }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      let decodedData = this.jwtHeplerService.decodeToken(token);
      this.currentUserId = decodedData.jti;
      console.log(this.currentUserId);
    }
    this.userService.getAll().subscribe(data => {
      this.users = data;
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }
}
