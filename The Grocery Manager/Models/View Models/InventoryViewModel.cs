/// <summary>
/// Author: Sannan Ali
/// InventoryViewModel.cs - ViewModel for displaying and editing inventory in
/// the Inventory View.
/// </summary>
public class InventoryViewModel
{
    public string ItemName { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public DateTime LastUpdated { get; set; }
}