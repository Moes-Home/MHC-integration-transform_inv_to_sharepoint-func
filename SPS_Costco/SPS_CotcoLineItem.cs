using System;
using System.Collections.Generic;

namespace MHC.Function.SPS_Costco
{
    public class SPS_CostcoLineItem
    {
        public string vendorPartNumber { get; set; }
        public string id { get; set; }
        public SPS_CostcoInventoryline InventoryLine { get; set; }
        public SPS_CostcoProductOrItemDescription  ProductOrItemDescription { get; set; }
        public List<SPS_CostcoQuantitiesSchedulesLocations> QuantitiesSchedulesLocations { get; set; }
        
    }
}