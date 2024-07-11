import * as vecti from "vecti";

export interface Planet {
  id: string;
  Name: string;
  Radius: number;
  Mass: number;
}

export interface CelestialBody {
  CelestialBodyID: string;
  Radius: number;
  Mass: number;
  Coordinate: Coordinate;
  VelocityVector: VelocityVector;
}

export interface Coordinate {
  PX: number;
  PY: number;
}

export interface VelocityVector {
  VX: number;
  VY: number;
}

export interface CelestialBodyReference {
  celestialBodyID: string;
  Coordinate: Coordinate;
  VelocityVector: VelocityVector;
}

export interface IdHandler {
  id: string;
}

export interface SolarSystem {
  id: string;
  Name?: string;
  CelestialBodies: Array<CelestialBodyReference>;
}

//Simulator classes come here:
export class CollisionDetector {
  isColliding(celestialBodies: Array<Planet>, solarSystem: SolarSystem, c1: string, c2: string): boolean {
    const vectA: vecti.Vector = new vecti.Vector(solarSystem.CelestialBodies?.find(x => x.celestialBodyID == c1)?.Coordinate.PX || 0,
      solarSystem.CelestialBodies?.find(x => x.celestialBodyID == c1)?.Coordinate.PY || 0);
    const vectB: vecti.Vector = new vecti.Vector(solarSystem.CelestialBodies?.find(x => x.celestialBodyID == c2)?.Coordinate.PX || 0,
      solarSystem.CelestialBodies?.find(x => x.celestialBodyID == c2)?.Coordinate.PY || 0);
    const Distance = vectA.normalize();
    const radius1: number = celestialBodies.find(x => x.id == c1)?.Radius || 0;
    const radius2: number = celestialBodies.find(x => x.id == c2)?.Radius || 0;
    //return radius1 + radius2 > Distance;
    return false;
  }
}

export class GravityCalculatorImpl {
  G: number;
  constructor(G: number) {
    this.G = G;
  }
  CalcForce(celestial1: CelestialBody, celestial2: CelestialBody): vecti.Vector {
    var vector1: vecti.Vector = new vecti.Vector(celestial1.Coordinate.PX, celestial1.Coordinate.PY);
    var vector2: vecti.Vector = new vecti.Vector(celestial2.Coordinate.PX, celestial2.Coordinate.PY);

    const r: vecti.Vector = vector2.subtract(vector1);
    const distance = r.length();
    const gPart: number = (this.G * celestial2.Mass * celestial1.Mass) / (distance * distance);
    const force: vecti.Vector = r.normalize().multiply(gPart);
    return force;
  }
}

export class SimulatorImpl {
  CelestialBodies: Array<CelestialBody> = [];

  SmashTypes(system: SolarSystem, planets: Array<Planet>): void {
    for (var i: number = 0; i < system.CelestialBodies.length; i++) {
      for (var j: number = 0; j < planets.length; j++) {
        if (planets[j].id == system.CelestialBodies[i].celestialBodyID) {
          this.CelestialBodies.push({
            CelestialBodyID: system.CelestialBodies[i].celestialBodyID,
            Radius: planets[j].Radius,
            Mass: planets[j].Mass,
            Coordinate: system.CelestialBodies[i].Coordinate,
            VelocityVector: system.CelestialBodies[i].VelocityVector
          });
        }
      }
    }
    //this.initializeVelocities();
  }

  /*initializeVelocities(): void {
    const center = this.CelestialBodies[0]; // Assuming the first celestial body is the center
    for (let i = 1; i < this.CelestialBodies.length; i++) {
      const body = this.CelestialBodies[i];
      const r = new vecti.Vector(body.Coordinate.PX - center.Coordinate.PX, body.Coordinate.PY - center.Coordinate.PY);
      const distance = r.length();
      const orbitalSpeed = Math.sqrt(center.Mass * 10 / distance); // Adjust the multiplier as needed
      body.VelocityVector.VX = -orbitalSpeed * (r.y / distance);
      body.VelocityVector.VY = orbitalSpeed * (r.x / distance);
    }
  }*/

  Simulate(seconds: number): void {
    var calculator: GravityCalculatorImpl = new GravityCalculatorImpl(10);
    var forceList: Array<vecti.Vector> = [];
    this.CelestialBodies.forEach(() => forceList.push(new vecti.Vector(0, 0)));

    for (let i = 1; i < this.CelestialBodies.length; i++) {
      for (let j = 0; j < this.CelestialBodies.length; j++) {
        if (i === j) continue;
        var forceVector: vecti.Vector = calculator.CalcForce(this.CelestialBodies[i], this.CelestialBodies[j]);
        forceList[i] = forceList[i].add(forceVector);
      }
    }

    for (let i = 1; i < this.CelestialBodies.length; i++) {
      var acceleration: vecti.Vector = forceList[i].divide(this.CelestialBodies[i].Mass);
      acceleration = acceleration.multiply(seconds);
      this.CelestialBodies[i].VelocityVector.VX += acceleration.x;
      this.CelestialBodies[i].VelocityVector.VY += acceleration.y;
    }

    for (let i = 1; i < this.CelestialBodies.length; i++) {
      var velocity: vecti.Vector = new vecti.Vector(this.CelestialBodies[i].VelocityVector.VX, this.CelestialBodies[i].VelocityVector.VY);
      velocity = velocity.multiply(seconds);
      this.CelestialBodies[i].Coordinate.PX += velocity.x;
      this.CelestialBodies[i].Coordinate.PY += velocity.y;
    }
  }
}
