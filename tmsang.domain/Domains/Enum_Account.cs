namespace tmsang.domain
{
    public enum E_AccountStatus
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

    public enum E_Mode 
    { 
        Remove = -2,
        Lock = -1,
        None = 0,
        Active = 1,
        Deactive = 2
    }

    public enum E_AccountType
    {
        Admin = 1,
        Driver = 2,
        Guest = 3
    }
}
