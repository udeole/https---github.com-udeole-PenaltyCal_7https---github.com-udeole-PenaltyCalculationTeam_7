using System;
using System.Collections;
using System.Collections.Generic;

namespace PenaltyCal_7.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public short PlaceOfHoldingTechNumber { get; set; }

    public string Isin { get; set; } = null!;

    public int SecurityQuantity { get; set; }

    public string TransactionTypeCode { get; set; } = null!;

    public string InstructionTypeCode { get; set; } = null!;

    public string MatchingReference { get; set; } = null!;

    public DateOnly SettlementDate { get; set; }

    public decimal SettlementCashAmount { get; set; }

    public string CalendarId { get; set; } = null!;

    public string PartyId { get; set; } = null!;

    public string CounterPartyId { get; set; } = null!;

    public string PartyRoleCd { get; set; } = null!;

    public string CounterPartyRoleCd { get; set; } = null!;

    public string FailingPartyRoleCd { get; set; } = null!;

    public decimal PenaltyAmount { get; set; }

    public BitArray Sign { get; set; } = null!;

    public DateTime CntlTimestamp { get; set; }

    public string CntlUserid { get; set; } = null!;
}
