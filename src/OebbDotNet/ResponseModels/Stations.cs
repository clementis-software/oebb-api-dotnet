using OebbDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet.ResponseModels
{
    internal record StationCollection(List<Station> Stations);
}
