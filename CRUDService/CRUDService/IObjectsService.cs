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
    public interface IRyanairDataCollector
    {

        [OperationContract]
        List<FlightS> GetFromRyanair(DateTime ArrivalDate, string fromCity, string toCity, string userId);
    }
}
