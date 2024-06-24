import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { SolarSystemService } from '../../services/solar-system/solar-system.service';
import { Planet, PlanetSystem } from '../../types';

@Component({
  selector: 'app-planet-system',
  templateUrl: './planet-system.component.html',
  styleUrls: ['./planet-system.component.css']
})


export class PlanetSystemComponent implements OnInit {

  planetSystem: PlanetSystem = {};


  constructor(private solarSystemService: SolarSystemService)
  {
  }

  ngOnInit(): void
  {

    this.solarSystemService.getSolarSystem().subscribe({
      next: (item: PlanetSystem) => {
        this.planetSystem = item;
      }
    });
  }
}
