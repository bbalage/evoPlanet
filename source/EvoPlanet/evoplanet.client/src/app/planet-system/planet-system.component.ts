import { Component, OnInit } from '@angular/core';
import { Planet, PlanetSystem } from '../types';



@Component({
  selector: 'app-planet-system',
  templateUrl: './planet-system.component.html',
  styleUrls: ['./planet-system.component.css']
})


export class PlanetSystemComponent implements OnInit {
  planetSystem!: PlanetSystem;
  constructor()
  {
  }

  ngOnInit(): void
  {
    this.planetSystem.Planets = [];
    this.planetSystem.Planets?.push({ Name: 'Jupiter', PX: 0, PY: 0, VX: 0, VY: 0, Radius: 100, Mass: 500 });
    this.planetSystem.Planets?.push({ Name: 'Mercury', PX: 10, PY: 20, VX: 30, VY: 40, Radius: 400, Mass: 2000 });

  }
}


