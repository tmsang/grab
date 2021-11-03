namespace tmsang.domain
{
    public class R_AdminChangePasswordEvent : DomainEvent
    {
        public R_Admin R_Admin { get; set; }
        public override void Flatten()
        {
            var name = "R_Admin";
            this.Args.Add(name + " Id", R_Admin.Id);
            this.Args.Add(name + " Password", R_Admin.Password);
        }
    }
}
