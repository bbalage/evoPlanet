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
  VelocityVector: VelocityVector;
}

export interface IdHandler{
  id: string;
}

export interface SolarSystem
{
  id: string;
  Name?: string;
  CelestialBodies?: Array<CelestialBodyReference>;
}
