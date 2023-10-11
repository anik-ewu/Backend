import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  currentUser: any = {};

  constructor(
    public accoutService: AccountService,
    private router: Router,
    private toaster: ToastrService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.accoutService.currentUser$.subscribe(
      (user: User | null) => {
        this.currentUser =  user;
        console.log('Current User:', this.currentUser);
      }
    );
  }

  login() {
    this.accoutService.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.router.navigateByUrl('/members');
      },
      error: error => {
        this.toaster.error(error.error);
        console.log(error);
      }
    })
  }

  logout() {
    this.accoutService.logout();
    this.router.navigateByUrl('/');
  }

}
