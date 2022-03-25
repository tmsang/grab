namespace tmsang.domain
{
    public enum E_AccountMode
    {
        Login = 1,
        ChangePassword = 2,
        ForgotPassword = 3,
        Register = 4,

        SetPolicy = 10,
        SetDriverFeePolicy = 11,
        SetTrustLevel = 12,
        SetBike = 13
    }

    public enum E_OrderStatus
    {
        Pending = 1,
        Accepted = 2,
        Started = 3,        
        Ended = 4,
        Evaluation = 5,

        CancelByUser = 10,
        CancelByDriver = 11,
        CancelByAdmin = 12,
        CancelBySystem = 13
    }

    public enum E_Status
    { 
        Hidden = -2,
        Locked = -1,
        None = 0,
        Actived = 1,
        Deactived = 2
    }

    public enum E_AccountType
    {
        Admin = 1,
        Driver = 2,
        Guest = 3
    }
}
