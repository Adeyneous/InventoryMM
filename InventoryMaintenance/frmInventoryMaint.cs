namespace InventoryMaintenance
{

    public partial class frmInventoryMaint : Form
    {
        public frmInventoryMaint()
        {
            InitializeComponent();
        }

        public List<InventoryItem> items = null!;

        public void frmInventoryMaint_Load(object sender, EventArgs e)
        {
            items = InventoryDB.GetItems();
            FillItemListBox();
        }

        public void FillItemListBox()
        {
            lstItems.Items.Clear();
            foreach (InventoryItem item in items)
            {
                lstItems.Items.Add(item.GetDisplayText());
            }
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewItem newItemForm = new();
            InventoryItem item = newItemForm.GetNewItem();
            if (item != null)
            {
                items.Add(item);
                InventoryDB.SaveItems(items); // Pass the List<InventoryItem> to SaveItems
                FillItemListBox();
            }
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;

            if (i == -1)
            {
                MessageBox.Show("Please select an item to delete.", "No item selected");
            }
            else
            {
                InventoryItem item = items[i];

                string message = $"Are you sure you want to delete {item.Name}?"; // Use Name property
                DialogResult result =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    items.Remove(item);
                    InventoryDB.SaveItems(items); // Pass the List<InventoryItem> to SaveItems
                    FillItemListBox();
                }
            }
        }

        public void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}