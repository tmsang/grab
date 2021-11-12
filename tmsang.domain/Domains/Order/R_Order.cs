using System;

namespace tmsang.domain
{
    public class R_Order: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual E_OrderStatus Status { get; protected set; }

        // NOT: set relationship to Guest
        public virtual Guid GuestId { get; protected set; }
        // NOT: set relationship to Request


        // ===========================================================
        // METHODS
        // ===========================================================
        public static R_Order Create(Guid guestId, E_OrderStatus status)
        {
            return Create(Guid.NewGuid(), guestId, status);
        }
        public static R_Order Create(Guid id, Guid guestId, E_OrderStatus status)
        {
            var order = new R_Order { 
                Id = id,
                GuestId = guestId,
                Status = status
            };

            return order;
        }

        public void UpdateStatus(E_OrderStatus status) {
            this.Status = status;
        }
    }
}
