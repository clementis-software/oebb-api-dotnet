using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OebbDotNet.ResponseModels
{
    internal record Auth(
        [property: JsonPropertyName("accessToken")] string AccessToken,
		[property: JsonPropertyName("token")] TokenDetails Token,
		[property: JsonPropertyName("supportId")] string SupportId,
		[property: JsonPropertyName("cashId")] string CashId,
		[property: JsonPropertyName("orgUnit")] int OrgUnit,
		[property: JsonPropertyName("legacyUserMigrated")] bool LegacyUserMigrated,
		[property: JsonPropertyName("userId")] string UserId,
		[property: JsonPropertyName("personId")] string PersonId,
		[property: JsonPropertyName("customerId")] string CustomerId,
		[property: JsonPropertyName("realm")] string Realm,
		[property: JsonPropertyName("sessionId")] string SessionId,
		[property: JsonPropertyName("sessionTimeout")] int SessionTimeout,
		[property: JsonPropertyName("sessionVersion")] string SessionVersion,
		[property: JsonPropertyName("sessionCreatedAt")] DateTimeOffset SessionCreatedAt,
		[property: JsonPropertyName("xffxIP")] string XffxIP);

    internal record TokenDetails(
		[property: JsonPropertyName("accessToken")] string AccessToken,
		[property: JsonPropertyName("refreshToken")] string RefreshToken);
}
