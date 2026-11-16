using ApplicationService.Dtos.PersonDtos;
using ApplicationService.Services;
using Model.DomainModels;
using System.CodeDom.Compiler;
using View.FormMain;

namespace View
{
    public partial class PersonForm : Form
    {
        private readonly PersonApplicationService _personApplicationService;
        bool FlagEdit;
        PutPersonDto OldPerson = new PutPersonDto();
        public PersonForm()
        {
            InitializeComponent();
            _personApplicationService = new PersonApplicationService();
            dgvPerson.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerson.MultiSelect = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            FlagEdit = false;

        }



        #region [Buttons]

        #region [Refresh]
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvPerson.DataSource = _personApplicationService.GetAll();
        }
        #endregion


        #region [Post]
        private void btnPost_Click(object sender, EventArgs e)
        {
            if (FlagEdit == false)
            {
                PostPersonDto postPersonDto = new PostPersonDto() { FirstName = txtFirstName.Text, LastName = txtLastName.Text };
                _personApplicationService.Post(postPersonDto);
                txtFirstName.Clear();
                txtLastName.Clear();
                //MessageBox.Show($"The person <{postPersonDto.FirstName} {postPersonDto.LastName}> has been registered successfully");
                dgvPerson.DataSource = _personApplicationService.GetAll();
            }
            else
            {
                PutPersonDto NewPerson = new PutPersonDto()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text
                };
                txtFirstName.Clear();
                txtLastName.Clear();


                _personApplicationService.Put(OldPerson, NewPerson);
            }
        }
        #endregion


        #region [Delete]
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<DeletePersonDto> ListOfDelete = new List<DeletePersonDto>();


            foreach (DataGridViewRow Row in dgvPerson.SelectedRows)
            {
                DeletePersonDto TempPerson = new DeletePersonDto();

                TempPerson.Id = Convert.ToInt32(Row.Cells["Id"].Value);

                ListOfDelete.Add(TempPerson);
            }


            _personApplicationService.Delete(ListOfDelete);
            dgvPerson.DataSource = _personApplicationService.GetAll();
        }
        #endregion


        #region [Edit]
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FlagEdit = true;

            OldPerson.Id = Convert.ToInt32(dgvPerson.CurrentRow.Cells["Id"].Value);
            OldPerson.FirstName = dgvPerson.CurrentRow.Cells["FirstName"].Value.ToString();
            OldPerson.LastName = dgvPerson.CurrentRow.Cells["LastName"].Value.ToString();

            txtFirstName.Text = OldPerson.FirstName;
            txtLastName.Text = OldPerson.LastName;

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
        private void dgvPerson_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPerson.SelectedRows.Count > 0 & dgvPerson.SelectedRows.Count < 2) { btnEdit.Enabled = true; }
            else { btnEdit.Enabled = false; }
            if (dgvPerson.SelectedRows.Count >= 1) { btnDelete.Enabled = true; }
            else { btnDelete.Enabled = false; }
        }
        #endregion




        #region {TextGaurd}
        public void TextGaurd(object sender, KeyPressEventArgs e)
        {

            if (!((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == ' '))
            {
                e.Handled = true;

                MessageBox.Show("فقط حروف انگلیسی مجاز هستند!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("لطفاً فقط حروف وارد کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        


        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextGaurd(sender, e);
        }


        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextGaurd(sender, e);
        }
        #endregion
    }

}

