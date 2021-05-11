import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {JugadorEntity} from '../../shared/models/jugador.Entity';
import { JugadorService } from 'src/app/services/jugador.service';
import { Router } from '@angular/router';
import { UserEntity } from 'src/app/shared/models/user.Entity';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-register-dialog',
  templateUrl: './register-dialog.component.html',
  styleUrls: ['./register-dialog.component.css']
})
export class RegisterDialogComponent {

  userForm = new FormGroup({
    identificacion : new FormControl('', [Validators.required,Validators.pattern("^[0-9]*$")]),
    primer_nombre : new FormControl('', Validators.required),
    segundo_nombre: new FormControl('',),
    primer_apellido: new FormControl('',Validators.required),
    segundo_apellido: new FormControl(''),
    telefono: new FormControl('', [Validators.required,Validators.pattern("^[0-9]*$")]),
    correo:new FormControl('', [Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
    password: new FormControl('',[Validators.minLength(6)]),
    ciudad: new FormControl('', Validators.required),
    genero: new FormControl('')
  });

  constructor(
    public dialogRef: MatDialogRef<RegisterDialogComponent>,
    private jugadorService: JugadorService,
    private loginService: LoginService,
    private router:Router
  ) { }

  ngOnInit() {
  }

  saveUser(jugador: JugadorEntity ){

    let user:UserEntity = {
      username:this.userForm.get('correo').value,
      password:this.userForm.get('password').value
    };

    this.jugadorService.create(jugador,user).subscribe(value=>{
      if(value.estado==0){
        this.loginService.saveUser(jugador);
        this.router.navigateByUrl('user/userhome');
        this.dialogRef.close();
      }
    });
  }

}
