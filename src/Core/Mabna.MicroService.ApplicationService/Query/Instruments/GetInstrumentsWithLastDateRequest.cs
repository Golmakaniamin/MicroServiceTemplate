using Mabna.MicroService.Contract.Query.Instruments;
using MediatR;

namespace Mabna.MicroService.ApplicationService.Query.Instruments
{
    public class GetInstrumentsWithLastDateRequest : IRequest<List<GetInstrumentsWithLastDateResult>>
    {
        internal class Handler : IRequestHandler<GetInstrumentsWithLastDateRequest, List<GetInstrumentsWithLastDateResult>>
        {
            private readonly IInstrumentQueryRepository _repository;

            public Handler(IInstrumentQueryRepository repository)
            {
                _repository = repository;
            }

            public Task<List<GetInstrumentsWithLastDateResult>> Handle(GetInstrumentsWithLastDateRequest request, CancellationToken cancellationToken)
            {
                return _repository.GetInstrumentsWithLastDateAsync(cancellationToken);
            }
        }
    }
}
