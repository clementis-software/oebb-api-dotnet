using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet.RequestModels
{
    public class Passenger
    {
        public bool Me { get; set; } = false;
        public bool Remembered { get; set; } = false;
        public bool MarkedForDeath { get; set; } = false;
        public ChallengedFlags ChallengedFlags { get; set; } = new ChallengedFlags();
        public List<object> Cards { get; set; } = new List<object>();
        public List<object> Relations { get; set; } = new List<object>();
        public bool IsBirthdateChangeable { get; set; } = true;
        public bool IsBirthdateDeletable { get; set; } = true;
        public bool IsNameChangeable { get; set; } = true;
        public bool IsDeletable { get; set; } = true;
        public bool IsSelected { get; set; }
        public int Id { get; set; }
        public string Type { get; set; } = "ADULT";
        public bool BirthdateChangeable { get; set; }
        public bool BirthdateDeletable { get; set; }
        public bool NameChangeable { get; set; }
        public bool PassengerDeletable { get; set; }
    }

    public class ChallengedFlags
    {
        public bool HasHandicappedPass { get; set; }
        public bool HasAssistanceDog { get; set; }
        public bool HasWheelchair { get; set; }
        public bool HasAttendant { get; set; }
    }

    public class DebugFilter
    {
        public bool NoAggregationFilter { get; set; }
        public bool NoEqclassFilter { get; set; }
        public bool NoNrtpathFilter { get; set; }
        public bool NoPaymentFilter { get; set; }
        public bool UseTripartFilter { get; set; }
        public bool NoVbxFilter { get; set; }
        public bool NoCategoriesFilter { get; set; }
    }
}
