import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { LoginModel } from 'src/app/Models/login.model';
import { AuthService } from 'src/app/Services/Auth.service';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private notifier: NotifierService,
    private router: Router,
    private authServise: AuthService

  ) { }

  model = new LoginModel();
  submitLogIn() {
    if (!this.model.isValid()) {
      this.notifier.notify("error", "Please, enter all fields!")
    }
    else if (!this.model.isEmail()) {
      this.notifier.notify("error", "Please, enter correct email!")
    }
    else {
      this.authServise.login(this.model).subscribe(data => {
        if (data.code == 200) {
          this.notifier.notify("success", "You have successfully registered!")
          this.router.navigate(['/']);
          console.log(data.token);
        }
        else {
          data.errors.forEach(e => {
            this.notifier.notify("error", e)
          });
        }
      });
    }

  }


  ngOnInit() {
  }

}
