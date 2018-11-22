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
    public partial class Form3 : Form
    {
        private Guest _guestItem;

        public Form3(Guest guestItem)
        {
            InitializeComponent();

            _guestItem = guestItem;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            RefreshForm3();

            roomListBox.DataSource = Program.RoomList;
            roomListBox.DisplayMember = "GetRoom";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room roomItem = (Room)roomListBox.SelectedItem;

            if (Program.RoomList.Contains(roomItem))
            {
                var confirm = MessageBox.Show(String.Format("Are you sure you want to set Guest {0} into Room {1}?", _guestItem.GetName, roomItem.ID), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (confirm == DialogResult.Yes)
                {
                    _guestItem.Room = roomItem;
                }

                RefreshForm3();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(String.Format("Are you sure you want to reset {0}'s room?", _guestItem.GetName), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                _guestItem.Room = null;
            }

            RefreshForm3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.GuestList.Contains(_guestItem))
            {
                var confirm = MessageBox.Show(String.Format("Are you sure you want to remove Guest {0}?", _guestItem.GetName), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    Program.GuestList.Remove(_guestItem);

                    this.Close();
                }
            }
        }

        private void RefreshForm3()
        {
            this.Text = String.Format("{0} {1}", _guestItem.PrimaryName, _guestItem.SecondaryName);

            label1.Text = String.Format("Primary Name: {0}", _guestItem.PrimaryName);
            label2.Text = String.Format("Secondary Name: {0}", _guestItem.SecondaryName);

            if (_guestItem.Room == null)
                label3.Text = "Room: None";
            else
                label3.Text = String.Format("Room: {0}", _guestItem.Room.ID);
        }
    }
}
