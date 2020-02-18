import { Component } from "@angular/core";
import { ApiService } from '../../core/api.service';
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html"
})
export class LoginComponent {

  constructor(private data: ApiService, private router: Router) { }

  errorMessage: string = "";
  public creds = {
    username: "",
    password: ""
  };

  onLogin() {
    this.errorMessage = "";
    this.data.login(this.creds)
      .subscribe(success => {
        if (success) {
          this.router.navigate(['home']);
        }
      }, err => this.errorMessage = "Failed to login");
  }
}
