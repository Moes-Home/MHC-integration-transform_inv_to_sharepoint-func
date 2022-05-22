using System;
using System.Collections.Generic;
public class MoesATP
{
    public Guid Id { get; set; }
    public string Sku { get; set; }
    public string Warehouse { get; set; }
    public DateTime TimeStamp { get; set; }
    public List<ItemQuantity> Quantities { get; set; }
}