using System;

namespace tmsang.domain
{
    public class R_Response: BaseEntity
    {
        public virtual int Id { get; protected set; }

        public virtual Guid OrderId { get; protected set; }
        public virtual Guid DriverId { get; protected set; }

        public virtual DateTime Start { get; protected set; }
        public virtual DateTime End { get; protected set; }

        public virtual double Fee { get; protected set; }         // tien to A_ mang y nghia la cot tinh toan -> nguyen tac: khong dua cot tinh toan de luu tru
        public virtual double Tax { get; protected set; }         // tien to A_ mang y nghia la cot tinh toan -> nguyen tac: khong dua cot tinh toan vao luu tru
    }
}
