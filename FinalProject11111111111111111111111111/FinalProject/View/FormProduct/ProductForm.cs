using ApplicationService.Dtos.ProductDtos;
using ApplicationService.Services;
using System.Text.RegularExpressions;
using View.FormMain;

namespace View.FormProduct
{
    public partial class ProductForm : Form
    {
        private readonly ProductApplicationService _productApplicationService;
        private readonly MainForm _mainForm;

        // Edit mode (same idea as PersonForm): Edit loads the selected row, Save then updates it.
        private bool _isEditing;
        private int _editId;
        private int _oldCode;
        private string _oldTitle = string.Empty;
        private decimal _oldUnitPrice;
        private int _oldQuantity;

        public ProductForm(MainForm mainForm)
        {
            InitializeComponent();
            _productApplicationService = new ProductApplicationService();
            _mainForm = mainForm;

            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.MultiSelect = true;

            // Quantity: plain number box (no up/down arrows, no mouse-wheel or arrow-key changes).
            nudProductQuantity.Controls[0].Visible = false;
            nudProductQuantity.InterceptArrowKeys = false;
            nudProductQuantity.MouseWheel += (s, e) => ((HandledMouseEventArgs)e).Handled = true;

            btnPut.Enabled = false;
            btnDelete.Enabled = false;
            _isEditing = false;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load products from the database!\n" + ex.GetBaseException().Message);
            }
        }

