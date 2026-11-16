using ApplicationService.Dtos.ProductDtos;
using ApplicationService.Services;
using System.Globalization;
using View.FormMain;

namespace View.FormProduct
{
    public partial class ProductForm : Form
    {
        private readonly ProductApplicationService _productApplicationService;
        bool FlagEdit;
        PutProductDto OldProduct = new PutProductDto();
        public ProductForm()
        {
            InitializeComponent();
            _productApplicationService = new ProductApplicationService();
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.MultiSelect = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            FlagEdit = false;

        }



        #region [Buttons]

        #region [Refresh]
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = _productApplicationService.GetAll();
            dgvProduct.ClearSelection();
        }
        #endregion


        #region [Post]
        private void btnPost_Click(object sender, EventArgs e)
        {
            if (CheckInputs() == false) return;

            if (FlagEdit == false)
            {
                PostProductDto postProductDto = new PostProductDto()
                {
                    Code = int.Parse(txtProductCode.Text),
                    Title = txtProductTitle.Text,
                    UnitPrice = decimal.Parse(txtProductUnitPrice.Text, CultureInfo.InvariantCulture),
                    Quantity = int.Parse(textProductQuantity.Text)
                };
                _productApplicationService.Post(postProductDto);
                MessageBox.Show("The product is registered successfully!");
            }
            else
            {
                PutProductDto NewProduct = new PutProductDto()
                {
                    Id = OldProduct.Id,
                    Code = int.Parse(txtProductCode.Text),
                    Title = txtProductTitle.Text,
                    UnitPrice = decimal.Parse(txtProductUnitPrice.Text, CultureInfo.InvariantCulture),
                    Quantity = int.Parse(textProductQuantity.Text)
                };

                if (NewProduct.Code == OldProduct.Code && NewProduct.Title == OldProduct.Title &&
                    NewProduct.UnitPrice == OldProduct.UnitPrice && NewProduct.Quantity == OldProduct.Quantity)
                {
                    MessageBox.Show("Please change at least one field!");
                    return;
                }

                _productApplicationService.Put(NewProduct);
                FlagEdit = false;
                MessageBox.Show("The product is updated successfully!");
            }

            txtProductCode.Clear();
            txtProductTitle.Clear();
            txtProductUnitPrice.Clear();
            textProductQuantity.Clear();
            dgvProduct.DataSource = _productApplicationService.GetAll();
            dgvProduct.ClearSelection();
        }
        #endregion


        #region [Delete]
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvProduct.SelectedRows)
            {
                DeleteProductDto TempProduct = new DeleteProductDto();

                TempProduct.Id = Convert.ToInt32(Row.Cells["Id"].Value);

                _productApplicationService.Delete(TempProduct);
            }

            dgvProduct.DataSource = _productApplicationService.GetAll();
            dgvProduct.ClearSelection();
        }
        #endregion


        #region [Edit]
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FlagEdit = true;

            OldProduct.Id = Convert.ToInt32(dgvProduct.CurrentRow.Cells["Id"].Value);
            OldProduct.Code = Convert.ToInt32(dgvProduct.CurrentRow.Cells["Code"].Value);
            OldProduct.Title = dgvProduct.CurrentRow.Cells["Title"].Value.ToString();
            OldProduct.UnitPrice = Convert.ToDecimal(dgvProduct.CurrentRow.Cells["UnitPrice"].Value);
            OldProduct.Quantity = Convert.ToInt32(dgvProduct.CurrentRow.Cells["Quantity"].Value);

            txtProductCode.Text = OldProduct.Code.ToString();
            txtProductTitle.Text = OldProduct.Title;
            txtProductUnitPrice.Text = OldProduct.UnitPrice.ToString("0.##", CultureInfo.InvariantCulture);
            textProductQuantity.Text = OldProduct.Quantity.ToString();

        }
        #endregion


        #region [Back]
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm Form = new MainForm();

            Form.StartPosition = FormStartPosition.Manual;
            Form.Location = this.Location;
            Form.Size = this.Size;

            Form.Show();
            this.Hide();
        }
        #endregion

        #endregion



        #region [selectionChanged]
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0 & dgvProduct.SelectedRows.Count < 2) { btnEdit.Enabled = true; }
            else { btnEdit.Enabled = false; }
            if (dgvProduct.SelectedRows.Count >= 1) { btnDelete.Enabled = true; }
            else { btnDelete.Enabled = false; }
        }
        #endregion



        #region [CheckInputs]
        public bool CheckInputs()
        {
            if (!int.TryParse(txtProductCode.Text, out int code) || code <= 0)
            {
                MessageBox.Show("Please enter a product code greater than zero!");
                return false;
            }
            if (txtProductTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the product title!");
                return false;
            }
            if (!decimal.TryParse(txtProductUnitPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price) || price <= 0)
            {
                MessageBox.Show("Product unit price must be greater than zero!");
                return false;
            }
            if (!int.TryParse(textProductQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Product quantity must be greater than zero!");
                return false;
            }
            return true;
        }
        #endregion



        #region [KeyPress]
        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProductTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || char.IsDigit(e.KeyChar) || e.KeyChar == ' '))
            {
                e.Handled = true;
            }
        }

        private void textProductQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProductUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtProductUnitPrice.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
        #endregion
    }

}
