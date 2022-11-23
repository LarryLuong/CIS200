// Program 3
// CIS 200-75
// Fall 2022
// Due: 11/23/2022
// By: Larry Nguyen 5317169

using Prog2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.CodeDom.Compiler;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv; // The UserParcelView

        // Precondition:    None
        // Postcondition:   The form's GUI is prepared for display. A few test addresses are
        //                  added to the lsit of addresses
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();

            // Test Data - Magic Numbers OK

        }

        // Precondition: File, about menu item activiated
        // Postcondition: Information about author displayed in dialog box

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine;

            MessageBox.Show($"Program 3{NL}By: Larry Nguyen{NL}CIS 200{NL}Fall 2022",
                "About Program 3");
        }

        // Precondition:    File, Exit Menu item activated
        // Postcondition:   The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition: Insert, Address menu item activated
        // Postcondition: The address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and st
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficent th
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result = result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // -- OR --
            // Not using StringBuilder, just use TextBox directly

            //reportTxt.Clear();
            //reportTxt.AppendText("Addresses:");
            //reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            //reportTxt.AppendText(NL);

            //foreach (Address a in upv.AddressList)
            //{
            //      reportTxt.AppendText(a.ToString());
            //      reportTxt.AppendText(NL)l
            //      reportTxt.AppendText("----------------------------");
            //      reportTxt.AppendText(NL);
            //}

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:    Insert, Letter menu item activated
        // Postcondition:   The Letter dialog box is displayed. If data entered
        //                  are OK, a Letter is created and added to the lsit
        //                  of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prog2.LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < Prog2.LetterForm.MIN_ADDRESSES) // Make sure we have enough
            {
                MessageBox.Show("Need " + Prog2.LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new Prog2.LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted
                }
                else // this should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:    Report, List Parcels menu item activated
        // Postcondition:   The lsit of parcels is displayed in the parcelResultsTxt
        //                  text box

        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This report is generated without using a StringBuilder, just to show an
            // alternative approach more like what most students will have done
            // Method AppendText is equivalent to using .Text +=

            decimal totalCost = 0;                      // Running total of parcel shipping
            string NL = Environment.NewLine;            // Newline shorthand

            reportTxt.Clear(); // Clear the textbox
            reportTxt.AppendText("Parcels:");
            reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            reportTxt.AppendText(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                reportTxt.AppendText(p.ToString());
                reportTxt.AppendText(NL);
                reportTxt.AppendText("-------------------------------");
                reportTxt.AppendText(NL);
                totalCost += p.CalcCost();
            }

            reportTxt.AppendText(NL);
            reportTxt.AppendText($"Total Cost: {totalCost:C}");

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter(); // object for serializing UPV in binary
            FileStream output = null;                          // stream for writing to a file
            DialogResult result;                               // result of file dialog box
            string fileName;                                   // name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file

                // retrieve the result of the dialog box
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specific file name
            } // end using

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {

                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // save file via FileStream if user specified valid file
                    
                    try
                    {
                        // open file with write access, create will overwrite existing file
                        output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

                        formatter.Serialize(output, upv); // Serialize whole UPV object
                    }
                    catch (IOException)
                    {
                        // Notify user if file could not be opened
                        MessageBox.Show("I/O Error Writing to File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    catch (SerializationException)
                    {
                        MessageBox.Show("Serialization Error Writing to File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        output?.Close(); // close FileStream if not null
                    }
                } // end else
            } // end if 
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter reader = new BinaryFormatter(); // objectr for seralizing upv in binary
            FileStream input = null;                        // stream for writing to a file
            DialogResult result;                            // result of file dialog box
            string fileName;                                // name of file to save data
            UserParcelView temp;                            // temporary holder for upv

            using (OpenFileDialog fileChooser = new OpenFileDialog()) // Creates an Openfile Dialog box
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; 
            }

            if (result == DialogResult.OK)
            {
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Create filestream to obtain read access file
                    try
                    {
                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        // get UPV from file
                        temp = (UserParcelView)reader.Deserialize(input);

                        upv = temp; // Separated in case deserialization failed
                    } // end try

                    // handle exception if there is a problem opening the file
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("I/O Error Reading from File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch

                    catch (SerializationException)
                    {
                        MessageBox.Show("Serialization Error Reading From File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        input?.Close(); // close FileStream if not null
                    }
                } // end else
            } // end if
        }

        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (upv.AddressList.Count > 0) // only edit if there are addresses!
            {
                ChooseAddressForm chooseAddForm = new ChooseAddressForm(upv.AddressList);
                DialogResult result = chooseAddForm.ShowDialog();

                if (result == DialogResult.OK) // onyl edit if ok
                {
                    int editIndex; // Index of address to edit
                    editIndex = chooseAddForm.AddressIndex;

                    if (editIndex >= 0) // -1 if didn't select item from combo box
                    {
                        Address editAddress = upv.AddressAt(editIndex);
                        AddressForm addressForm = new AddressForm();

                        // Populate form fields from selected address
                        addressForm.AddressName = editAddress.Name;
                        addressForm.Address1 = editAddress.Address1;
                        addressForm.Address2 = editAddress.Address2;
                        addressForm.City = editAddress.City;
                        addressForm.State = editAddress.State;

                        result = addressForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            addressForm.AddressName = editAddress.Name;
                            addressForm.Address1 = editAddress.Address1;
                            addressForm.Address2 = editAddress.Address2;
                            addressForm.City = editAddress.City;
                            addressForm.State = editAddress.State;
                            if (int.TryParse(addressForm.ZipText, out int zip))
                            {
                                editAddress.Zip = zip;
                            }
                            else
                            {
                                MessageBox.Show("Validation Error", "Error");
                            }
                        }
                        addressForm.Dispose();
                    }
                }
                chooseAddForm.Dispose();
            }
            else
                MessageBox.Show("Unable to edit addresses", "Validation Error");
        }

        private void Prog2Form_Load(object sender, EventArgs e)
        {

        }
    }
}
