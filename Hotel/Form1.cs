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
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int amount = 10;

            for (int i = 1; i <= amount; i++)
            {
                Program.RoomList.Add(new Room()
                {
                    ID = i,
                    Code = random.Next(1000, 9999)
                });
            }

            RefreshRoomList();
            RefreshGuestList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshRoomList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshGuestList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                form2.StartPosition = FormStartPosition.CenterParent;
                form2.ShowDialog();
            }

            RefreshGuestList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Guest guestItem = (Guest)listBox2.SelectedItem;

            if (Program.GuestList.Contains(guestItem))
            {
                var confirm = MessageBox.Show(String.Format("Are you sure you want to remove Guest {0}?", guestItem.GetName), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    Program.GuestList.Remove(guestItem);
                }

                RefreshGuestList();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Room roomItem = (Room)listBox1.SelectedItem;

            if (Program.RoomList.Contains(roomItem))
            {
                using (Form4 form4 = new Form4(roomItem))
                {
                    form4.StartPosition = FormStartPosition.CenterParent;
                    form4.ShowDialog();
                }
            }

            RefreshRoomList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Guest guestItem = (Guest)listBox2.SelectedItem;

            if (Program.GuestList.Contains(guestItem))
            {
                using (Form3 form3 = new Form3(guestItem))
                {
                    form3.StartPosition = FormStartPosition.CenterParent;
                    form3.ShowDialog();
                }

                RefreshGuestList();
            }
        }

        private void RefreshGuestList()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = Program.GuestList.OrderBy(x => x.SecondaryName).ToList();
            listBox2.DisplayMember = "GetName";
        }

        private void RefreshRoomList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = Program.RoomList;
            listBox1.DisplayMember = "GetRoom";
        }
    }
}
