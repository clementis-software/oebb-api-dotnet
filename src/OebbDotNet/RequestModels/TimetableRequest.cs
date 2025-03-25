using OebbDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet.RequestModels
{
    internal class TimetableRequest
    {
        public string TravelActionId { get; set; }
        public DateTime DatetimeDeparture { get; set; }
        public TravelRequestFilter Filter { get; set; } = new TravelRequestFilter();
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
        public string EntryPointId { get; set; } = "timetable";
        public int Count { get; set; } = 5;
        public DebugFilter DebugFilter { get; set; } = new DebugFilter();
        public string SortType { get; set; } = "DEPARTURE";
        public Station From { get; set; }
        public Station To { get; set; }
    }

    public class TravelRequestFilter
    {
        public bool RegionalTrains { get; set; }
        public bool Direct { get; set; }
        public bool Wheelchair { get; set; }
        public bool Bikes { get; set; }
        public bool Trains { get; set; }
        public bool Motorail { get; set; }
        public List<object> Connections { get; set; } = new List<object>();
    }
}
