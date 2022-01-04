
public class InventoryUpdate
{
    public string id {get; set;}
    public string supplierId { get; set; }
    public string supplierPartNumber { get; set; }
    public int quantityOnHand { get; set; }
    public string deliveryMode { get; set; }
     public int quantityOnOrder { get; set; }
    public string itemNextAvailabilityDate { get; set; }
}