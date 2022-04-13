using System;

namespace tmsang.application
{
    public class BookDto
    {        
        public string FromLatitude { get; set; }
        public string FromLongtitude { get; set; }
        public string FromAddress { get; set; }

        public string ToLatitude { get; set; }
        public string ToLongtitude { get; set; }
        public string ToAddress { get; set; }

        public double Distance { get; set; }
        public double Amount { get; set; }

        public void EmptyValidation()
        {            
            if (string.IsNullOrEmpty(this.FromLatitude)) throw new Exception("From(latitude) is null or empty");
            if (string.IsNullOrEmpty(this.FromLongtitude)) throw new Exception("From(longtitude) is null or empty");
            if (string.IsNullOrEmpty(this.FromAddress)) throw new Exception("From(address) is null or empty");

            if (string.IsNullOrEmpty(this.ToLatitude)) throw new Exception("To(latitude) is null or empty");
            if (string.IsNullOrEmpty(this.ToLongtitude)) throw new Exception("To(longtitude) is null or empty");
            if (string.IsNullOrEmpty(this.ToAddress)) throw new Exception("To(address) is null or empty");

            if (Distance <= 0) throw new Exception("Distance is invalid");
            if (Amount <= 0) throw new Exception("Amount is invalid");
        }
    }
}
