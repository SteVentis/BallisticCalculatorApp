namespace Modules.Security.Domain.Models;

public class EmailConfirmationModel
{
    public string EmailToken { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
}
