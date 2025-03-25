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
            //HttpClient.DefaultRequestHeaders.Add("Host", "shop.oebbtickets.at");
        }

        public async Task<IEnumerable<Station>> QueryStations(string name, int count, Auth accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"hafas/v1/stations?name={name}&count={count}");
            request.Headers.Add("AccessToken", accessToken.AccessToken);
            request.Headers.Add("Host", "shop.oebbtickets.at");
            
            var response = await HttpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<IEnumerable<Station>>();
        }

        internal async Task<TravelActionCollection> CreateTravelAction(TravelActionsRequest travelActionsRequest, Auth apiToken)
        {
            return await PostAsync<TravelActionsRequest, TravelActionCollection>("offer/v2/travelActions", apiToken.AccessToken, travelActionsRequest);
        }

        internal async Task<OfferCollection> GetOffers(IEnumerable<Connection> connections, Auth accessToken)
        {
            string url = "offer/v1/prices?" + connections.Select(x => "connectionIds[]="+x.Id).Aggregate((s1, s2) => s1 + "&" + s2) + "&sortType=DEPARTURE&bestPriceId=undefined";

            return await GetAsync<OfferCollection>(url, accessToken.AccessToken);
        }

        internal async Task<ConnectionCollection> SearchConnections(TimetableRequest request, Auth apiToken)
        {
            return await PostAsync<TimetableRequest, ConnectionCollection>("hafas/v4/timetable", apiToken.AccessToken, request);
        }
    }
}
