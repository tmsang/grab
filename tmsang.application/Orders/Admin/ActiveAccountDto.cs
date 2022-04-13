using System;
using System.Collections.Generic;
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

        public IEnumerable<AccountHistoryDto> Histories { get; set; }
    }

    public class AccountHistoryDto
    {
        public int Id { get; set; }
        public DateTime HappenDate { get; set; }
        public E_Status Status { get; set; }
        public string Description { get; set; }
    }
}
