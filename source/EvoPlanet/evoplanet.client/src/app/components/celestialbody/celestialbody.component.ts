import { Component, inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { CelestialBodyService } from '../../services/celestial-body/celestial-body.service';
import { Planet } from '../../types';

@Component({
  selector: 'app-celestialbody',
  templateUrl: './celestialbody.component.html',
  styleUrls: ['./celestialbody.component.css']
})
export class CelestialbodyComponent implements OnInit {

  celestialBodies: Array<Planet> = [];
  celestialBodyService = inject(CelestialBodyService);
  newPlanet: Planet = {
    Name: '',
    Radius: 0,
    Mass: 0,
    id: ''
  };

  ngOnInit(): void {
    this.celestialBodyService.getCelestialBodies().subscribe(
      {
        next: celestialarray => {
          this.celestialBodies = celestialarray;
        }
      }
    );
  }

  addPlanet(form: NgForm): void {
    if (form.invalid) {
      return;
    }

    this.celestialBodyService.postCelestialBody(this.newPlanet).subscribe({
      next: (planet) => {
        this.celestialBodies.push(planet);
        this.newPlanet = { id: '', Name: '', Radius: 0, Mass: 0 }; // Reset form
        form.resetForm();
      },
      error: (err) => {
        console.error('Error adding planet:', err);
      }
    });
  }
}
