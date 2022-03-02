using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Request: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }        

        // NOT: set relatioship to Location
        public virtual Guid FromLocationId { get; protected set; }
        public virtual Guid ToLocationId { get; protected set; }

        public virtual double Distance { get; protected set; }
        public virtual double Cost { get; protected set; }

        public virtual DateTime RequestDateTime { get; protected set; }
        public virtual string Reason { get; protected set; }

        // YES: relationship child
        public virtual Guid GuestId { get; protected set; }
        public virtual R_Guest Guest { get; protected set; }

        // YES: set relationship to Histories (1-n: 1)
        public virtual IList<B_RequestHistory> Histories { get; protected set; }


        // ===========================================================
        // METHODS
        // ===========================================================
        public static async Task<R_Request> CreateAsync(Guid orderId, Guid guestId, R_Location from, R_Location to, double distance, double amount, IBingMap bingMap)
        {
            //var distance = await CalculateDistanceAsync(from, to, bingMap);
            //var cost = CalculateCost(distance, routineCost);

            var request = new R_Request
            {
                Id = orderId,
                GuestId = guestId,
                FromLocationId = from.Id,
                ToLocationId = to.Id,
                Distance = distance,
                Cost = amount,

                RequestDateTime = DateTime.Now
            };

            // add event sourcing
            DomainEvents.Raise<R_RequestCreatedEvent>(new R_RequestCreatedEvent() { Request = request });

            return request;
        }

        public void AddHistories(E_OrderStatus status, string description) {
            var history = B_RequestHistory.Create(this.Id, status, DateTime.Now, description);

            if (this.Histories == null) this.Histories = new List<B_RequestHistory>();

            this.Histories.Add(history);
        }

        public void UpdateReason(string reason) {
            this.Reason = reason;
        }


        private static double CalculateCost(double distance, double routineCost)
        {            
            return routineCost * distance;            
        }

        private static async Task<double> CalculateDistanceAsync(R_Location from, R_Location to, IBingMap bingMap)
        {
            /*
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
                    var distance = dsResult.Tables["distance"].Rows[0]["text"].ToString();

                    double.TryParse(distance.Replace(" km", ""), out double result);

                    return result;
                }
            }
            */

            var distanceMatrix = await bingMap.GetDistanceMatrixAsync(from.Address, to.Address);
            return distanceMatrix.Distance;
        }
    }
}
