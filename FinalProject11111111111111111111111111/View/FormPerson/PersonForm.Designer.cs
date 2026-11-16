namespace View
{
    partial class PersonForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnPost = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            lblFirstName = new Label();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            dgvPerson = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPerson).BeginInit();
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
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ActiveCaption;
            btnDelete.Font = new Font("Segoe UI", 11F);
            btnDelete.Location = new Point(490, 73);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 55);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ActiveCaption;
            btnEdit.Font = new Font("Segoe UI", 11F);
            btnEdit.Location = new Point(490, 134);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 55);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ActiveCaption;
            btnBack.Font = new Font("Segoe UI", 11F);
            btnBack.Location = new Point(490, 256);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 55);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ActiveCaption;
            btnRefresh.Font = new Font("Segoe UI", 11F);
            btnRefresh.Location = new Point(490, 195);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 55);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.ForeColor = SystemColors.ActiveCaptionText;
            lblFirstName.Location = new Point(18, 28);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(82, 20);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "Fist Name :";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(18, 69);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(90, 20);
            lblLastName.TabIndex = 6;
            lblLastName.Text = "Last Name : ";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = SystemColors.ScrollBar;
            txtFirstName.Location = new Point(105, 25);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(367, 27);
            txtFirstName.TabIndex = 7;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = SystemColors.ScrollBar;
            txtLastName.ForeColor = SystemColors.InfoText;
            txtLastName.Location = new Point(105, 66);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(367, 27);
            txtLastName.TabIndex = 8;
            txtLastName.KeyPress += txtLastName_KeyPress;
            // 
            // dgvPerson
            // 
            dgvPerson.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.MenuText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPerson.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.MenuText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPerson.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPerson.EnableHeadersVisualStyles = false;
            dgvPerson.GridColor = SystemColors.GradientActiveCaption;
            dgvPerson.Location = new Point(18, 111);
            dgvPerson.Name = "dgvPerson";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.MenuText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPerson.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPerson.RowHeadersWidth = 51;
            dgvPerson.Size = new Size(454, 207);
            dgvPerson.TabIndex = 0;
            dgvPerson.SelectionChanged += dgvPerson_SelectionChanged;
            // 
            // PersonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(596, 330);
            Controls.Add(dgvPerson);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnPost);
            ForeColor = SystemColors.MenuText;
            Name = "PersonForm";
            Text = "Person";
            TransparencyKey = Color.White;
            ((System.ComponentModel.ISupportInitialize)dgvPerson).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPost;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnBack;
        private Button btnRefresh;
        private Label lblFirstName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DataGridView dgvPerson;
    }
}
