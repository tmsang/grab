﻿using System;

namespace tmsang.domain
{
    public class B_DriverBike : BaseEntity
    {
        public virtual int Id { get; protected set; }        
        public virtual string PlateNo { get; protected set; }           // EX: 59C1 22983
        public virtual string BikeOwner { get; protected set; }         // EX: SANG THACH MINH
        public virtual string EngineNo { get; protected set; }          // EX: 21655
        public virtual string ChassisNo { get; protected set; }         // EX: 7232-1
        public virtual string BikeType { get; protected set; }          // EX: Vison
        public virtual string Brand { get; protected set; }             // EX: Honda
        public virtual DateTime RegistrationDate { get; protected set; }

        // relationship R_Driver - B_DriverBike (by Fluent API)
        public virtual Guid AccountId { get; protected set; }
        public virtual R_Driver Driver { get; protected set; }        

        public static B_DriverBike Create(
            Guid AccountId, string plateNo, string bikeOwner, string engineNo, 
            string chassisNo, string bikeType, string brand, DateTime registrationDate)
        {
            var bike = new B_DriverBike
            {
                AccountId = AccountId,
                PlateNo = plateNo,
                BikeOwner = bikeOwner,
                EngineNo = engineNo,
                ChassisNo = chassisNo,
                BikeType = bikeType,
                Brand = brand,
                RegistrationDate = registrationDate
            };

            return bike;
        }

        public static B_DriverBike CreateForSeed(
            int Id,
            Guid AccountId, string plateNo, string bikeOwner, string engineNo,
            string chassisNo, string bikeType, string brand, DateTime registrationDate
        ) {
            var bike = Create(AccountId, plateNo, bikeOwner, engineNo,
                chassisNo, bikeType, brand, registrationDate);
            bike.Id = Id;

            return bike;
        }
    }
}
