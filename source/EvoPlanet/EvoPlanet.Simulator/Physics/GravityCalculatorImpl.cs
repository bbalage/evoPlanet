/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoPlanet.Simulator.Celestial;
using MathNet.Numerics.LinearAlgebra;


namespace EvoPlanet.Simulator.Simulator
{
    internal class GravityCalculatorImpl : IGravityCalculator
    {
        public GravityCalculatorImpl(double G) { this.G = G; }

        public Vector<double> CalcForce(CelestialBody body1, CelestialBody body2)
        {
            var r = body2.Position - body1.Position;
            var force = -(G * body1.Mass * body2.Mass) * r / (Math.Pow(r.Norm(2), 3));
            return force;
        }

        private double G;
    }
}
