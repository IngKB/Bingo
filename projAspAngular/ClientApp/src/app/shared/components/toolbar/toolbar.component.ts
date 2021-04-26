import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { RegisterDialogComponent } from 'src/app/pages/Jugador-pages/register-dialog/register-dialog.component';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialogRegister(){
    let dialogRef = this.dialog.open(RegisterDialogComponent, {
      height: '550px',
      width: '600px',
    });
  }

}
