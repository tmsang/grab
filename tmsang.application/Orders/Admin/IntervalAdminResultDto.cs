using System.Collections.Generic;

namespace tmsang.application
{    
    // ho tro interval
    public class IntervalAdminResultDto
    {
        public StatisticDto Statistic { get; set; }
        public IEnumerable<NearestDriverDto> NearestDrivers { get; set; }        
    }
}
