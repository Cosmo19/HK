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
    public partial class Form4 : Form
    {
        private Room _roomItem;

        Random random = new Random();

        public Form4(Room roomItem)
        {
            InitializeComponent();

            _roomItem = roomItem;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            RefreshForm4();
        }

        private void RefreshForm4()
        {
            this.Text = String.Format("Room {0}", _roomItem.ID);

            label1.Text = String.Format("Room Number: {0}", _roomItem.ID);
            label2.Text = String.Format("Room Code: {0}", _roomItem.Code);

            if (_roomItem.CodeList.Any())
                label3.Text = String.Format("Last Code: {1}", _roomItem.CodeList.Count, _roomItem.CodeList.Last());
            else
                label3.Text = "None";

            codeListBox.DataSource = _roomItem.CodeList.ToList();

            guestListBox.DataSource = Program.GuestList.Where(x => _roomItem == x.Room).OrderBy(a => a.SecondaryName).ToList();
            guestListBox.DisplayMember = "GetName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(String.Format("Are you sure you want to reset Room {0}'s code?", _roomItem.ID), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                _roomItem.CodeList.Add(_roomItem.Code);
                _roomItem.Code = random.Next(1000, 9999);
            }

            RefreshForm4();
        }
    }
}
