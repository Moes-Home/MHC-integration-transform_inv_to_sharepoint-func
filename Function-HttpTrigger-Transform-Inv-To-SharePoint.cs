using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MHC.Function.SPS_Costco;
using System.Collections.Generic;

namespace MHC.Function
{
    public static class Function_HttpTrigger_Transform_Inv_To_SharePoint
    {
        [FunctionName("Function_HttpTrigger_Transform_Inv_To_SharePoint")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string id = "";
                string supplierId = "";
                string vendorPartNumber = "";
                string deliveryMode = "";


                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                InputObject inventoryInputObject = JsonConvert.DeserializeObject<InputObject>(requestBody);

                SharePointResultObject sharePointResultObject = new SharePointResultObject();

                if (inventoryInputObject.CardCode == "CUS002194")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS(LULU & GEORGIA INC)";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS002194-ATP")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS(LULU & GEORGIA INC)";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS002780")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_Rooms to Go";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS002780-ATP")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_Rooms to Go";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS002236")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_Macy's";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS003658")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_WilliamsSonoma";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS003658-ATP")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.id;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_WilliamsSonoma";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.id;
                }
                 else if (inventoryInputObject.CardCode == "CUS002317")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_McGee";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                 else if (inventoryInputObject.CardCode == "CUS002317-ATP")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_McGee";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS001607")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "Houzz";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS000389")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_BisonOffice";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CUS000389-ATP")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_BisonOffice";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                 else if (inventoryInputObject.CardCode == "CUS003941-ATP")
                {
                    LineItem lineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = lineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS_Target.com";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + lineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "CCAN000289")
                {
                    InventoryUpdate inventoryUpdate = JsonConvert.DeserializeObject<InventoryUpdate>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = inventoryUpdate.supplierPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = inventoryUpdate.quantityOnHand;
                    sharePointResultObject.AtpDate = inventoryUpdate.itemNextAvailabilityDate;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "Wayfair Canada";
                    sharePointResultObject.Warehouse = inventoryUpdate.supplierId;
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + inventoryUpdate.supplierPartNumber + "_" + inventoryUpdate.supplierId;
                }
                else if (inventoryInputObject.CardCode == "CUS003640")
                {
                    InventoryUpdate inventoryUpdate = JsonConvert.DeserializeObject<InventoryUpdate>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = inventoryUpdate.supplierPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = inventoryUpdate.quantityOnHand;
                    sharePointResultObject.QuantityOnOrder = inventoryUpdate.quantityOnOrder;
                    sharePointResultObject.QuantityOnOrderDate = inventoryUpdate.itemNextAvailabilityDate;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "Wayfair US";
                    sharePointResultObject.Warehouse = inventoryUpdate.supplierId;
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + inventoryUpdate.supplierPartNumber + "_" + inventoryUpdate.supplierId;
                }
                else if (inventoryInputObject.CardCode == "CCAN000289-ATP")
                {
                    InventoryUpdate inventoryUpdate = JsonConvert.DeserializeObject<InventoryUpdate>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = inventoryUpdate.supplierPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = inventoryUpdate.quantityOnHand;
                    sharePointResultObject.AtpDate = inventoryUpdate.itemNextAvailabilityDate;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "Wayfair Canada";
                    sharePointResultObject.Warehouse = inventoryUpdate.supplierId;
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + inventoryUpdate.supplierPartNumber + "_" + inventoryUpdate.supplierId;
                }
                else if (inventoryInputObject.CardCode == "CUS003640-ATP")
                {
                    InventoryUpdate inventoryUpdate = JsonConvert.DeserializeObject<InventoryUpdate>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = inventoryUpdate.supplierPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = inventoryUpdate.quantityOnHand;
                    sharePointResultObject.QuantityOnOrder = inventoryUpdate.quantityOnOrder;
                    sharePointResultObject.QuantityOnOrderDate = inventoryUpdate.itemNextAvailabilityDate;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "Wayfair US";
                    sharePointResultObject.Warehouse = inventoryUpdate.supplierId;
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + inventoryUpdate.supplierPartNumber + "_" + inventoryUpdate.supplierId;
                }
                else if (inventoryInputObject.CardCode == "CCAN000410")
                {
                    LineItem sps_CostcoLineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = sps_CostcoLineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS(COSTCO HOME)";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + sps_CostcoLineItem.InventoryLine.VendorPartNumber;
                } else if (inventoryInputObject.CardCode == "CCAN000410-ATP")
                {
                    LineItem sps_CostcoLineItem = JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = sps_CostcoLineItem.id;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.TotalQty ?? 0;
                    sharePointResultObject.AtpDate = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "33")?.Dates.Date;
                    sharePointResultObject.QuantityOnOrder = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.TotalQty ?? 0; ;
                    sharePointResultObject.QuantityOnOrderDate = sps_CostcoLineItem.QuantitiesSchedulesLocations.Find(x => x.QuantityQualifier == "29")?.Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS(COSTCO HOME)";
                    sharePointResultObject.Warehouse = "";
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = inventoryInputObject.CardCode + "_" + sps_CostcoLineItem.InventoryLine.VendorPartNumber;
                }
                else if (inventoryInputObject.CardCode == "MOES-ATP")
                {
                    MoesATP moesATP = JsonConvert.DeserializeObject<MoesATP>(inventoryInputObject.InventoryContent.ToString());
                    sharePointResultObject.SKU = moesATP.Sku;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = moesATP.Quantities[0].Quantity;
                    sharePointResultObject.AtpDate = moesATP.Quantities[0].date.ToString("yyyy-MM-dd HH:mm:ss");
                    if (moesATP.Quantities.Count >1)
                    {
                        sharePointResultObject.QuantityOnOrder = moesATP.Quantities[1].Quantity;
                        sharePointResultObject.QuantityOnOrderDate = moesATP.Quantities[1].date.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "MOES-ATP";
                    sharePointResultObject.Warehouse = moesATP.Warehouse;
                    sharePointResultObject.Content = inventoryInputObject.InventoryContent;
                    sharePointResultObject.Status = inventoryInputObject.status;
                    sharePointResultObject.FileName = moesATP.Warehouse + "_" + moesATP.Sku;
                }


                return new OkObjectResult(sharePointResultObject);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
