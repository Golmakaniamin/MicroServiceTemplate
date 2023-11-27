namespace Mabna.MicroService.Contract.Query.Instruments;

public class GetInstrumentsWithLastDateResult
{
    public int? Id { get; set; }
    public string? Name { get; set; } = null!;
    public DateTime? LastTrade { get; set; } = null!;
}