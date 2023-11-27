using Mabna.MicroService.Contract.Query.Instruments;
using Mabna.MicroService.Query.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Mabna.MicroService.Query.Repositories
{
    public class InstrumentQueryRepository : IInstrumentQueryRepository
    {
        private readonly MersaairCrowdfindingTestContext _dbContext;

        public InstrumentQueryRepository(MersaairCrowdfindingTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetInstrumentsWithLastDateResult>> GetInstrumentsWithLastDateAsync(CancellationToken cancellationToken)
        {
            //var result = _dbContext.Instruments.FromSql($"SELECT [Id] ,[Name] ,(SELECT TOP 1 trade.[DateEn] FROM [mersaair_crowdfindingTest].[mersaair_crowdfundingTest].[Trade] AS trade WHERE trade.[InstrumentId] = instrument.[ID] ORDER BY trade.[DateEn] DESC) AS LastTrade FROM [mersaair_crowdfindingTest].[mersaair_crowdfundingTest].[Instrument] As instrument").ToList();\

            var result = await (from i in _dbContext.Instruments
                          join tr in _dbContext.Trades
                          on i.Id equals tr.InstrumentId
                          select new GetInstrumentsWithLastDateResult()
                          {
                              Id = i.Id,
                              Name = i.Name,
                              LastTrade = tr.DateEn
                          })
                          .GroupBy(i => new { i.Id, i.Name})
                          .Select(i => new GetInstrumentsWithLastDateResult() { Id = i.Key.Id , Name = i.Key.Name, LastTrade = i.Max(y => y.LastTrade) })
                          .ToListAsync();

            return result;
            //throw new NotImplementedException();
        }
    }
}
