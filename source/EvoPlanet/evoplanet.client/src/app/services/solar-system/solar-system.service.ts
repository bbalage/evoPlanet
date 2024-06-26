import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SolarSystem } from '../../types';

@Injectable({
  providedIn: 'root'
})
export class SolarSystemService {

  constructor(private http: HttpClient) { }

  getSolarSystem() {
    return this.http.get<Array<SolarSystem>>('https://localhost:7081/api/SolarSystem/mongo');
}

}
