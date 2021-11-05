namespace tmsang.domain
{
    public class R_DriverChangePasswordEvent : DomainEvent
    {
        public R_Driver R_Driver { get; set; }

        public override void Flatten()
        {
            var name = "R_Driver";
            this.Args.Add(name + " Id", R_Driver.Id);
            this.Args.Add(name + " Password", R_Driver.Password);
        }
    }
}
