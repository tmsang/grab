using System;

namespace tmsang.domain
{
    public class R_Admin : BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FullName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Phone { get; protected set; }
        public virtual string Address { get; protected set; }
        public virtual E_Mode Mode { get; protected set; } = E_Mode.Deactive;

        public virtual string Password { get; protected set; }
        public virtual byte[] Salt { get; protected set; }


        public static R_Admin Create(
            string fullName, string email, string phone, string address, string password, byte[] salt) 
        {
            return Create(Guid.NewGuid(), fullName, email, phone, address, password, salt);
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

            DomainEvents.Raise<R_AdminCreatedEvent>(new R_AdminCreatedEvent { R_Admin = admin });

            return admin;
        }

        public virtual void Activate()      // y nghia: protected set la vay - gom logic vao
        {
            this.Mode = E_Mode.Active;            
        }

        public virtual void ResetPassword(string hash, byte[] salt) {
            this.Password = hash;
            this.Salt = salt;
        }
    }
}
