using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Request: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }        

        public virtual R_Location From { get; protected set; }
        public virtual R_Location To { get; protected set; }

        public virtual double Distance { get; protected set; }
        public virtual double Cost { get; protected set; }

        public virtual DateTime RequestDateTime { get; protected set; }
        public virtual string Reason { get; protected set; }

        // relationship (1-n: n)        
        public virtual Guid GuestId { get; protected set; }
        public virtual R_Guest Guest { get; protected set; }

        // relationship (1-n: 1)
        public virtual IList<B_RequestHistory> Histories { get; protected set; }


        public static R_Request Create(Guid accountId, R_Location from, R_Location to, double routineCost)
        {
            return Create(Guid.NewGuid(), accountId, from, to, routineCost);
        }
        public static R_Request Create(Guid id, Guid accountId, R_Location from, R_Location to, double routineCost)
        {
            var distance = CalculateDistance(from, to);
            var cost = CalculateCost(distance, routineCost);

            var request = new R_Request
            {
                Id = id,
                From = from,
                To = to,
                Distance = distance,
                Cost = cost,

                RequestDateTime = DateTime.Now,                
                GuestId = accountId
            };

            // add event sourcing
            DomainEvents.Raise<R_RequestCreatedEvent>(new R_RequestCreatedEvent() { Request = request });

            return request;
        }

        public void AddHistories() {
            var history = B_RequestHistory.Create(this.Id, E_OrderStatus.Pending, DateTime.Now, "Create Request");

            this.Histories.Add(history);
        }

        private static double CalculateCost(double distance, double routineCost)
        {            
            return routineCost * distance;            
        }

        private static double CalculateDistance(R_Location from, R_Location to)
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" 
                + from.Address + "&destinations=" + to.Address
                + "&key=" + Singleton.Instance.GoogleApiKey;

            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    var OriginAddress = dsResult.Tables["DistanceMatrixResponse"].Rows[0]["origin_address"].ToString();
                    var DestinationAddress = dsResult.Tables["DistanceMatrixResponse"].Rows[0]["destination_address"].ToString();
                    var duration = dsResult.Tables["duration"].Rows[0]["text"].ToString();
                    var distance = dsResult.Tables["duration"].Rows[0]["value"].ToString() + dsResult.Tables["distance"].Rows[0]["text"].ToString();

                    double.TryParse(distance, out double result);

                    return result;
                }
            }
        }
    }
}
