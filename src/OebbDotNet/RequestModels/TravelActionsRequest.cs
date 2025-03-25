using OebbDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OebbDotNet.RequestModels
{
    internal class TravelActionsRequest
    {
        public Station From { get; set; }
        public Station To { get; set; }
        public DateTime Datetime { get; set; }
        public List<object> CustomerVias { get; set; } = new List<object>();
        public List<string> TravelActionTypes { get; set; } = new List<string>() { "timetable" };
        public bool IgnoreHistory { get; set; } = true;
        public TravelActionsRequestFilter Filter { get; set; } = new TravelActionsRequestFilter();
    }

    public class TravelActionsRequestFilter
    {
        public List<string> ProductTypes { get; set; } = new List<string>();
        public bool History { get; set; } = true;
        public int MaxEntries { get; set; } = 5;
        public string Channel { get; set; } = "inet";
    }
}