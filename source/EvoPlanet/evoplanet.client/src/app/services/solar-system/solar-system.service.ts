import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { IdHandler, SolarSystem } from '../../types';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};



@Injectable({
  providedIn: 'root'
})
export class SolarSystemService {

  constructor(private http: HttpClient) { }

  getSolarSystemById(handler: IdHandler): Observable<SolarSystem> {
    return this.http.post<SolarSystem>('https://localhost:7081/api/SolarSystem/mongo/getOne/', handler);
  }
}
