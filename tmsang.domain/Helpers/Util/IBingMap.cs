using BingMapsRESTToolkit;
using System.Threading.Tasks;

namespace tmsang.domain
{
    public interface IBingMap
    {
        Response GetLocationFromAddress(string address);
        Task<(double Distance, double Time)> GetDistanceMatrixAsync(string addressFrom, string addressTo);
        double GetDistanceByCoordinate(double lat1, double lon1, double lat2, double lon2);
    }
}
