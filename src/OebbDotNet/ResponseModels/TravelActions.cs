using OebbDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OebbDotNet.ResponseModels;

internal record TravelActionCollection(List<TravelAction> TravelActions);

public record TravelAction(
    string Id,
    bool IsRemovable,
    Entrypoint Entrypoint,
    string Type,
    Station From,
    Station To,
    List<Title> Title,
    bool IsAbroad,
    string VectorIcon,
    string VectorIconUrl,
    string IconType,
    string Icon,
    string IconUrl,
    string DisplayType,
    Subtitle Subtitle,
    string BackgroundColor,
    DateTime Date)
{
    [JsonIgnore]
    public DateTime Date { get; internal set; } = Date;
}

public record Entrypoint(
    string Id,
    bool RegistrationRequired,
    string ChooseConnection,
    string DateMandatory,
    int DefaultQuantity,
    string AgeStatement,
    bool PassengerMandatory,
    bool RelationMandatory,
    Title Title,
    DateTime ValidTo,
    Filter Filter,
    ErrorText ErrorText);

public record Title(
    string De,
    string En,
    string It);

public record Filter(
    List<object> Connections,
    bool Bikes,
    bool Motorail,
    bool Wheelchair,
    bool Regionaltrains,
    bool Direct,
    bool Trains);

public record ErrorText(
    Message Message,
    Title Title);

public record Message(string De);

public record Subtitle(
    string De,
    string En,
    string It);
