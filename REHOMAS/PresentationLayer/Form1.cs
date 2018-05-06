using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REHOMAS.Business_Layer;
using REHOMAS.BusinessLayer;

namespace REHOMAS.PresentationLayer
{
    // TODO: allow form to access bookingcontroller to be shared by bookingform if needed and make sure everything calls pageChange that needs to
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GuestContoller = userControlGuest1.GuestController;

        }

        GuestController guestContoller;

        public GuestController GuestContoller { get => guestContoller; set => guestContoller = value; }

        private void label1_Click(object sender, EventArgs e)
        {

        }







        private void hideIndicators()
        {
            panelGuestsSelected.Visible = false;
            panelHomeSelected.Visible = false;
            panelRoomsSelected.Visible = false;
            panelLogOutSelected.Visible = false;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            hideIndicators();
            panelHomeSelected.Visible = true;
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            hideIndicators();
            panelRoomsSelected.Visible = true;
            userControl11.GuestController = userControlGuest1.GuestController;
            userControl11.BringToFront();
            pageChange();


        }

        private void buttonGuests_Click(object sender, EventArgs e)
        {
            hideIndicators();
            panelGuestsSelected.Visible = true;
            userControlGuest1.BringToFront();
            pageChange();

        }

        private void buttonPayments_Click(object sender, EventArgs e)
        {
            hideIndicators();
            panelLogOutSelected.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
                ConsoleApplication.ReadWriteObject.writeObjectsToFile(userControl11.Rooms);
            Application.Exit();

        }

        private void userControlGuest1_Load(object sender, EventArgs e)
        {

        }

        private void pageChange()
        {
            GuestContoller = userControlGuest1.GuestController;

        }
    }
}
