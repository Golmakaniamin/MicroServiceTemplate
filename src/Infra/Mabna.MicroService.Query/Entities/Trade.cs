using System;
using System.Collections.Generic;

namespace Mabna.MicroService.Query.Entities;

public partial class Trade
{
    public int? Id { get; set; }

    public int? InstrumentId { get; set; }

    public DateTime? DateEn { get; set; }

    public decimal? Open { get; set; }

    public decimal? High { get; set; }

    public decimal? Low { get; set; }

    public decimal? Close { get; set; }
}
