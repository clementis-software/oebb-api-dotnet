using OebbDotNet;
using OebbDotNet.Models;
using OebbDotNet.RequestModels;
using OebbDotNet.ResponseModels;
using System.Net.Http.Json;

namespace OebbApiClient
{
    internal class OebbTicketingApiClient : ApiClientBase
    {
        public OebbTicketingApiClient() : base("https://shop.oebbtickets.at/api/")
        {
        }

        public async Task<IEnumerable<Station>> QueryStations(string name, int count, Auth accessToken)
        {
            return await GetAsync<IEnumerable<Station>>($"hafas/v1/stations?name={name}&count={count}", accessToken.AccessToken);
        }

        internal async Task<TravelActionCollection> CreateTravelAction(TravelActionsRequest travelActionsRequest, Auth apiToken)
        {
            return await PostAsync<TravelActionsRequest, TravelActionCollection>("offer/v2/travelActions", apiToken.AccessToken, travelActionsRequest);
        }

        internal async Task<OfferCollection> GetOffers(IEnumerable<Connection> connections, Auth accessToken)
        {
            if (!connections.Any())
                return new OfferCollection(new List<Offer>());

            var connectionIds = connections.Select(x => "connectionIds[]=" + x.Id);
            string connectionIdsString = connectionIds.Count() == 1 ? connectionIds.First() : connectionIds.Aggregate((s1, s2) => s1 + "&" + s2);

            string url = $"offer/v1/prices?{connectionIdsString}&sortType=DEPARTURE&bestPriceId=undefined";

            return await GetAsync<OfferCollection>(url, accessToken.AccessToken);
        }

        internal async Task<ConnectionCollection> SearchConnections(TimetableRequest request, Auth apiToken)
        {
            return await PostAsync<TimetableRequest, ConnectionCollection>("hafas/v4/timetable", apiToken.AccessToken, request);
        }
    }
}
