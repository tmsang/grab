using System;

namespace tmsang.domain
{
    public class M_RoutineCost: MasterEntity
    {
        public virtual double Cost { get; protected set; }

        public static M_RoutineCost Create(int id, string name, DateTime from, DateTime to, E_Status status, double cost) 
        {
            var routineCost = new M_RoutineCost {
                Id = id,
                Name = name,
                From = from,
                To = to,
                Status = status,
                ChangedDate = DateTime.Now,
                Cost = cost
            };

            return routineCost;
        }
    }
}
