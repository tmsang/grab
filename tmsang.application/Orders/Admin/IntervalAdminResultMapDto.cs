using System.Collections.Generic;

namespace tmsang.application
{
    public class IntervalAdminResultMapDto
    {
        public int TotalRequests { get; set; }
        public int TotalNew { get; set; }
        public int TotalProcessing { get; set; }
        public int TotalDone { get; set; }
        public int TotalCancel { get; set; }

        public IEnumerable<AdminPositionDto> Positions { get; set; }        
    }
}
