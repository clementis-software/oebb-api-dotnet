using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet.RequestModels
{
    public class Selection
    {
        public string ConnectionId { get; set; }
        public List<object> Extras { get; set; }
        public List<object> CityTickets { get; set; }
        public List<object> TouristExtras { get; set; }
        public List<object> IntermodalExtras { get; set; }
    }

    public class OfferDetailsRequest
    {
        public Selection Selection { get; set; }
        public List<Passenger> Passengers { get; set; }
        public DebugFilter DebugFilter { get; set; }
        public DateTime Datetime { get; set; }
    }
}
