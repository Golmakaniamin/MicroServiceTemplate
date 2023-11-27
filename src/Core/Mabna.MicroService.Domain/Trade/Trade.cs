namespace Mabna.MicroService.Domain.Trade;

public class Trade
{
    public Trade(int id, int instrumentId, DateTime dateEn, decimal open, decimal high, decimal low, decimal close)
    {
        Id = id;
        InstrumentId = instrumentId;
        DateEn = dateEn;
        Open = open;
        High = high;
        Low = low;
        Close = close;
    }

    public int Id { get; private set; }
    public int InstrumentId { get; private set; }
    public DateTime DateEn { get; private set; }
    public decimal Open { get; private set; }
    public decimal High { get; private set; }
    public decimal Low { get; private set; }
    public decimal Close { get; private set; }

}
