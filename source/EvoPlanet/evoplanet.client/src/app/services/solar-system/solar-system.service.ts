import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PlanetSystem } from '../../types';

@Injectable({
  providedIn: 'root'
})
export class SolarSystemService {

  solarSystem: PlanetSystem = {};

  constructor(private http: HttpClient) { }

  //TODO: Change link if it doesn't work

getSolarSystem(): Observable<PlanetSystem> {
  return this.http.get<PlanetSystem>('https://localhost:7081/api/SolarSystem');
  }
}
