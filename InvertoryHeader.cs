using System;
using System.Collections.Generic;

public class InvertoryHeader {
    public string Country { get; set; }
    public string DeliveryMode { get; set; }
    public Guid Id { get; set; }
    public string ItemCode { get; set; }
    public List<Po> pos { get; set; }

    public string WhsCode { get; set; }
    public DateTime TimeStamp { get; set; }

}