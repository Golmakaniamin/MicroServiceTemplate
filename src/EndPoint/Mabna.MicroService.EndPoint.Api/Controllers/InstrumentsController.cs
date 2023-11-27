using Mabna.MicroService.ApplicationService.Query.Instruments;
using Mabna.MicroService.Contract.Query.Instruments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mabna.MicroService.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class InstrumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstrumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets Instruments With Last Date
        /// </summary>
        /// <returns></returns>
        [HttpGet("Instruments")]
        public async Task<List<GetInstrumentsWithLastDateResult>> GetInstrumentsWithLastDateAsync(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetInstrumentsWithLastDateRequest(), cancellationToken);
        }

    }
}