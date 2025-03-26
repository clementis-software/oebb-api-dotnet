# Austrian Railways (ÖBB) .NET API Client
.NET Client library for Austrian Railways (ÖBB) API: Search stations, connections, offers

## Example
The following example finds connections and offers from Wien Hbf. to L'viv (Львів).
```csharp
using var client = new OebbApiClient();

var from = (await client.QueryStationsAsync("Wien Hbf")).First();
var to = (await client.QueryStationsAsync("Lviv")).First();
var date = DateTime.Today;

var travelAction = await client.CreateTravelActionAsync(from, to, date);

var connections = await client.GetConnectionsAsync(travelAction, new List<RequestModels.Passenger>()
{
    new RequestModels.Passenger{ Id = 1742832923 }
}, 5);
```

Notes:
 - The usage of Passenger ID is not entirely clear. For this example I just took an ID that I've seen during my explorations on the ÖBB Ticket shop.
