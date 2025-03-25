using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OebbDotNet.ResponseModels
{
    internal record ConnectionCollection(List<Connection> Connections);

    public record Connection(
        string Id,
        ConnectionStation From,
        ConnectionStation To,
        List<Section> Sections,
        int Switches,
        long Duration,
        List<Info> Infos);

    public record ConnectionStation(
        string Name,
        [property: JsonPropertyName("esn")] int StationNumber,
        DateTime? Departure,
        DateTime? Arrival,
        string DeparturePlatform,
        string ArrivalPlatform,
        bool ShowAsResolvedMetaStation);

    public record Section(
        ConnectionStation From,
        ConnectionStation To,
        long Duration,
        Category Category,
        string Type,
        bool HasRealtime);

    public record Category(
        string Name,
        string Number,
        string Direction,
        string ShortName,
        string DisplayName,
        Dictionary<string, string> LongName,
        string BackgroundColor,
        string FontColor,
        string BarColor,
        Dictionary<string, string> Place);

    public record Info(
        string Category,
        string ValidFrom,
        string ValidTo,
        string Header,
        string Text,
        string TextPlain,
        string Type,
        int SectionIdx,
        bool Emergency);
}
