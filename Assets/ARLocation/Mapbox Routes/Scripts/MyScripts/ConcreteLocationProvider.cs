using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARLocation
{
    public class ConcreteLocationProvider : AbstractLocationProvider
    {
        public override string Name => "ConcreteLocationProvider";

        public override bool IsCompassEnabled => true;

        protected override LocationReading? ReadLocation()
        {
            // Implement location reading logic here
            return new LocationReading(); // Return a dummy location for now
        }

        protected override HeadingReading? ReadHeading()
        {
            // Implement heading reading logic here
            return new HeadingReading(); // Return a dummy heading for now
        }

        protected override void RequestLocationAndCompassUpdates()
        {
            // Implement location and compass update request logic here
        }

        protected override void UpdateLocationRequestStatus()
        {
            // Implement location request status update logic here
        }
    }
}

