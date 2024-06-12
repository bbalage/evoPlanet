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
    public class CollisionDetector
    {
        public CollisionDetector() { }

        public bool IsColliding(CelestialBody body1, CelestialBody body2)
        {
            var distanceOfCenters = (body2.Position - body1.Position).L2Norm();
            return distanceOfCenters < body1.Radius + body2.Radius;
        }
    }
}
