import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { LoginDialogComponent } from 'src/app/pages/login-dialog/login-dialog.component';
import { RegisterDialogComponent } from 'src/app/pages/register-dialog/register-dialog.component';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  logged:boolean;
  name:string;
  constructor(public dialog: MatDialog,private loginService:LoginService) { }

  ngOnInit() {
    this.logged=false;
    this.checkisLogged();
  }

  openDialogRegister(){
    let dialogRef = this.dialog.open(RegisterDialogComponent, {
      minHeight: '460px',
      width: '800px',
    });
  }

  openDialogLogin(){
    let dialogRef = this.dialog.open(LoginDialogComponent,{
      minHeight:'250px',
      width:'300px'
    })
    dialogRef.afterClosed();
  }

  checkisLogged(){
    this.name = this.loginService.getItem('Nombre');
    if(this.name != null){
      this.logged = true;
    }
  }

  logOut(){
    this.loginService.logout();
  }

}
