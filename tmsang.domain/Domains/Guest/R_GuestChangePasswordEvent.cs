namespace tmsang.domain
{
    public class R_GuestChangePasswordEvent : DomainEvent
    {
        public R_Guest R_Guest { get; set; }

        public override void Flatten()
        {
            var name = "R_Guest";
            this.Args.Add(name + " Id", R_Guest.Id);
            this.Args.Add(name + " Password", R_Guest.Password);
        }
    }
}
