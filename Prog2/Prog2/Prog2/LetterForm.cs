using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog2
{
    public partial class LetterForm : Form
    {
        public const int MIN_ADDRESSES = 2; // Minimum number of addresses needed

        private List<Address> addressList; // List of addresses used to fill combo boxes

        // Precondition:    addresses.Count >= MIN_ADDRESSES
        // Postcondition:   The form's GUI is prepared for display
        public LetterForm(List<Address> addresses)
        {
            InitializeComponent();

            addressList = addresses;
        }

        internal int OriginAddressIndex
        {
            // Precondtion:     User has selected from originAddCbo
            // Postcondition:   The index of the selected origin address retrurned
            get
            {
                return originAddCbo.SelectedIndex;
            }

            // Precondition:   -1 <= value < addressList.Count
            // Postcondition:  The specified index is selected in originAddCbo
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    originAddCbo.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("OriginAddressIndex", value,
                        "Index must be valid");
            }
        }

        internal int DestinationAddressIndex
        {
            // Precondition:    User has selected from destAddCbo
            // Postcondition:   The index of the selected origin address returned
            get
            {
                return destAddCbo.SelectedIndex;
            }

            // Precondition:    -1 <= value < addressList.Count
            // Postcondition:   The speicifed index is selected in destAddCbo
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    destAddCbo.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("DestinationAddressIndex", value,
                        "Index must be valid");
            }
        }

        internal string FixedCostText
        {
            // Precondition:    None
            // Postcondition:   The text of form's fixed cost field is returned
            get
            {
                return fixedCostTxt.Text;
            }
            // Precondition:    None
            // Postcondition:   The text of form's fixed cost field is set to specified value
            set
            {
                fixedCostTxt.Text = value;
            }
        }

        // Precondition:    addressList.Count >= MIN_ADDRESSES
        // Postcondition:   The lsit of addresses is used to populate the
        //                  origin and destination address combo boxes

        private void LetterForm_Load(object sender, EventArgs e)
        {
            if (addressList.Count < MIN_ADDRESSES) // Violated precondition
            {
                MessageBox.Show("Need " + MIN_ADDRESSES + " addresses to create letter!", "Addresses Error");
                this.DialogResult = DialogResult.Abort; // Dismiss immediately
            }
            else
            {
                foreach (Address a in addressList)
                {
                    originAddCbo.Items.Add(a.Name);
                    destAddCbo.Items.Add(a.Name);
                }
            }
        }
        // Precondition:    Focus is shifting from fixedCostTxt
        // Postcondition:   If text is invalid, focus remains and error provider
        //                  highlights the field
        private void fixedCostTxt_Validating(object sender, CancelEventArgs e)
        {
            decimal costTxt;   // Cost of letter
            bool valid = true; // Is text valid

            if (!decimal.TryParse(fixedCostTxt.Text, out costTxt)) // Parse failed?
                valid = false;
            else if (costTxt < 0)
                valid = false;
        }


        // Precondition:    Focus shifting from one of the address combo boxes
        //                  sender is ComboBox
        // Postcondition:   If no address selected, focus remains and error provider
        //                  highlights the field
        private void addressCbo_Validating(object sender, CancelEventArgs e)
        {
            // Downcast to sender as Combobox, so make sure you obey precondition!
            ComboBox cbo = sender as ComboBox; // Cast sender as combo box

            if (cbo.SelectedIndex == -1) // -1 means no item selected
            {
                e.Cancel = true;
                errorProvider.SetError(cbo, "Must select an address");
            }
            else if (originAddCbo.SelectedIndex != -1 && destAddCbo.SelectedIndex == originAddCbo.SelectedIndex)
            {
                e.Cancel = true;
                errorProvider.SetError(cbo, "Must select different addresses");
            }

            // Precondition:    Validating of sender not cancelled, so data OK
            //                  sender is Control
            // Postcondition:   Error provider cleared and focus allowed to change
        }

        private void AllFields_Validated(Object sender, EventArgs e)
        {
            // Downcast to sender as Control, soi make sure you obey precondition!
            Control control = sender as Control; // Cast sender as Control
                                                 // Should always be a Control
            errorProvider.SetError(control, "");
        }

        // Precondition:  User pressed on cancelBtn
        // Postcondition: Form closes
        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }


        // Precondition:    User clickeed on okBTN
        // Postcondition:   If invalid field on dialog, keep form open and give first inv
        //                  field the focus, Else return OK and close form

        private void okBtn_Click(object sender, EventArgs e)
        {
            // Raise validating event for all enabled controls on form
            // If all pass, ValidateChildren() will be true
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

    }
}

