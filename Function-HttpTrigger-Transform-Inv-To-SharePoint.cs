using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

                if(inventoryInputObject.CardCode =="CUS002194")
                {
                    LineItem lineItem =  JsonConvert.DeserializeObject<LineItem>(inventoryInputObject.InventoryContent);
                    sharePointResultObject.SKU= lineItem.InventoryLine.VendorPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = lineItem.QuantitiesSchedulesLocations[0].TotalQty;
                    sharePointResultObject.AtpDate = lineItem.QuantitiesSchedulesLocations[0].Dates.Date;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "SPS(LULU & GEORGIA INC)";
                    sharePointResultObject.Warehouse = "";
                }
                else if(inventoryInputObject.CardCode =="CCAN000289")
                {
                    InventoryUpdate inventoryUpdate =  JsonConvert.DeserializeObject<InventoryUpdate>(inventoryInputObject.InventoryContent);
                    sharePointResultObject.SKU = inventoryUpdate.supplierPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = inventoryUpdate.quantityOnHand;
                    sharePointResultObject.AtpDate = inventoryUpdate.itemNextAvailabilityDate;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "Wayfair Canada";
                    sharePointResultObject.Warehouse = inventoryUpdate.supplierId;
                }
                else if(inventoryInputObject.CardCode =="CUS003640")
                {
                    InventoryUpdate inventoryUpdate =  JsonConvert.DeserializeObject<InventoryUpdate>(inventoryInputObject.InventoryContent);
                    sharePointResultObject.SKU = inventoryUpdate.supplierPartNumber;
                    sharePointResultObject.CardCode = inventoryInputObject.CardCode;
                    sharePointResultObject.Atp = inventoryUpdate.quantityOnHand;
                    sharePointResultObject.QuantityOnOrder = inventoryUpdate.quantityOnOrder;
                    sharePointResultObject.QuantityOnOrderDate = inventoryUpdate.itemNextAvailabilityDate;
                    sharePointResultObject.DeliveryMode = inventoryInputObject.DeliveryMode;
                    sharePointResultObject.PartnerName = "Wayfair US";
                    sharePointResultObject.Warehouse = inventoryUpdate.supplierId;
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
