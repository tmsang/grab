namespace tmsang.domain
{
    public class R_RequestCreatedEvent: DomainEvent
    {
        public R_Request Request { get; set; }

        public override void Flatten()
        {
            var name = "R_Request";

            this.Args.Add(name + " Id", Request.Id);
            this.Args.Add(name + " RequestDate", Request.RequestDateTime.ToString("dd-MMM-yyyy"));
            this.Args.Add(name + " From", Request.From.Address);
            this.Args.Add(name + " To", Request.To.Address);
            this.Args.Add(name + " Distance", Request.Distance.ToString());
            this.Args.Add(name + " Cost", Request.Cost.ToString());
        }
    }
}
