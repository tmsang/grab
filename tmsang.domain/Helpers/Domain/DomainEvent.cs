﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tmsang.domain
{
    public abstract class DomainEvent
    {
        public string Type { get { return this.GetType().Name; } }

        public DateTime Created { get; private set; }

        public Dictionary<string, Object> Args { get; private set; }

        public string CorrelationID { get; set; }

        public DomainEvent() {
            this.Created = DateTime.Now;
            this.Args = new Dictionary<string, object>();
        }

        public abstract void Flatten();
    }
}
