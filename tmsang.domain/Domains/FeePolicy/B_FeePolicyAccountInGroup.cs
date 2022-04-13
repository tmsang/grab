using System;

namespace tmsang.domain
{
    public class B_FeePolicyAccountInGroup: BaseEntity
    {
        public virtual int Id { get; protected set; }
        
        // relatioship (1-n: n)
        public virtual Guid GroupId { get; protected set; }
        public virtual R_FeePolicyGroup Group { get; protected set; }
        
        public virtual Guid DriverId { get; protected set; }


        public static B_FeePolicyAccountInGroup Create(Guid groupId, Guid driverId) 
        {
            var policyInGroup = new B_FeePolicyAccountInGroup
            {                
                GroupId = groupId,
                DriverId = driverId
            };

            return policyInGroup;
        }

        public static B_FeePolicyAccountInGroup Create(int id, Guid groupId, Guid driverId)
        {
            var policyInGroup = new B_FeePolicyAccountInGroup
            {
                Id = id,
                GroupId = groupId,
                DriverId = driverId
            };

            return policyInGroup;
        }
    }
}
