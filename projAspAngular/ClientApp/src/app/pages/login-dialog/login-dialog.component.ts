import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UserEntity } from 'src/app/shared/models/user.Entity';
import {LoginService} from '../../services/login.service';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.css']
})
export class LoginDialogComponent implements OnInit {

  userForm = new FormGroup({
    username:new FormControl('', [Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
    password: new FormControl('',[Validators.minLength(6)]),
  });

  constructor(
    public dialogRef: MatDialogRef<LoginDialogComponent>,
    private loginService:LoginService,
    private router:Router) { }

  ngOnInit() {
  }

  login(user:UserEntity){
    this.loginService.login(user).subscribe(value=>{

      if(value.estado==0){
        this.router.navigateByUrl('user/userhome');
        this.dialogRef.close();
      }
    }
    );
  }
}
