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
  handler: IdHandler = { id: '' }
  router = inject(Router);
  Alpha: number = 0;
  highestMass: number = 0;
  index: number = 0;
  celestialBodySprite: HTMLImageElement;
  lastFrameTime: number = 0;

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
    this.lastFrameTime = Date.now();
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

    this.canvas.width = 900
    this.canvas.height = 700;
    this.canvas.style.width = "900px";
    this.canvas.style.height = "700px";
  }

  Draw(): void {
    const ctx: any = this.canvas.getContext("2d");

    ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);

    ctx.beginPath();

    this.simulator.CelestialBodies.forEach((item: CelestialBody) => {
      ctx.drawImage(
        this.celestialBodySprite,
        item.Coordinate.PX,
        item.Coordinate.PY,
        20,
        20
      );
    });

    this.Alpha += 30;

    requestAnimationFrame(() => {
      const now = Date.now();
      const deltaTime = now - this.lastFrameTime
      this.Draw();
      if (deltaTime >= 100) {
        this.simulator.Simulate(0.1);
        this.lastFrameTime = now;
      }
    });
  }

  FillData(): void {
    this.simulator.SmashTypes(this.planetSystem, this.planets);
    console.log("Result of smashed types");
    console.log(this.simulator.CelestialBodies);

    this.simulationCanStart = true;
    this.Draw();

  }

}
