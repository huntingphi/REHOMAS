using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REHOMAS.BusinessLayer;
using REHOMAS.Business_Layer;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace REHOMAS.PresentationLayer
{
    public partial class UserControl1 : UserControl
    {
        Collection<Room> rooms;
        Form1 parentForm;
        BookingController bookingController;
        GuestController guestController;

        enum mode
        {
            VIEW = 0, UPDATE, ADD, DELETE
        }
        mode state = default(mode);
        bool editable = false;

        public GuestController GuestController {
            get
            {
                return guestController;

            }
            set { guestController = value;
                comboBoxGuestID.DataSource = guestController.AllGuests.ToList<Guest>();
                comboBoxBookingSearch.DisplayMember = "GuestID";

            }
        }

        internal BookingController BookingController { get => bookingController; set => bookingController = value; }
        internal Collection<Room> Rooms { get => rooms; set => rooms = value; }

        public UserControl1(UserControlGuest userControlGuest)
        {
            InitializeComponent();
            this.guestController = userControlGuest.GuestController;
            BookingController = new BookingController();
            setFieldsEnabled(false);
            Rooms = new Collection<Room>();
            Room room1 = new Room(1, 1, 600);
            Room room2 = new Room(2, 2, 1000);
            Room room3 = new Room(3, 1, 800);
            Room room4 = new Room(4, 4, 1500);
            Room room5 = new Room(5, 2, 1500);
            Room room6 = new Room(6, 4, 2000);
            Rooms.Add(room1);
            Rooms.Add(room2);
            Rooms.Add(room3);
            Rooms.Add(room4);
            Rooms.Add(room5);
            Rooms.Add(room6);
            comboBoxBookingSearch.DataSource = BookingController.AllBookings.Cast<Booking>().ToList();
            comboBoxBookingSearch.DisplayMember = "RefNo";

            try { setFields((Booking)BookingController.AllBookings.Cast<Booking>().ToList()[0]); } catch (Exception e) { Debug.WriteLine(e.StackTrace); }


        }



        private void UserControl1_Load(object sender, EventArgs e)
        {
            parentForm = (Form1)this.Parent;
            guestController = parentForm.GuestContoller;
        }



        private void buttonAddBooking_Click(object sender, EventArgs e)
        {

        }

        private Booking captureBooking()
        {
            string guestId = comboBoxGuestID.Text;
            //return new Booking(textBoxRefNo.Text, guestController.FindGuestByGuestID(guestId), dateTimePickerCheckIn.Value, dateTimePickerCheckOut.Value, (int)numericUpDownNoGuests.Value, true);
            int confirmed;

            if(labelDeposit.Text == "R 0")confirmed=-1;
            else confirmed = 0;
                return new Booking(textBoxRefNo.Text,(Guest) comboBoxGuestID.SelectedItem, dateTimePickerCheckIn.Value, dateTimePickerCheckOut.Value, (int)numericUpDownNoGuests.Value, confirmed);

        }

        private void refreshForm()
        {
            clearFields();
            comboBoxBookingSearch.DataSource = BookingController.AllBookings.Cast<Booking>().ToList();
            comboBoxBookingSearch.DisplayMember = "RefNo";
            //generateRef();
            updateStatusLabel();
            if(state == mode.VIEW)
            {
                setFieldsEnabled(false);
                buttonChanges.Text = "Remove Booking";
            }


        }



        void setFieldsEnabled(bool enabled)
        {
            textBoxRefNo.Enabled = enabled;
            comboBoxBookingSearch.Enabled = !enabled;
            dateTimePickerCheckIn.Enabled = enabled;
            dateTimePickerCheckOut.Enabled = enabled;
            comboBoxGuestID.Enabled = enabled;
            numericUpDownNoGuests.Enabled = enabled;
            //buttonChanges.Visible = enabled;
            //buttonCancel.Visible = enabled;
        }

        void clearFields()
        {
            textBoxRefNo.Text = "";
            comboBoxBookingSearch.Text = "";
            dateTimePickerCheckIn.Value = DateTime.Now;
            dateTimePickerCheckOut.Value = DateTime.Now.AddDays(1);

            numericUpDownNoGuests.Value = 1;
            //comboBoxGuestID.SelectedIndex = 0;
            //updateStatusLabel();
        }

        void setFields(Booking booking)
        {
            textBoxRefNo.Text = booking.RefNo;
            
            comboBoxBookingSearch.Text = "";
            dateTimePickerCheckIn.Value = booking.StartDate;
            dateTimePickerCheckOut.Value = booking.EndDate;

            numericUpDownNoGuests.Value = booking.NumPeople;
            comboBoxGuestID.SelectedItem = booking.Guest;
            textBoxRefNo.Text = booking.RefNo;
            int confirmed = booking.Confirmed;

            //switch (confirmed)
            //{
            //    case -1:
            //        //
            //        labelBookingStatus.ForeColor = Color.LimeGreen;
            //        labelBookingStatus.Text = "AVAILABLE";
            //        break;
            //    case 0:
            //        labelBookingStatus.ForeColor = Color.Orange;
            //        labelBookingStatus.Text = "UNCONFIRMED";
            //        break;
            //    case 1:
            //        labelBookingStatus.ForeColor = Color.Red;
            //        labelBookingStatus.Text = "UNAVAILABLE";
            //        break;

            //}
            updateStatusLabel();

        }
        private void buttonToggleEdit_Click_1(object sender, EventArgs e)
        {
            editable = !editable;
            if (state == mode.VIEW)
            {
                state = mode.UPDATE;
                buttonChanges.Text = "Finalise Changes";
                //buttonChanges.Visible = true;
                //buttonMakePayment.Visible = true;


            }
            else
            {
                state = mode.VIEW;
                buttonChanges.Text = "Remove Booking";
                //buttonChanges.Visible = false;
                //buttonMakePayment.Visible = false;

            }
            dateTimePickerCheckIn.Enabled = state == mode.UPDATE;
            dateTimePickerCheckOut.Enabled = state == mode.UPDATE;
            numericUpDownNoGuests.Enabled = state == mode.UPDATE;


            //MessageBox.Show("State: " + state);
            //MessageBox.Show("editable: " + editable);

            string img;
            object o;
            if (editable) img = "unlock";
            else img = "lock";
            o = Properties.Resources.ResourceManager.GetObject(img);

            Button b = (Button)sender;
            b.Image = o as Image;

        }

        private void buttonChanges_Click(object sender, EventArgs e)
        {
            
                    Booking b = captureBooking();
            Debug.WriteLine(b.Guest.GuestID);
            if (comboBoxGuestID.Text != "") {
                switch (state)
                {
                    case mode.ADD:

                        if (BookingAvailable(true)<1)
                {
                            state = mode.VIEW;
                            b.Confirmed = 0;
                    BookingController.DataMaintenance(b, DatabaseLayer.DB.DBOperation.Add);
                    MessageBox.Show("The booking was made!");
                    refreshForm();



                }
                else
                {
                    MessageBox.Show("The booking requested is unavailable. Please choose a check in, check out and room size that is available");

                }
                        //state = mode.VIEW;
                break;
                case mode.UPDATE:
                        state = mode.VIEW;
                        Debug.WriteLine(b == null);
                        Debug.WriteLine(b.Guest.GuestID);

                        BookingController.DataMaintenance(b, DatabaseLayer.DB.DBOperation.Edit);
                        MessageBox.Show("The booking was updated!");
                        refreshForm();
                        break;
                case mode.VIEW:
                        BookingController.DataMaintenance(new Booking(comboBoxBookingSearch.Text,null, new DateTime(), new DateTime(),0,0), DatabaseLayer.DB.DBOperation.Delete);
                        MessageBox.Show("The booking was removed!");
                        refreshForm();
                        break;
            }
            }
            else
            {
                if (MessageBox.Show("To continue you need to select a GuestID. Do you want to add a new guest?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                  
                    this.SendToBack();
                }
                
            }
            comboBoxBookingSearch.DataSource = BookingController.AllBookings.ToList<Booking>();
            BookingController.FinalizeChanges(b);
            if (guestController.AllGuests.Count == 0) buttonChanges.Visible = false;
            else buttonChanges.Visible = true;


        }

        private void buttonAddGuest_Click(object sender, EventArgs e)
        {
            state = mode.ADD;

            refreshForm();
            setFieldsEnabled(true);
            comboBoxBookingSearch.Enabled = true;
            editable = true;

            buttonChanges.Text = "Add Booking";
            buttonChanges.Visible = true;
            generateRef();


        }

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            updateStatusLabel();
        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            updateStatusLabel();
        }

        private void updateStatusLabel()
        {
            Debug.WriteLine(state);
            if (state != mode.VIEW)
            {
                Debug.WriteLine("?");

                if (BookingAvailable() == -1)
            {
                
                    labelBookingStatus.ForeColor = Color.LimeGreen;

                    labelBookingStatus.Text = "AVAILABLE";
                }
                else if (BookingAvailable() == 0)
                {
                    labelBookingStatus.ForeColor = Color.Orange;
                    labelBookingStatus.Text = "UNCONFIRMED";

                }
                else
                {
                    labelBookingStatus.ForeColor = Color.Red;
                    labelBookingStatus.Text = "UNAVAILABLE";

                }
                

            }
            else
            {
                if (BookingAvailable() == -1)
                {

                    labelBookingStatus.ForeColor = Color.LimeGreen;

                    labelBookingStatus.Text = "CONFIRMED";
                }
                else if (BookingAvailable() == 0)
                {
                    labelBookingStatus.ForeColor = Color.Orange;
                    labelBookingStatus.Text = "UNCONFIRMED";

                }
                else
                {
                    MessageBox.Show(BookingAvailable()+"");
                    labelBookingStatus.ForeColor = Color.Red;
                    labelBookingStatus.Text = "ERROR";

                }

            }

            int lowCost = 550;
            int midCost = 750;
            int hiCost = 995;
            DateRange dateRangeMid = new DateRange(new DateTime(2017, 12, 8), new DateTime(2017, 12, 15));
            DateRange dateRangeHi = new DateRange(new DateTime(2017, 12, 16), new DateTime(2017, 12, 31));

            if (dateRangeMid.Includes(captureBooking().StartDate))
            {
                setCosts(midCost, captureBooking());
            }

            else if (dateRangeHi.Includes(captureBooking().StartDate))
            {
                setCosts(hiCost, captureBooking());
            }
            else
            {
                setCosts(lowCost, captureBooking());
            }
        }

        void setCosts(int cost, Booking b)
        {
            int noDays = b.EndDate.DayOfYear - b.StartDate.DayOfYear;
            labelDailyCost.Text = "R " + cost;
            labelTotalCost.Text = "R " + cost * noDays;
            if (b.Confirmed > -1||state!=mode.VIEW)
            {
                labelDeposit.Text = "R " + cost * noDays * 0.1;
                buttonMakePayment.Visible = true;

            }
            else
            {
                labelDeposit.Text = "R 0";
                buttonMakePayment.Visible = false;
            }
        }


        private int BookingAvailable()
        {
            Object o = comboBoxBookingSearch.SelectedItem; 
            if (state != mode.VIEW||o is Booking==false)
            {
                Booking temp = captureBooking();
                foreach (Room room in Rooms)
                {
                    if (room.NoPeople == temp.NumPeople)
                    {
                        if (room.isAvailable(temp) < 1) return room.isAvailable(temp);
                    }
                }
                return 1;

            }
            else
            {
                Booking b =(Booking) comboBoxBookingSearch.SelectedItem;
                return b.Confirmed;
            }
            }
        private int BookingAvailable(bool add)
        {
            Booking temp = captureBooking();
            foreach (Room room in Rooms)
            {
                if (room.NoPeople == numericUpDownNoGuests.Value)
                {
                    if (room.isAvailable(temp)<1)
                    {
                        room.addBooking(temp);
                        return -1;
                    }
                }
            }
            return 1;

        }

        private void comboBoxGuestID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(state == mode.ADD)
            generateRef();
        }

        private void generateRef()
        {
            Guest guest = (Guest)comboBoxGuestID.SelectedItem;
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            textBoxRefNo.Text = guest.GuestID + unixTimestamp;
        }

        private void comboBoxBookingSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFields((Booking) comboBoxBookingSearch.SelectedItem);
            updateStatusLabel();

        }

        private void buttonMakePayment_Click(object sender, EventArgs e)
        {
            try
            {
                labelDeposit.Text = "R 0";
                state = mode.UPDATE;
                buttonChanges_Click(new Object(), new EventArgs());
                state = mode.VIEW;
                updateStatusLabel();
            }catch( Exception)
            {
                MessageBox.Show("You need to add the booking before you make the payment!");
            }
        }

        private void numericUpDownNoGuests_ValueChanged(object sender, EventArgs e)
        {
            updateStatusLabel();
        }
    }
}