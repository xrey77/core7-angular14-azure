import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  userName: any;
  profilepic: any;

  constructor(

  ) { 
    this.userName = sessionStorage.getItem("USERNAME");
    this.profilepic = sessionStorage.getItem('USERPIC');
  }

  ngOnInit(): void {
  }


  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }
  logOut(){
    sessionStorage.removeItem("USERNAME");
    sessionStorage.clear();
    window.location.reload();
  }
}
