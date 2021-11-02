﻿using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public class DomainEventRecord
    {
        public string Type { get; set; }
        public List<KeyValuePair<string, string>> Args { get; set; }
        public string CorrelationID { get; set; }
        public DateTime Created { get; set; }
    }
}
