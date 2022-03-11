using System;
using System.Collections.Generic;
using tmsang.domain;

namespace tmsang.application
{
    public class IntervalGuestResultDto
    {
        public Guid OrderId { get; set; }
        public E_OrderStatus Status { get; set; }
        public IEnumerable<DriverPositionDto> Positions { get; set; }        
    }

    public class DriverPositionDto
    {
        public string Phone { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Distance { get; set; }
    }
}
