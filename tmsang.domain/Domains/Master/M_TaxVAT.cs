using System;

namespace tmsang.domain
{
    public class M_TaxVAT: MasterEntity
    {
        public virtual double Cost { get; protected set; }

        public static M_TaxVAT Create(int id, string name, DateTime from, DateTime to, E_Status status, double cost)
        {
            var tax = new M_TaxVAT
            {
                Id = id,
                Name = name,
                From = from,
                To = to,
                Status = status,
                ChangedDate = DateTime.Now,
                Cost = cost
            };

            return tax;
        }
    }
}
