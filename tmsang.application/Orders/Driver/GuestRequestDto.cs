using System;
using tmsang.domain;

namespace tmsang.application
{
    public class GuestRequestDto
    {
        public Guid OrderId { get; set; }
        public E_OrderStatus Status { get; set; }

        public string FromAddress { get; set; }

        public string ToLat { get; set; }
        public string ToLng { get; set; }
        public string ToAddress { get; set; }

        public DateTime RequestDateTime { get; set; }        
        public double Distance { get; set; }
        public double Cost { get; set; }
                
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }

        public string GuestLat { get; set; }
        public string GuestLng { get; set; }
    }
}
