public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Quantity { get; set; } // Change the data type to decimal

    public InventoryItem(int id, string name, decimal quantity) // Update the parameter data type
    {
        Id = id;
        Name = name;
        Quantity = quantity; // Assign the quantity argument to the Quantity property
    }

    public string GetDisplayText()
    {
        return $"{Id}: {Name} (Quantity: {Quantity})";
    }
}
