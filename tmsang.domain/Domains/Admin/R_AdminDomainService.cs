using System;

namespace tmsang.domain
{
    public class R_AdminDomainService
    {
        readonly IRepository<R_Admin> adminAccountRepository;                

        public R_AdminDomainService(
            IRepository<R_Admin> adminAccountRepository)
        {
            this.adminAccountRepository = adminAccountRepository;            
        }

        public bool CanExists(string email, string phone)
        {
            // doi chieu email/phone voi database
            var r_AdminCheckRegisterAccountSpec = new R_AdminCheckRegisterAccountSpec(email, phone);
            var user = this.adminAccountRepository.FindOne(r_AdminCheckRegisterAccountSpec);

            return user != null;
        }

        //=============================================
        // ADMIN
        //=============================================
        public R_Admin GetAdminById(Guid id)
        {
            // doi chieu email/phone voi database
            var r_AdminGetByIdSpec = new R_AdminGetByIdSpec(id);
            var user = this.adminAccountRepository.FindOne(r_AdminGetByIdSpec);

            return user;
        }

        public R_Admin GetAdminByEmail(string email)
        {
            // doi chieu email/phone voi database
            var r_AdminGetByEmailSpec = new R_AdminGetByEmailSpec(email);
            var user = this.adminAccountRepository.FindOne(r_AdminGetByEmailSpec);

            return user;
        }

        public R_Admin GetAdminByEmailIgnoreActive(string email)
        {
            // doi chieu email/phone voi database
            var r_AdminGetByEmailSpec = new R_AdminGetByEmailIgnoreActiveSpec(email);
            var user = this.adminAccountRepository.FindOne(r_AdminGetByEmailSpec);

            return user;
        }
        
    }
}
