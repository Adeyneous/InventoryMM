namespace InventoryMaintenance
{
    public static class InventoryDB
    {
        private const string Path = @"..\..\..\InventoryItems.txt";

        public static List<InventoryItem> GetItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            try
            {
                // Use using declarations to automatically close StreamReader
                using (StreamReader reader = new StreamReader(Path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into fields using the pipe character ('|') as a separator
                        string[] fields = line.Split('|');

                        if (fields.Length >= 3)
                        {
                            int id = int.Parse(fields[0]);
                            string name = fields[1];
                            decimal quantity = decimal.Parse(fields[2]); // Parse as decimal

                            InventoryItem item = new InventoryItem(id, name, quantity);
                            items.Add(item);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            }

            return items;
        }



        public static void SaveItems(List<InventoryItem> items)
        {
            try
            {
                // Create a StreamWriter with a FileStream for the InventoryItems.txt file
                using (FileStream fileStream = new FileStream(Path, FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    foreach (InventoryItem item in items)
                    {
                        // Convert each InventoryItem object to a string representation
                        string line = $"{item.Id}|{item.Name}|{item.Quantity}"; // Customize this based on your InventoryItem properties

                        // Write each line to the file
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine("Items saved successfully.");
            }
            catch (IOException ex)
            {
                // Handle any potential exceptions related to file I/O
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
        }
    }
}

