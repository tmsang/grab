using System;

namespace tmsang.application
{
    public class EvaluableDto
    {
        public string OrderId { get; set; }
        public int Rating { get; set; }
        public string Remark { get; set; }

        public void EmptyValidation()
        {
            if (string.IsNullOrEmpty(this.Remark)) throw new Exception("Note is null or empty");                                                            
        }
    }
}
