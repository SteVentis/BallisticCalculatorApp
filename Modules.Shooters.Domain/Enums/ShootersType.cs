using System.Text.Json.Serialization;

namespace Modules.Shooters.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShootersType
{
    Athlete,
    Military,
    LawEnforcement
}
