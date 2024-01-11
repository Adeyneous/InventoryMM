namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        public frmNewItem()
        {
            InitializeComponent();
        }

        public InventoryItem item = null!;

        public InventoryItem GetNewItem()
        {
            this.ShowDialog();
            return item;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                item = new(
                    Convert.ToInt32(txtItemNo.Text),
                    txtDescription.Text,
                    Convert.ToDecimal(txtPrice.Text)
                );
                this.Close();
            }
        }

        public bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtItemNo.Text, "Item no");
            errorMessage += Validator.IsInt32(txtItemNo.Text, "Item no");
            errorMessage += Validator.IsPresent(txtDescription.Text, "Description");
            errorMessage += Validator.IsPresent(txtPrice.Text, "Price");
            errorMessage += Validator.IsDecimal(txtPrice.Text, "Price");

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        public void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void frmNewItem_Load(object sender, EventArgs e)
        {

        }
    }
}