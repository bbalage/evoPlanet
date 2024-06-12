/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoPlanet.Simulator.Celestial
{
    public class CelestialBody
    {
        public CelestialBody(Vector<double> position, Vector<double> velocity, double mass, double radius)
        {
            Position = position;
            Velocity = velocity;
            Mass = mass;
            Radius = radius;
        }
        public Vector<double> Position { get; set; }
        public Vector<double> Velocity { get; set; }
        public double Mass {  get; set; }
        public double Radius { get; set; }
    }
}
