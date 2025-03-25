using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet.Models
{
    public record Station(int Number, string Name, int Latitude, int Longitude);
}
