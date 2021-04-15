import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierModule, NotifierService } from 'angular-notifier';
import { RegisterModel } from 'src/app/Models/register.model';
import { AuthService } from 'src/app/Services/Auth.service';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private notifier:NotifierService,
    private router:Router,
    private authServise: AuthService
    
  ) { }

  confirmPassword:string;
  model = new RegisterModel();
  submitRegister()
  {
  
  if(!this.model.isValid()){
    this.notifier.notify("error", "Please, enter all fields!")
  }
  else if(this.model.Password != this.confirmPassword){
    this.notifier.notify("error", "Password don't match!")
  }
  else if(!this.model.isEmail()){
    this.notifier.notify("error", "Please, enter correct email!")
  }
  else{
    this.authServise.register(this.model).subscribe(data=>{
      if(data.code == 200){
        this.notifier.notify("success", "You have successfully registered!")
        this.router.navigate(['/login'])
      }
      else{
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
