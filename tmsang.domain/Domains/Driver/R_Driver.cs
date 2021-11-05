﻿using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_Driver: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string FullName { get; protected set; }        
        public virtual string Email { get; protected set; }
        public virtual string Phone { get; protected set; }
        public virtual string PersonalId { get; protected set; }
        public virtual string PersonalImage { get; protected set; }
        public virtual string Address { get; protected set; }
        public virtual E_Status AccountStatus { get; protected set; } = E_Status.Deactive;

        public virtual string Password { get; protected set; }
        public virtual byte[] Salt { get; protected set; }
        
        // should make relationship, IList (allow Add) - but IEnumerable is not
        public virtual IList<B_DriverBike> Bikes { get; set; } 


        public static R_Driver Create(string fullName, string personId, string personImage, string address, string phone, string email, string password, byte[] salt)
        {
            return Create(Guid.NewGuid(), fullName, personId, personImage, address, phone, email, password, salt);
        }
        public static R_Driver Create(Guid id, string fullName, string personId, string personImage, string address, string phone, string email, string password, byte[] salt)
        {
            var user = new R_Driver
            {
                Id = id,
                FullName = fullName,  
                PersonalId = personId,
                PersonalImage = personImage,
                Address = address,
                Phone = phone,
                Email = email,                

                Password = password,
                Salt = salt                
            };

            DomainEvents.Raise<R_DriverCreatedEvent>(new R_DriverCreatedEvent { R_Driver = user });

            return user;
        }

        public virtual void Activate()      // y nghia: protected set la vay - gom logic vao
        {
            this.AccountStatus = E_Status.Active;
        }

        public virtual void ResetPassword(string newPassword)
        {
            this.Password = newPassword;
        }
    }
}
