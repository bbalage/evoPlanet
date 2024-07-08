import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as vecti from 'vecti';
import { CelestialBodyService } from '../../services/celestial-body/celestial-body.service';
import { SolarSystemService } from '../../services/solar-system/solar-system.service';
import { CelestialBody, CelestialBodyReference, Coordinate, GravityCalculatorImpl, IdHandler, Planet, SimulatorImpl, SolarSystem, VelocityVector } from '../../types';

@Component({
  selector: 'app-simulator',
  standalone: true,
  imports: [HttpClientModule, CommonModule],
  templateUrl: './simulator.component.html',
  styleUrls: ['./simulator.component.css'],
  providers: [SolarSystemService]
})



export class SimulatorComponent implements OnInit {
  simulationCanStart: boolean = false;
  forceCalaculator: GravityCalculatorImpl = new GravityCalculatorImpl(10);
  planets: Array<Planet> = [];
  activatedRoute = inject(ActivatedRoute);
  handler: IdHandler = { id:'' }
  router = inject(Router);
  Alpha: number = 0;
  highestMass: number = 0;
  index: number = 0;
  celestialBodySprite: HTMLImageElement;

  canvas!: HTMLCanvasElement;

  planetSystem: SolarSystem = {
    id: '',
    CelestialBodies: []
  };
  solarService: SolarSystemService = inject(SolarSystemService);
  celestialService: CelestialBodyService = inject(CelestialBodyService);
  positions: Array<vecti.Vector> = [];
  velocities: Array<VelocityVector> = [];

  simulator: SimulatorImpl = new SimulatorImpl();

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
          console.log(item);
          this.planetSystem.CelestialBodies?.forEach(
            (celestialbody: CelestialBodyReference) => {
              this.positions.push(new vecti.Vector(celestialbody.Coordinate.PX, celestialbody.Coordinate.PY));
            }
          );

        }
      }
    );

    this.celestialService.getCelestialBodies().subscribe(
      {
        //TODO search for id from celestialbodies from solarsystem
        next: (item: Array<Planet>) => {
          this.planets = item;
          console.log(item);
        }
      }
    );
    if (this.simulationCanStart) {
    }
    else {
      console.log("Click button to start simulation.");
    }



    this.canvas = <HTMLCanvasElement>document.getElementById("simulator-canvas");

    this.canvas.width = 800
    this.canvas.height = 600;
    this.canvas.style.width = "600px";
    this.canvas.style.height = "800px";


  }

  Draw(): void {
    const ctx: any = this.canvas.getContext("2d");

    ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);

    
    //Hardcoded index to be 2 but ideally it should be decided with mass
    this.index = 0;
   
        ctx.beginPath();
       // ctx.arc(this.positions[i].PX + 10 * Math.cos(this.Alpha), this.positions[i].PY + 10 * Math.sin(this.Alpha), 10, 0, 2 * Math.PI);
        // ctx.stroke();

        this.simulator.CelestialBodies.forEach((item: CelestialBody) => {
          ctx.drawImage(
            this.celestialBodySprite,
            item.Coordinate.PX,
            item.Coordinate.PY,
            20,
            20
          );
        });
        /*
        ctx.drawImage(
          this.celestialBodySprite,
          this.positions[i].x + 10 * Math.cos(this.Alpha),
          this.positions[i].y + 10 * Math.sin(this.Alpha),
          20,
          20
        );
        */
     

    //TODO:Remove setTimeOut.
    this.Alpha += 30;
    requestAnimationFrame(() =>
    {
      this.Draw();

      /*
       500, y : 300, vx: 0, vy: 0, mass: 1000000
x: 600, y: 300, vx: 0, vy: 40, mass: 10
      */

      this.simulator.Simulate(0.1);
    });
    
  
  }

  //TODO give seconds here
  FillData(): void {
    this.simulator.SmashTypes(this.planetSystem, this.planets);
    console.log("Result of smashed types");
    console.log(this.simulator.CelestialBodies);
   
    this.simulationCanStart = true;
    this.Draw();

  }

}
