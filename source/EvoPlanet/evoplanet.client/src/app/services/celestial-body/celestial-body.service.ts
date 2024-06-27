import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Planet } from '../../types';

@Injectable({
  providedIn: 'root'
})
export class CelestialBodyService {

  constructor(private http: HttpClient) { }

  getCelestialBodies() {
    return this.http.get<Array<Planet>>('https://localhost:7081/api/CelestialBody/mongo');
  }
}
