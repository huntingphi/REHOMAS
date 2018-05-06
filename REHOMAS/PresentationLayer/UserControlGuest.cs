using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using REHOMAS.BusinessLayer;

namespace REHOMAS.PresentationLayer
{
    public partial class UserControlGuest : UserControl
    {
        GuestController guestController;
        enum mode
        {
           VIEW = 0, UPDATE, ADD, DELETE
        }
        mode state = default(mode);
        bool editable = false;

        public GuestController GuestController { get => guestController; set => guestController = value; }

        public UserControlGuest()
        {
            InitializeComponent();

            GuestController = new GuestController();
            setFieldsEnabled(false);
            comboBoxGuestSearch.SelectedIndexChanged += ComboBoxGuestSearch_SelectedIndexChanged;
            refreshForm();
        }

        private void ComboBoxGuestSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            Guest selected = (Guest)box.SelectedItem;
            //setFields(selected);
        }

        private void buttonToggleEdit_Click(object sender, EventArgs e)
        {
            editable = !editable;
            string img;
            object o;
            if (editable)
            {
                img = "unlock";
                buttonChanges.Text = "Finalize Changes";
                buttonCancel.Text = "Delete";

                state = mode.UPDATE;
            }
            else {
                img = "lock";
                state = mode.VIEW;


            }
            o = Properties.Resources.ResourceManager.GetObject(img);
           
            Button b = (Button)sender;
            b.Image = o as Image;
            setFieldsEnabled(editable);
        }


        void setFieldsEnabled(bool enabled)
        {
            //guestIDTextBox.Enabled = enabled;
            comboBoxGuestSearch.Enabled = !enabled;
            nameTextBox.Enabled = enabled;
            emailTextBox.Enabled = enabled;
            phoneTextBox.Enabled = enabled;
            //idTextBox.Enabled = enabled;
            comboBoxActiveBookings.Enabled = enabled;
            comboBoxPaymentMethods.Enabled = enabled;
            buttonChanges.Visible = enabled;
            buttonCancel.Visible = enabled;
        }

        void clearFields()
        {
            guestIDTextBox.Text = "";
            comboBoxGuestSearch.Text = "";
            nameTextBox.Text = "";
            phoneTextBox.Text =  "";
            idTextBox.Text = "";
            emailTextBox.Text = "";
            comboBoxActiveBookings.Text = "";
            comboBoxPaymentMethods.Text = "";
        }

        void setFields(Guest guest)
        {
            guestIDTextBox.Text = guest.GuestID;
            comboBoxGuestSearch.SelectedItem = guest;
            nameTextBox.Text = guest.Name;
            phoneTextBox.Text = guest.Phone;
            idTextBox.Text = guest.ID;
            emailTextBox.Text = guest.Email;
            comboBoxActiveBookings.Text = "";
            comboBoxPaymentMethods.Text = "";
        }

        private void buttonAddGuest_Click(object sender, EventArgs e)
        {
            idTextBox.Enabled = true;
            guestIDTextBox.Enabled = true;
            clearFields();
            buttonChanges.Text = "Add Guest";
            buttonCancel.Text = "Cancel";

            setFieldsEnabled(true);
            state = mode.ADD;
        }

        private void buttonChanges_Click(object sender, EventArgs e)
        {
            Guest newGuest = captureGuest();
            switch (state){
                case mode.VIEW:
                    break;
                case mode.ADD:
                    GuestController.DataMaintenance(newGuest, DatabaseLayer.DB.DBOperation.Add);
                    MessageBox.Show(newGuest.Name+" has been added succeessfully!");
                    editable = false;
                    state = mode.VIEW;
                    refreshForm();
                    idTextBox.Enabled = false;
                    guestIDTextBox.Enabled = false;
                    break;
                case mode.UPDATE:
                    GuestController.DataMaintenance(newGuest, DatabaseLayer.DB.DBOperation.Edit);
                    MessageBox.Show(newGuest.Name + " has been changed succeessfully!");
                    editable = false;
                    state = mode.VIEW;
                    refreshForm();

                    break;
                case mode.DELETE:
                    //GuestController.DataMaintenance(newGuest, DatabaseLayer.DB.DBOperation.Delete);
                    //MessageBox.Show(newGuest.Name + " has been deleted succeessfully!");
                    editable = false;
                    state = mode.VIEW;
                    refreshForm();
                    comboBoxGuestSearch.Enabled = true;

                    break;
            }
            refreshForm();

            MessageBox.Show(GuestController.FinalizeChanges(newGuest)+"");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (state == mode.UPDATE)
            {
                Guest newGuest = captureGuest();

                GuestController.DataMaintenance(newGuest, DatabaseLayer.DB.DBOperation.Delete);
                MessageBox.Show(newGuest.Name + " has been deleted succeessfully!");
                //editable = false;
                //state = mode.DELETE;
                refreshForm();
                // clearFields();
                //setFieldsEnabled(false);
            }
            else
            {
                state = mode.VIEW;
                refreshForm();
            }
        }

        private Guest captureGuest()
        {
            return new Guest(idTextBox.Text,nameTextBox.Text,phoneTextBox.Text,emailTextBox.Text,guestIDTextBox.Text);
        }

        private void refreshForm()
        {
            clearFields();

            List<Guest> guestList = GuestController.AllGuests.Cast<Guest>().ToList();
            comboBoxGuestSearch.DataSource = guestList;
            comboBoxGuestSearch.DisplayMember = "GuestID";
            if(guestList.Count>0)comboBoxGuestSearch.SelectedItem = comboBoxGuestSearch.FindStringExact(guestList[guestList.Count-1].GuestID);
            setFieldsEnabled(editable);
            idTextBox.Enabled = false;
            guestIDTextBox.Enabled = false;


        }

        private void comboBoxGuestSearch_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Guest selected = (Guest)comboBoxGuestSearch.SelectedValue;
            setFields(selected);
        }
    }
}
