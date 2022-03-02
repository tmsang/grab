using System;
using System.Collections.Generic;
using System.Linq;

namespace tmsang.domain
{
    public class R_Guest: BaseEntity, IAggregateRoot
    {
        // =========================================
        // A. Design Entity + Properties
        // =========================================        
        public virtual Guid Id { get; protected set; }
        public virtual string FullName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Phone { get; protected set; }

        public virtual E_Status AccountStatus { get; protected set; }

        public virtual string Password { get; protected set; }
        public virtual byte[] Salt { get; protected set; }

        // relationship (1-n: 1)
        public virtual IList<B_GuestHistory> Histories { get; protected set; }
        public virtual IList<B_GuestLocation> Locations { get; set; }
        public virtual IList<B_GuestPolicy> Policies { get; protected set; }
        
        public virtual IList<R_Request> Requests { get; protected set; }
        public virtual IList<R_Payment> Payments { get; protected set; }
        public virtual IList<R_Evaluation> Evaluations { get; protected set; }

        // =========================================
        // B. Events of guest
        // =========================================
        // 0. Event Sourcing: this is technical
        // 1. Guest can create request From-To -> OrderRequest.Add
        // 2. Guest need to know Distance, Cost -> OrderRequest.Get
        // 3. Guest can cancel this trip (after 3 minutes without response | or manually cancel) -> OrderRequest.Update
        // 4. Guest need to know Driver take care this trip -> OrderResponse.Add
        // 5. Guest can vote|rate this trip -> OrderEvaluation.Add
        // 6. Guest can view History (trips) -> OrderHistory.Get

        // 0. Event Sourcing: this is technical
        public static R_Guest Create(string fullName, string phone, string email, string password, byte[] salt) {
            return Create(Guid.NewGuid(), fullName, phone, email, password, salt);
        }

        public static R_Guest CreateForSeed(Guid id, string fullName, string phone, string email, string password, byte[] salt) {
            var guest = new R_Guest
            {
                Id = id,
                FullName = fullName,
                Phone = phone,
                Email = email,
                AccountStatus = E_Status.Active,

                Password = password,
                Salt = salt
            };

            return guest;
        }

        public static R_Guest Create(Guid id, string fullName, string phone, string email, string password, byte[] salt) {
            var guest = new R_Guest {
                Id = id,
                FullName = fullName,
                Phone = phone,
                Email = email,

                Password = password,
                Salt = salt                
            };
            // add event sourcing
            DomainEvents.Raise<R_GuestCreatedEvent>(new R_GuestCreatedEvent() { R_Guest = guest });

            return guest;
        }

        // 1. Guest can create request From-To -> OrderRequest.Add


        // 2. Guest need to know Distance, Cost -> OrderRequest.Get
        // -> this is _orderRequest list out

        // 3. Guest can cancel this trip (after 3 minutes without response | or manually cancel) -> OrderRequest.Update


        // 4. Guest need to know Driver take care this trip -> OrderResponse.Add
        // 5. Guest can vote|rate this trip -> OrderEvaluation.Add
        // 6. Guest can view History (trips) -> OrderHistory.Get


        // =========================================
        // C. Business & Logic
        // =========================================

        public virtual void Activate()      // y nghia: protected set la vay - gom logic vao
        {
            this.AccountStatus = E_Status.Active;
        }        

        public virtual void ResetPassword(string hash, byte[] salt)
        {
            this.Password = hash;
            this.Salt = salt;

            DomainEvents.Raise<R_GuestChangePasswordEvent>(new R_GuestChangePasswordEvent { R_Guest = this });
        }

        public virtual void PushPosition(double lat, double lng)
        {
            // delete old location (maybe change later)
            Locations = new List<B_GuestLocation>();

            // add location latest
            Locations.Add(B_GuestLocation.Create(lat, lng, DateTime.Now.Ticks));
        }
    }
}
