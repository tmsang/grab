using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_Admin : BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FullName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Phone { get; protected set; }
        public virtual string Address { get; protected set; }
        public virtual E_Status AccountStatus { get; protected set; } = E_Status.Deactived;

        public virtual string Password { get; protected set; }
        public virtual byte[] Salt { get; protected set; }

        // relationship
        public virtual IList<B_AdminHistory> Histories { get; protected set; }
        public virtual IList<B_AdminPolicy> Policies { get; protected set; }


        public static R_Admin Create(
            string fullName, string email, string phone, string address, string password, byte[] salt) 
        {
            return Create(Guid.NewGuid(), fullName, email, phone, address, password, salt);
        }

        public static R_Admin CreateForSeed(
            Guid id, string fullName, string email, string phone, string address,
            string password, byte[] salt)
        {
            var admin = new R_Admin
            {
                Id = id,
                FullName = fullName,
                Email = email,
                Phone = phone,
                Address = address,
                AccountStatus = E_Status.Actived,

                Password = password,
                Salt = salt
            };            

            return admin;
        }

        public static R_Admin Create(
            Guid id, string fullName, string email, string phone, string address, 
            string password, byte[] salt)
        {
            var admin = new R_Admin { 
                Id = id,
                FullName = fullName,                
                Email = email,
                Phone = phone,
                Address = address,                

                Password = password,
                Salt = salt                
            };
            admin.Histories.Add(B_AdminHistory.Create(E_Status.None, "Create account"));

            DomainEvents.Raise<R_AdminCreatedEvent>(new R_AdminCreatedEvent { R_Admin = admin });

            return admin;
        }

        public virtual void ChangeStatus(E_Status status)      // y nghia: protected set la vay - gom logic vao
        {
            this.AccountStatus = status;
            this.Histories.Add(B_AdminHistory.Create(status, $"Change status account {status.ToString()}"));
        }
        
        public virtual void ResetPassword(string hash, byte[] salt) {
            this.Password = hash;
            this.Salt = salt;
            this.Histories.Add(B_AdminHistory.Create(E_Status.Actived, "Reset password"));

            DomainEvents.Raise<R_AdminChangePasswordEvent>(new R_AdminChangePasswordEvent { R_Admin = this });
        }
    }
}
