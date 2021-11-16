﻿using System;
using tmsang.domain;

namespace tmsang.application
{
    public class DriverTransactionHistoriesDto
    {
        public Guid OrderId { get; set; }
        public E_OrderStatus Status { get; set; }

        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string Reason { get; set; }
        public double Distance { get; set; }
        public double Cost { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
                
    }
}
