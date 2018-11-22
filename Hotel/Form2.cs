using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must enter a suitable name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Program.GuestList.Add(new Guest()
                {
                    PrimaryName = textBox1.Text,
                    SecondaryName = textBox2.Text
                });

                MessageBox.Show("Guest " + String.Format("{0} {1}", textBox2.Text, textBox1.Text).ToUpper() + " has been created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
