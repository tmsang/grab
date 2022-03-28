using System;
using tmsang.domain;

namespace tmsang.application
{
    public class ActionOnAccountDto
    {                        
        public Guid Id { get; set; }
        public string AccountType { get; set; }        
        public E_Status Status { get; set; }                
    }
    
}
