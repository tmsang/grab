namespace tmsang.application
{
    // Tinh hinh bao cao thong ke
    public class StatisticDto
    {
        public double Price { get; set; }
        public int CancelCounter { get; set; }
        public int DoneCounter { get; set; }
        public double TotalAmount { get; set; }

        public int NewCounter { get; set; }
        public int ProcessingCounter { get; set; }
        public double TotalRequests { get; set; }
    }
}
