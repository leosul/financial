namespace Financial.Services.Core.DomainObjects;

public class AppSettings
{
    public string Secret { get; set; }
    public int ExpirationsHours { get; set; }
    public string Emission { get; set; }
    public string Validate { get; set; }
}
