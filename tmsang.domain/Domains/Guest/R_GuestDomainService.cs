using System;

namespace tmsang.domain
{
    public class R_GuestDomainService
    {        
        readonly IRepository<R_Guest> guestAccountRepository;

        public R_GuestDomainService(     
            IRepository<R_Guest> guestAccountRepository)
        {            
            this.guestAccountRepository = guestAccountRepository;
        }

        public bool CanExists(string email, string phone)
        {
            // doi chieu email/phone voi database
            var r_GuestCheckRegisterAccountSpec = new R_GuestCheckRegisterAccountSpec(email, phone);
            var user = this.guestAccountRepository.FindOne(r_GuestCheckRegisterAccountSpec);

            return user != null;
        }

        //=============================================
        // GUEST
        //=============================================
        public R_Guest GetGuestById(Guid id)
        {
            // doi chieu email/phone voi database
            var r_GuestGetByIdSpec = new R_GuestGetByIdSpec(id);
            var user = this.guestAccountRepository.FindOne(r_GuestGetByIdSpec);

            return user;
        }

        public R_Guest GetGuestByEmail(string email)
        {
            // doi chieu email/phone voi database
            var r_GuestGetByEmailSpec = new R_GuestGetByEmailSpec(email);
            var user = this.guestAccountRepository.FindOne(r_GuestGetByEmailSpec);

            return user;
        }

        public R_Guest GetGuestByEmailIgnoreActive(string email)
        {
            // doi chieu email/phone voi database
            var r_GuestGetByEmailSpec = new R_GuestGetByEmailIgnoreActiveSpec(email);
            var user = this.guestAccountRepository.FindOne(r_GuestGetByEmailSpec);

            return user;
        }

    }
}
