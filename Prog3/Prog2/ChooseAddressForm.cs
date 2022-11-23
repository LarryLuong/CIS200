using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog2
{
    public partial class ChooseAddressForm : Form
    {
        private List<Address> addressesList;
        public ChooseAddressForm(List<Address> addresses)
        {
            InitializeComponent();
            addressesList = addresses;
        }

        public int AddressIndex
        {
            get
            {
                return comboBox1.SelectedIndex;
            }
            set
            {
                if
                    ((value >= -1) && (value < addressesList.Count))
                    comboBox1.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("AddressIndex", value, "Invalid Index");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void combobox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
        }

        private void combobox_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox1, "Select an Address");
            }
        }

        private void ChooseAddressForm_Load(object sender, EventArgs e)
        {
            foreach (Address a in addressesList)
            {
                comboBox1.Items.Add(a.Name);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
