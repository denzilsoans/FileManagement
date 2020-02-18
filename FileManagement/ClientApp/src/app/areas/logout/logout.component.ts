import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../core/api.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
})
export class LogoutComponent implements OnInit {
  constructor(private data: ApiService,private apiService: ApiService) { }

  ngOnInit() {
      this.data.logout()
        .subscribe(success => {
        });
  }
}
