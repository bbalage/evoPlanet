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

  //TODO: make RESTAPI call using this:
  /*
getSolarSystem(): Observable<PlanetSystem> {
  return this.http.get<PlanetSystem>('localthost...');
}
*/


  getSolarSystem(): PlanetSystem {
    this.solarSystem.Planets = [];
    this.solarSystem.Planets?.push({ Name: 'Jupiter', PX: 0, PY: 0, VX: 0, VY: 0, Radius: 100, Mass: 500 });
    this.solarSystem.Planets?.push({ Name: 'Mercury', PX: 10, PY: 20, VX: 30, VY: 40, Radius: 400, Mass: 2000 });
    this.solarSystem.Planets?.push({ Name: 'Uranus', PX: 20, PY: 40, VX: 15, VY: 20, Radius: 500, Mass: 3000 });
    this.solarSystem.Planets?.push({ Name: 'Pluto', PX: 30, PY: 20, VX: 70, VY: 15, Radius: 200, Mass: 1000 });
    this.solarSystem.Planets?.push({ Name: 'Mars', PX: 50, PY: 80, VX: 235, VY: 221, Radius: 542, Mass: 3020 });

    return this.solarSystem;
  }

}
