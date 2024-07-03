import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SolarSystemService } from '../../services/solar-system/solar-system.service';
import { CelestialBodyReference, Coordinate, IdHandler, SolarSystem, VelocityVector } from '../../types';

@Component({
  selector: 'app-simulator',
  standalone: true,
  imports: [HttpClientModule, CommonModule],
  templateUrl: './simulator.component.html',
  styleUrls: ['./simulator.component.css'],
  providers: [SolarSystemService]
})



export class SimulatorComponent implements OnInit {
  activatedRoute = inject(ActivatedRoute);
  handler: IdHandler = { id:'' }
  router = inject(Router);
  Alpha: number = 0;
  highestMass: number = 0;
  index: number = 0;
  celestialBodySprite: HTMLImageElement;

  constructor() {
    this.celestialBodySprite = new Image();
    this.celestialBodySprite.src = "assets/logo.png";

  }


  ngOnInit(): void {
    const solarId: string = this.activatedRoute.snapshot.params['id'];
    this.handler.id = solarId
    this.solarService.getSolarSystemById(this.handler).subscribe(
      {
        next: (item) => {
          this.planetSystem = item;

          this.planetSystem.CelestialBodies?.forEach(
            (celestialbody: CelestialBodyReference) => {
              this.positions.push(celestialbody.Coordinate);
              this.velocities.push(celestialbody.VelocityVector);
            }
          );

        }
      }
    );
    

    this.Draw();

  }

  Draw(): void {
    const canvas: HTMLCanvasElement = <HTMLCanvasElement>document.getElementById("simulator-canvas");
    const ctx: any = canvas.getContext("2d");

    ctx.clearRect(0, 0, canvas.width, canvas.height);

    
    //Hardcoded index to be 2 but ideally it should be decided with mass
    this.index = 0;
    for (let i in this.positions) {
      if (i != this.index.toString()) {
        ctx.beginPath();
       // ctx.arc(this.positions[i].PX + 10 * Math.cos(this.Alpha), this.positions[i].PY + 10 * Math.sin(this.Alpha), 10, 0, 2 * Math.PI);
        // ctx.stroke();
        ctx.drawImage(
          this.celestialBodySprite,
          this.positions[i].PX + 10 * Math.cos(this.Alpha),
          this.positions[i].PY + 10 * Math.sin(this.Alpha),
          20,
          20
        );
      }
      else
      {
        ctx.beginPath();
       // ctx.arc(this.positions[i].PX, this.positions[i].PY, 10, 0, 2 * Math.PI);
        // ctx.stroke();
        ctx.drawImage(
          this.celestialBodySprite,
          this.positions[i].PX,
          this.positions[i].PY,
          20,
          20
        );
      }
    }


    //TODO:Remove setTimeOut.
    this.Alpha += 30;
    setTimeout( () => {
      requestAnimationFrame(() => { this.Draw() });
    }, 1000 / 5);
  
}

  planetSystem: SolarSystem = { id: ''  };
  solarService: SolarSystemService = inject(SolarSystemService);

  positions: Array<Coordinate> = [];
  velocities: Array<VelocityVector> = [];

}
