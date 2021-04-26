import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {JugadorEntity} from '../../../shared/models/jugador.Entity';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { JugadorService } from 'src/app/services/jugador.service';

@Component({
  selector: 'app-register-dialog',
  templateUrl: './register-dialog.component.html',
  styleUrls: ['./register-dialog.component.css']
})
export class RegisterDialogComponent {

  jugador:JugadorEntity;
  userForm = new FormGroup({
    identificacion : new FormControl('', [Validators.required,Validators.pattern("^[0-9]*$")]),
    primer_nombre : new FormControl('', Validators.required),
    segundo_nombre: new FormControl('',),
    primer_apellido: new FormControl('',Validators.required),
    segundo_apellido: new FormControl(''),
    telefono: new FormControl('', [Validators.required,Validators.pattern("^[0-9]*$")]),
    correo:new FormControl('', [Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
    ciudad: new FormControl('', Validators.required),
    genero: new FormControl('')
  });

  constructor(
    public dialogRef: MatDialogRef<RegisterDialogComponent>,
    private jugadorService: JugadorService
  ) { }

  ngOnInit() {
  }

  saveUser(jugador: JugadorEntity ){
    this.jugadorService.create(jugador).subscribe(value=>{console.log(value.mensaje)});
  }

}
