/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoPlanet.Simulator.Celestial
{
    public class SolarSystem
    {
        public List<CelestialBody> CelestialBodies { get; set; } = new List<CelestialBody>();
    }
}
