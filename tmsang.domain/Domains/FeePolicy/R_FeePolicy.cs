using System;

namespace tmsang.domain
{
    public class R_FeePolicy: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
                                
        public virtual Guid GroupId { get; protected set; }             // root chi xai Id khong nen set Object        
        public virtual string ProvinceOrCity { get; protected set; }

        public virtual double Cost { get; protected set; }


        public static R_FeePolicy Create(string provinceOrCity, Guid groupId, double cost) {
            var policy = new R_FeePolicy { 
                Id = Guid.NewGuid(),
                ProvinceOrCity = provinceOrCity,
                GroupId = groupId,
                Cost = cost
            };

            return policy;
        }
    }
}
