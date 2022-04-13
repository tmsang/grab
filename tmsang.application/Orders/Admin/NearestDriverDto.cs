using System;

namespace tmsang.application
{
    public class NearestDriverDto
    {
        public Guid OrderId { get; set; }
        public Guid DriverId { get; set; }
        public double Distance { get; set; }
    }
}
