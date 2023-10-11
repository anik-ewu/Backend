import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(
    public accoutService: AccountService,
    private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.accoutService.login(this.model).subscribe({
      next: _ => this.router.navigateByUrl('/members'),
      error: error => console.log(error)
    })
    console.log(this.model);
  }

  logout() {
    this.accoutService.logout();
    this.router.navigateByUrl('/');
  }

}
