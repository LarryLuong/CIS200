// Grading ID: 5317169

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS200E2P3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text); // Adds textbox text to listbox
            textBox1.Clear();                  // clears textbox for next entry
            textBox1.Focus();                  // Put cursor at start of textbox
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine;

            MessageBox.Show($"Grading ID: 5317169", "CIS200E2P3"); // Displays grading id and program name
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exits application
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
