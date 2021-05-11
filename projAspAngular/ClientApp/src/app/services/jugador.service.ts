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
    let body:CrearJugadorRequest={usuario:usuario,jugador:jugador};
    return this.http.post<DefaultResponse>(baseUrl+'/api/Jugador/', body);
  }

}

export interface CrearJugadorRequest{
  usuario:UserEntity,
  jugador:JugadorEntity
}

export interface CrearJugadorResponse{
  estado:number,
  mensaje:number,
  jugador:JugadorEntity
}

