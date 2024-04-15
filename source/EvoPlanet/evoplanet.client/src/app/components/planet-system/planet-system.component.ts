import { Component, OnInit } from '@angular/core';
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
    this.planetSystem = this.solarSystemService.getSolarSystem();
  }
}


