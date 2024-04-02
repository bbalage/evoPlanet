import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Planet } from './types';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {

  public planet!: Planet;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    //this.getPlanet();
  }

  getPlanet() {
    this.http.get<Planet>('https://localhost:7081/api/Planet').subscribe(
      (result) => {
        this.planet = result;
        console.log(this.planet.Name);
      },
      (error) => {
        console.error(error);
      }
    );
  }


  title = 'evoplanet.client';
}
