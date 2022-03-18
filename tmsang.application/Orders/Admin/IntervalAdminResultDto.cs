using System.Collections.Generic;

namespace tmsang.application
{
    public class IntervalAdminResultDto
    {
        public IEnumerable<AdminRequestDto> Requests { get; set; }        
        public IEnumerable<NearestDriverDto> NearestDrivers { get; set; }        
    }
}
