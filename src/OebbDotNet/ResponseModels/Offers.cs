using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet.ResponseModels
{
    internal record OfferCollection(List<Offer> Offers);

    public record Offer(
        string ConnectionId,
        List<Warning> Warnings,
        decimal? Price,
        List<ReducedScope> ReducedScope,
        SpecialNote SpecialNote,
        bool OfferError,
        bool FirstClass,
        string AvailabilityState);

    public record Location(string Name, int SectionIdx);

    public record ReducedScope(Location From, Location To);

    public record SpecialNote(string De, string En, string It);

    public record Warning(int SectionIdx, string Status);
}
