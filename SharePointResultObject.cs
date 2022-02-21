using System;

namespace MHC.Function
{
    public  class SharePointResultObject 
    {
        public string SKU { get; set; }
        public string CardCode { get; set; }
        public int Atp { get; set; }
        public string AtpDate { get; set; }
        public string QuantityOnOrderDate { get; set; }
        public int QuantityOnOrder { get; set; }
        public string PartnerName { get; set; }
        public string DeliveryMode { get; set; }
        public string Warehouse { get; set; }
        public object Content { get; set; }
        public string Status { get; set; }
    }
}