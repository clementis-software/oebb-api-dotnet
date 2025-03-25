using OebbApiClient;
using OebbDotNet.Models;
using OebbDotNet.RequestModels;
using OebbDotNet.ResponseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet
{
    public class OebbApiClient : IDisposable
    {
        private OebbDomainApiClient _domainApiClient = new OebbDomainApiClient();
        private OebbTicketingApiClient _ticketingApiClient = new OebbTicketingApiClient();

        private Auth _accessToken;
        private DateTime _accessTokenExpirationDate;

        public async Task<IEnumerable<Station>> QueryStationsAsync(string query, int maxResults = 10)
        {
            await EnsureAccessTokenIsSet();
            var result = await _ticketingApiClient.QueryStations(query, maxResults, _accessToken);
            return result;
        }

        public async Task<TravelAction?> CreateTravelActionAsync(Station from, Station to, DateTime dateTime)
        {
            await EnsureAccessTokenIsSet();

            var result = await _ticketingApiClient.CreateTravelAction(new TravelActionsRequest
            {
                From = from,
                To = to,
                Datetime = dateTime
            }, _accessToken);

            var travelAction = result.TravelActions.FirstOrDefault();

            if (travelAction != null)
                travelAction.Date = dateTime;

            return travelAction;
        }

        public async Task<IEnumerable<Connection>> GetConnectionsAsync(TravelAction travelAction, List<Passenger> passengers, int results)
        {
            TimetableRequest request = new TimetableRequest
            {
                TravelActionId = travelAction.Id,
                From = travelAction.From,
                To = travelAction.To,
                Count = results,
                DatetimeDeparture = travelAction.Date,
                Passengers = passengers
            };

            var result = await _ticketingApiClient.SearchConnections(request, _accessToken);
            return result.Connections;
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync(IEnumerable<Connection> connections)
        {
            await EnsureAccessTokenIsSet();
            var result = await _ticketingApiClient.GetOffers(connections, _accessToken);
            return result.Offers;
        }

        //public async Task<>

        private async Task EnsureAccessTokenIsSet()
        {
            if (_accessToken == null || _accessTokenExpirationDate <= DateTime.Now)
            {
                _accessToken = await _domainApiClient.GetAnonymousToken();

                if (_accessToken == null)
                    throw new Exception("Authorization failed");
                _accessTokenExpirationDate = DateTime.Now.AddSeconds(_accessToken.SessionTimeout);
            }
        }

        public void Dispose()
        {
            _domainApiClient.Dispose();
            _ticketingApiClient.Dispose();
        }
    }
}
