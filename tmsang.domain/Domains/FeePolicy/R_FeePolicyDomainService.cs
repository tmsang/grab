using System;

namespace tmsang.domain
{
    public class R_FeePolicyDomainService
    {
        readonly IRepository<R_FeePolicy> feePolicyRepository;
        readonly R_LocationDomainService locationDomainService;
        readonly IRepository<R_FeePolicyGroup> feePolicyGroupRepository;
        readonly IRepositoryNonRoot<M_TaxVAT> taxRepository;

        public R_FeePolicyDomainService(
            IRepository<R_FeePolicy> feePolicyRepository,
            R_LocationDomainService locationDomainService,
            IRepository<R_FeePolicyGroup> feePolicyGroupRepository,
            IRepositoryNonRoot<M_TaxVAT> taxRepository
        )
        {
            this.feePolicyRepository = feePolicyRepository;
            this.locationDomainService = locationDomainService;
            this.feePolicyGroupRepository = feePolicyGroupRepository;
            this.taxRepository = taxRepository;
        }

        public double GetFee(Guid driverId, string provinceOrCity) {
            //        loai chinh sach(theo nhom)      khu vuc nao            gia/km
            //                 binh thuong             tay nguyen              0.2               (20% phi tren tong so tien ca chuyen) nui cao, kho di    
            //                 binh thuong             tphcm                   0.1               (10% phi tren tong so tien ca chuyen) dong bang
            //                 ho ngheo                tphcm                   0.09              (9% phí tren tong so tien ca chuyen)  uu dai
            //                 thuong binh             tphcm                   0.08              (8% phí)

            // neu [ho ngheo + thuong binh] = tong tien - (0.09 + 0.08)*tong tien = ...
                        
            // a. find group by driverId
            R_FeePolicyGroup group = this.feePolicyGroupRepository.FindOne(new R_FeePolicyGroupGetByUserId(driverId), "Users");
            if (group == null) {
                throw new Exception("This driver is not set into FeePolicyGroup yet");
            }

            // b. find record of group policy
            R_FeePolicy policy = this.feePolicyRepository.FindOne(new R_FeePolicyGetCostSpec(provinceOrCity, group.Id));
            if (policy == null) {
                throw new Exception("The group of this driver is not set into FeePolicy yet");
            }

            return policy.Cost;

        }

        public double GetTax() 
        {
            M_TaxVAT tax = this.taxRepository.FindOne(new M_TaxVATGetLatestSpec());

            return tax.Cost;
        }

    }
}
