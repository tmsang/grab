using System;
using tmsang.domain;

namespace tmsang.application
{
    public class ActiveAccountDto
    {                        
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }        
        public string Email { get; set; }
        public DateTime ModifiedDate { get; set; }

        public E_Status Status { get; set; }        
    }
}
