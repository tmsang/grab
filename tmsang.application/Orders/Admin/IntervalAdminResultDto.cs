using System.Collections.Generic;

namespace tmsang.application
{    
    // ho tro interval
    public class IntervalAdminResultDto
    {
        public IEnumerable<AdminRequestDto> Requests { get; set; }
        public StatisticDto Statistic { get; set; }
        public IEnumerable<NearestDriverDto> NearestDrivers { get; set; }        
    }
}
