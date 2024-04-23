/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using EvoPlanet.Simulator.Celestial;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoPlanet.Simulator.Simulator
{
    public interface IGravityCalculator
    {
        public Vector<double> CalcForce(CelestialBody body1, CelestialBody body2);
    }
}
