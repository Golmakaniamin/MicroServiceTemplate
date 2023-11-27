namespace Mabna.MicroService.Contract.Query.Instruments;

public interface IInstrumentQueryRepository
{
    Task<List<GetInstrumentsWithLastDateResult>> GetInstrumentsWithLastDateAsync(CancellationToken cancellationToken);
}
