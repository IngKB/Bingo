import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';
import { JugadorEntity } from '../shared/models/jugador.Entity';

@Injectable({
  providedIn: 'root'
})
export class JugadorService {

  constructor(private http: HttpClient) { }

  create(data:JugadorEntity): Observable<CrearJugadorResponse> {
    let body= new CrearJugadorRequest();
    body.jugador = data;
    return this.http.post<CrearJugadorResponse>(baseUrl+'/api/Jugador/', body);
  }

}

export class CrearJugadorRequest{
  jugador:JugadorEntity
}
export interface CrearJugadorResponse{
  estado: number,
  mensaje: string,
}
