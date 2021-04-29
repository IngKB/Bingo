import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';
import { JugadorEntity } from '../shared/models/jugador.Entity';
import { UserEntity } from '../shared/models/user.Entity';
import { DefaultResponse } from './DefaultResponse';

@Injectable({
  providedIn: 'root'
})
export class JugadorService {

  constructor(private http: HttpClient) { }

  create(jugador:JugadorEntity, usuario:UserEntity): Observable<DefaultResponse> {
    let body:CrearJugadorRequest={Usuario:usuario,Jugador:jugador};
    return this.http.post<DefaultResponse>(baseUrl+'/api/Jugador/', body);
  }

}

export interface CrearJugadorRequest{
  Usuario:UserEntity,
  Jugador:JugadorEntity
}

export interface CrearJugadorResponse{
  Estado:number,
  Mensaje:number,
  Jugador:JugadorEntity
}

