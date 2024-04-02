import { Observable } from "rxjs";

export interface Planet
{
  Name?: string;
  PX: number;
  PY: number;
  VX: number;
  VY: number;
  Radius: number;
  Mass: number;
}

export interface PlanetSystem
{
  //Maybe make it an observable
  Planets?: Array<Planet>;
}
