
using System;
using System.Collections.Generic;

namespace MHC.Function
{
    public class LineItem
    {
        public string vendorPartNumber { get; set; }
        public string id { get; set; }
        public InventoryLine InventoryLine { get; set; }
        public ProductOrItemDescription ProductOrItemDescription { get; set; }
        public List<QuantitiesSchedulesLocations> QuantitiesSchedulesLocations { get; set; }
        
    }
}