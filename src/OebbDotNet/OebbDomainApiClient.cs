using OebbDotNet.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OebbDotNet
{
    internal class OebbDomainApiClient : ApiClientBase
    {
        public OebbDomainApiClient() : base("https://tickets.oebb.at/api/domain/v3/")
        {
        }

        internal async Task<Auth?> GetAnonymousToken()
        {
            return await HttpClient.GetFromJsonAsync<Auth>("init");
        }
    }
}
