/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using EvoPlanet.Simulator.Celestial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoPlanet.Simulator.Simulator
{
    public interface ISimulator
    {
        public void Simulate(SolarSystem solarSystem, double seconds);
    }
}
