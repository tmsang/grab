namespace tmsang.domain
{
    public class R_RequestsOfGuestEvent : DomainEvent
    {
        public R_Request Request { get; set; }

        public override void Flatten()
        {
            var name = "R_Request";
            this.Args.Add(name + " Id", this.Request.Id);
            this.Args.Add(name + " From", this.Request.From.Address);
            this.Args.Add(name + " To", this.Request.To.Address);
            this.Args.Add(name + " Distance", this.Request.Distance);
            this.Args.Add(name + " Cost", this.Request.Cost);
            this.Args.Add(name + " RequestDate", this.Request.RequestDateTime);
            this.Args.Add(name + " Reason", this.Request.Reason);
        }
    }
}
