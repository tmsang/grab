using System;

namespace tmsang.application
{
    public class EvaluableDto
    {
        public string RequestId { get; set; }
        public int Rating { get; set; }
        public string Note { get; set; }

        public void EmptyValidation()
        {
            if (string.IsNullOrEmpty(this.Note)) throw new Exception("Note is null or empty");                                                            
        }
    }
}
