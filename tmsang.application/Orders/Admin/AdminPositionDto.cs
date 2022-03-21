using System;

namespace tmsang.application
{
    public class AdminPositionDto
    {                        
        public Guid Id { get; set; }
        public string Phone { get; set; }        
        public int Type { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
