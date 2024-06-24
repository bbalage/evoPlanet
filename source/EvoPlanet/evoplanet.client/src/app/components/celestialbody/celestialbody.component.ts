import { Component, inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CelestialBodyService } from '../../services/celestial-body/celestial-body.service';
import { Planet, PlanetSystem } from '../../types';

@Component({
  selector: 'app-celestialbody',
  templateUrl: './celestialbody.component.html',
  styleUrls: ['./celestialbody.component.css']
})
export class CelestialbodyComponent implements OnInit {
  celestialBodies: Array<Planet> = [];
  celestialBodyService = inject(CelestialBodyService);
  ngOnInit(): void {
    this.celestialBodyService.getCelestialBodies().subscribe(
      {
        next: celestialarray => {
          this.celestialBodies = celestialarray;
        }
      }
    );
  }
}
