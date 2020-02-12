import { Component, OnInit } from "@angular/core";
import { AuthService } from "../_services/auth.service";
import { AlertifyService } from "../_services/alertify.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(
    public authService: AuthService,
    private alertify: AlertifyService,
    private route: Router
  ) {}

  ngOnInit() {}

  login(): void {
    console.log(this.model);
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success("Logged in successfully");
      },
      error => {
        this.alertify.error("Failed to login");
      }, ()=>{
        this.route.navigate(['/members']);
      }
    );
  }

  loggedIn(): boolean {
    return this.authService.loggedIn();
  }

  logout(): void {
    localStorage.removeItem("token");
    this.alertify.message("logged out");
    this.route.navigate(['/home']);
  }
}
