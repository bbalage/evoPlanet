//TODO: Waiting for backend to adapt the vector class
export interface Planet
{
  CelestialBodyID: string;
  Name: string;
  Radius: number;
  Mass: number;
}

export interface Coordinate
{
  PX: number;
  PY: number;
}

export interface VelocityVector
{
  VX: number;
  VY: number;
}

export interface CelestialBodyReference
{
  CelestialBodyID: string;
  Coordinate: Coordinate;
  Velocity: VelocityVector;
}

export interface SolarSystem
{
  Id?: string;
  Name?: string;
  CelestialBodies?: Array<CelestialBodyReference>;
}
