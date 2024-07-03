import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { SolarSystemService } from '../../services/solar-system/solar-system.service';
import { Planet, SolarSystem } from '../../types';

@Component({
  selector: 'app-planet-system',
  templateUrl: './planet-system.component.html',
  styleUrls: ['./planet-system.component.css']
})


export class PlanetSystemComponent implements OnInit {
  planetSystem: Array<SolarSystem> = [];;
  router = inject(Router);

  constructor(private solarSystemService: SolarSystemService)
  {
  }

  goToSimulation(id: string): void{
    this.router.navigate(['/simulator', id]);
  }

  ngOnInit(): void
  {
    /*this.solarSystemService.getSolarSystem().subscribe({
      next: (item: Array<SolarSystem>) => {
        this.planetSystem = item;
       
      }
    });*/
  }
}


