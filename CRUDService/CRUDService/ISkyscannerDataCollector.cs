using EasyBooking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRUDService
{
    [ServiceContract]
    public interface ISkyscannerDataCollector
    {

        [OperationContract]
        List<FlightS> GetFromSkyscanner(DateTime ArrivalDate, DateTime DepartureTime, string fromCity, string toCity, string userId);
    }
}
