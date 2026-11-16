using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using View.FormProduct;

namespace View.FormMain
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            PersonForm Form = new PersonForm();

            Form.StartPosition = FormStartPosition.Manual;
            Form.Location = this.Location;
            Form.Size = this.Size;

            Form.Show();
            this.Hide();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm Form = new ProductForm();

            Form.StartPosition = FormStartPosition.Manual;
            Form.Location = this.Location;
            Form.Size = this.Size;

            Form.Show();
            this.Hide();
        }
    }
}