        private void ProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Show();
        }

        #region [- Buttons -]

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        // Save: inserts a new product, or updates the product being edited.
        private void btnPost_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInputs(txtProductCode, txtProductTitle, txtProductUnitPrice, nudProductQuantity)) return;

            if (!_isEditing)
            {
                PostProductDto postProductDto = new PostProductDto()
                {
                    Code = int.Parse(txtProductCode.Text),
                    Title = txtProductTitle.Text,
                    UnitPrice = decimal.Parse(txtProductUnitPrice.Text),
                    Quantity = (int)nudProductQuantity.Value,
                };
                _productApplicationService.Post(postProductDto);

                RefreshData();
                ResetForm();

                MessageBox.Show(
                    $"The product is registered successfully!\n" +
                    $"Code: {postProductDto.Code}\n" +
                    $"Title: {postProductDto.Title}\n" +
                    $"UnitPrice: {postProductDto.UnitPrice:0.##}\n" +
                    $"Quantity: {postProductDto.Quantity}"
                    );
            }
            else
            {
                if (!HasChanges())
                {
                    MessageBox.Show("Please change at least one field!");
                    return;
                }

                PutProductDto putProductDto = new PutProductDto()
                {
                    Id = _editId,
                    Code = int.Parse(txtProductCode.Text),
                    Title = txtProductTitle.Text,
                    UnitPrice = decimal.Parse(txtProductUnitPrice.Text),
                    Quantity = (int)nudProductQuantity.Value,
                };
                _productApplicationService.Put(putProductDto);

                RefreshData();
                ResetForm();

                MessageBox.Show(
                    $"The product is updated successfully!\n" +
                    $"Code: {putProductDto.Code}\n" +
                    $"Title: {putProductDto.Title}\n" +
                    $"UnitPrice: {putProductDto.UnitPrice:0.##}\n" +
                    $"Quantity: {putProductDto.Quantity}"
                    );
            }
        }

        // Edit: loads the single selected row into the inputs.
        private void btnPut_Click(object sender, EventArgs e)
        {
            StartEdit();
        }

        // Delete: works for one or many selected rows.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count == 0) return;

            var ids = new List<int>();
            foreach (DataGridViewRow row in dgvProduct.SelectedRows)
            {
                ids.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }

            var confirm = MessageBox.Show(
                ids.Count == 1 ? "Delete the selected product?" : $"Delete {ids.Count} selected products?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            foreach (var id in ids)
            {
                _productApplicationService.Delete(new DeleteProductDto() { Id = id });
            }

            RefreshData();
            ResetForm();

            MessageBox.Show(ids.Count == 1
                ? "The product is deleted successfully!"
                : $"{ids.Count} products are deleted successfully!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region [- Grid Events -]

        // One selected row  -> Edit + Delete enabled.
        // Several rows      -> only Delete enabled.
        // No selection      -> both disabled.
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            int count = dgvProduct.SelectedRows.Count;

            btnPut.Enabled = count == 1;
            btnDelete.Enabled = count >= 1;

            // Selection changed while editing -> leave edit mode.
            if (_isEditing)
            {
                _isEditing = false;
                ClearInputs();
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProduct.SelectedRows.Count == 1)
            {
                StartEdit();
            }
        }

        private void dgvProduct_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dgvProduct.HitTest(e.X, e.Y);

            if (hit.RowIndex == -1)
            {
                dgvProduct.ClearSelection();
                ResetForm();
            }
        }

        #endregion

        #region [- Validation Helpers -]
        private static bool IsEmpty(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

        private static bool IsValidTitle(string title)
        {
            return Regex.IsMatch(title, @"^[a-zA-Z0-9 ]+$");
        }

        private static bool IsZero(NumericUpDown numericUpDown)
        {
            return numericUpDown.Value == 0;
        }

        private static bool IsValidCode(TextBox textBox)
        {
            return int.TryParse(textBox.Text, out int code) && code > 0;
        }

        private static bool IsValidPrice(TextBox textBox)
        {
            return decimal.TryParse(textBox.Text, out decimal price) && price > 0;
        }

        private static bool ValidateProductInputs(TextBox txtProductCode, TextBox txtProductTitle, TextBox txtProductUnitPrice, NumericUpDown nudProductQuantity)
        {
            if (IsEmpty(txtProductCode))
            {
                MessageBox.Show("Please enter the product code!");
                txtProductCode.Focus();
                return false;
            }

            if (!IsValidCode(txtProductCode))
            {
                MessageBox.Show("Product code must be a positive integer!");
                txtProductCode.Focus();
                return false;
            }

            if (IsEmpty(txtProductTitle))
            {
                MessageBox.Show("Please enter the product title!");
                txtProductTitle.Focus();
                return false;
            }

            if (!IsValidTitle(txtProductTitle.Text))
            {
                MessageBox.Show("Product title must contain only English letters, numbers, and spaces!");
                txtProductTitle.Focus();
                return false;
            }

            if (IsEmpty(txtProductUnitPrice))
            {
                MessageBox.Show("Please enter the product unit price!");
                txtProductUnitPrice.Focus();
                return false;
            }

            if (!IsValidPrice(txtProductUnitPrice))
            {
                MessageBox.Show("Product unit price must be greater than zero!");
                txtProductUnitPrice.Focus();
                return false;
            }

            if (IsZero(nudProductQuantity))
            {
                MessageBox.Show("Product quantity cannot be zero!");
                nudProductQuantity.Focus();
                return false;
            }

            return true;
        }

        private bool HasChanges()
        {
            return _oldCode != int.Parse(txtProductCode.Text) ||
                   _oldTitle != txtProductTitle.Text ||
                   _oldUnitPrice != decimal.Parse(txtProductUnitPrice.Text) ||
                   _oldQuantity != (int)nudProductQuantity.Value;
        }
        #endregion

        #region [- Form Helpers -]
        private void StartEdit()
        {
            if (dgvProduct.SelectedRows.Count != 1) return;

            var row = dgvProduct.SelectedRows[0];

            _editId = Convert.ToInt32(row.Cells["Id"].Value);
            _oldCode = Convert.ToInt32(row.Cells["Code"].Value);
            _oldTitle = row.Cells["Title"].Value?.ToString() ?? string.Empty;
            _oldUnitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
            _oldQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);

            txtProductCode.Text = _oldCode.ToString();
            txtProductTitle.Text = _oldTitle;
            txtProductUnitPrice.Text = _oldUnitPrice.ToString("0.##");
            nudProductQuantity.Value = _oldQuantity;

            _isEditing = true;
            txtProductCode.Focus();
        }

        private void ClearInputs()
        {
            txtProductCode.Clear();
            txtProductTitle.Clear();
            txtProductUnitPrice.Clear();
            nudProductQuantity.Value = 0;
        }

        private void ResetForm()
        {
            _isEditing = false;
            ClearInputs();
            dgvProduct.ClearSelection();
            btnPut.Enabled = false;
            btnDelete.Enabled = false;
            txtProductCode.Focus();
        }

        private void RefreshData()
        {
            dgvProduct.DataSource = _productApplicationService.GetAll();
            dgvProduct.Columns["UnitPrice"].DefaultCellStyle.Format = "0.##";
            dgvProduct.ClearSelection();
        }
        #endregion
    }
}
