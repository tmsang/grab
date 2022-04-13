using System;

namespace tmsang.domain
{
    public class R_DriverDomainService
    {        
        readonly IRepository<R_Driver> driverAccountRepository;        

        public R_DriverDomainService(            
            IRepository<R_Driver> driverAccountRepository)
        {            
            this.driverAccountRepository = driverAccountRepository;            
        }

        public bool CanExists(string email, string phone)
        {
            // doi chieu email/phone voi database
            var r_DriverCheckRegisterAccountSpec = new R_DriverCheckRegisterAccountSpec(email, phone);
            var user = this.driverAccountRepository.FindOne(r_DriverCheckRegisterAccountSpec);

            return user != null;
        }

        //=============================================
        // DRIVER
        //=============================================
        public R_Driver GetDriverById(Guid id)
        {
            // doi chieu email/phone voi database
            var r_DriverGetByIdSpec = new R_DriverGetByIdSpec(id);
            var user = this.driverAccountRepository.FindOne(r_DriverGetByIdSpec);

            return user;
        }

        public R_Driver GetDriverByEmail(string email)
        {
            // doi chieu email/phone voi database
            var r_DriverGetByEmailSpec = new R_DriverGetByEmailSpec(email);
            var user = this.driverAccountRepository.FindOne(r_DriverGetByEmailSpec);

            return user;
        }

        public R_Driver GetDriverByEmailIgnoreActive(string email)
        {
            // doi chieu email/phone voi database
            var r_DriverGetByEmailSpec = new R_DriverGetByEmailIgnoreActiveSpec(email);
            var user = this.driverAccountRepository.FindOne(r_DriverGetByEmailSpec);

            return user;
        }
        
    }
}
