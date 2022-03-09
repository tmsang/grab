using System;
using tmsang.domain;

namespace tmsang.application
{
    // Driver xem thong tin message
    public class DriverRequestHistoryDto
    {
        public Guid OrderId { get; set; }
        public E_OrderStatus Status { get; set; }

        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime RequestDateTime { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public double Distance { get; set; }
        public double Cost { get; set; }
        public float Rating { get; set; }

        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
    }
}
