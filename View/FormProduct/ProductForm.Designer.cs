namespace View.FormProduct
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPost = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnBack = new Button();
            lblProductCode = new Label();
            lblProductTitle = new Label();
            lblProductUnitPrice = new Label();
            lblProductQuantity = new Label();
            txtProductCode = new TextBox();
            txtProductTitle = new TextBox();
            txtProductUnitPrice = new TextBox();
            dgvProduct = new DataGridView();
            textProductQuantity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // btnPost
            // 
            btnPost.BackColor = SystemColors.ActiveCaption;
            btnPost.Font = new Font("Segoe UI", 11F);
            btnPost.Location = new Point(490, 12);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(94, 55);
            btnPost.TabIndex = 0;
            btnPost.Text = "Save";
            btnPost.UseVisualStyleBackColor = false;
            btnPost.Click += btnPost_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ActiveCaption;
            btnEdit.Font = new Font("Segoe UI", 11F);
            btnEdit.Location = new Point(490, 73);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 55);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ActiveCaption;
            btnDelete.Font = new Font("Segoe UI", 11F);
            btnDelete.Location = new Point(490, 134);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 55);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ActiveCaption;
            btnRefresh.Font = new Font("Segoe UI", 11F);
            btnRefresh.Location = new Point(490, 195);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 55);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ActiveCaption;
            btnBack.Font = new Font("Segoe UI", 11F);
            btnBack.Location = new Point(490, 256);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 55);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(18, 15);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(51, 20);
            lblProductCode.TabIndex = 5;
            lblProductCode.Text = "Code :";
            // 
            // lblProductTitle
            // 
            lblProductTitle.AutoSize = true;
            lblProductTitle.Location = new Point(18, 47);
            lblProductTitle.Name = "lblProductTitle";
            lblProductTitle.Size = new Size(45, 20);
            lblProductTitle.TabIndex = 6;
            lblProductTitle.Text = "Title :";
            // 
            // lblProductUnitPrice
            // 
            lblProductUnitPrice.AutoSize = true;
            lblProductUnitPrice.Location = new Point(18, 79);
            lblProductUnitPrice.Name = "lblProductUnitPrice";
            lblProductUnitPrice.Size = new Size(79, 20);
            lblProductUnitPrice.TabIndex = 7;
            lblProductUnitPrice.Text = "Unit Price :";
            // 
            // lblProductQuantity
            // 
            lblProductQuantity.AutoSize = true;
            lblProductQuantity.Location = new Point(18, 111);
            lblProductQuantity.Name = "lblProductQuantity";
            lblProductQuantity.Size = new Size(72, 20);
            lblProductQuantity.TabIndex = 8;
            lblProductQuantity.Text = "Quantity :";
            // 
            // txtProductCode
            // 
            txtProductCode.BackColor = SystemColors.ScrollBar;
            txtProductCode.Location = new Point(110, 12);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(362, 27);
            txtProductCode.TabIndex = 9;
            txtProductCode.KeyPress += txtProductCode_KeyPress;
            // 
            // txtProductTitle
            // 
            txtProductTitle.BackColor = SystemColors.ScrollBar;
            txtProductTitle.Location = new Point(110, 44);
            txtProductTitle.Name = "txtProductTitle";
            txtProductTitle.Size = new Size(362, 27);
            txtProductTitle.TabIndex = 10;
            txtProductTitle.KeyPress += txtProductTitle_KeyPress;
            // 
            // txtProductUnitPrice
            // 
            txtProductUnitPrice.BackColor = SystemColors.ScrollBar;
            txtProductUnitPrice.Location = new Point(110, 76);
            txtProductUnitPrice.Name = "txtProductUnitPrice";
            txtProductUnitPrice.Size = new Size(362, 27);
            txtProductUnitPrice.TabIndex = 11;
            txtProductUnitPrice.KeyPress += txtProductUnitPrice_KeyPress;
            // 
            // dgvProduct
            // 
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.AllowUserToDeleteRows = false;
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.BackgroundColor = SystemColors.ActiveCaption;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Location = new Point(18, 148);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.ReadOnly = true;
            dgvProduct.RowHeadersWidth = 51;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.Size = new Size(454, 170);
            dgvProduct.TabIndex = 13;
            dgvProduct.SelectionChanged += dgvProduct_SelectionChanged;
            // 
            // textProductQuantity
            // 
            textProductQuantity.BackColor = SystemColors.ScrollBar;
            textProductQuantity.Location = new Point(110, 111);
            textProductQuantity.Name = "textProductQuantity";
            textProductQuantity.Size = new Size(362, 27);
            textProductQuantity.TabIndex = 14;
            textProductQuantity.KeyPress += textProductQuantity_KeyPress;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(596, 330);
            Controls.Add(textProductQuantity);
            Controls.Add(dgvProduct);
            Controls.Add(txtProductUnitPrice);
            Controls.Add(txtProductTitle);
            Controls.Add(txtProductCode);
            Controls.Add(lblProductQuantity);
            Controls.Add(lblProductUnitPrice);
            Controls.Add(lblProductTitle);
            Controls.Add(lblProductCode);
            Controls.Add(btnBack);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnPost);
            Name = "ProductForm";
            Text = "Product";
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPost;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnBack;
        private Label lblProductCode;
        private Label lblProductTitle;
        private Label lblProductUnitPrice;
        private Label lblProductQuantity;
        private TextBox txtProductCode;
        private TextBox txtProductTitle;
        private TextBox txtProductUnitPrice;
        private DataGridView dgvProduct;
        private TextBox textProductQuantity;
    }
}
