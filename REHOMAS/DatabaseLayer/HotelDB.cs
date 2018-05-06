using REHOMAS.Business_Layer;
using REHOMAS.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace REHOMAS.DatabaseLayer
{
    class HotelDB : DB
    {
        private string guestTable = "Guest";
        private string queryAllGuests = "SELECT * FROM Guest";

        private Collection<Guest> guests;

        internal Collection<Guest> Guests { get => guests; set => guests = value; }
        private string bookingTable = "Booking";
        private string queryAllBookings = "SELECT * FROM Booking";

        private Collection<Booking> bookings;

        internal Collection<Booking> Bookings { get => bookings; set => bookings = value; }
        internal Collection<Room> Rooms { get => rooms; set => rooms = value; }

        private string roomTable = "Room";
        private string queryAllRooms = "SELECT * FROM Room";
        private Collection<Room> rooms;



        //public struct ColumnAttribs
        //{
        //    public string myName;
        //    public SqlDbType myType;
        //    public int mySize;
        //}

        public HotelDB() : base()
        {
            guests = new Collection<Guest>();
            FillDataSet(queryAllGuests, guestTable);
            PopulateGuestList(guestTable);
            FillDataSet(queryAllBookings, bookingTable);
            PopulateBookingList(bookingTable);
        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Guest aGuest, DB.DBOperation operation)
        {
            Debug.WriteLine(aGuest.ID+" : "+aGuest.GuestID);
            DataRow aRow = null;
            string dataTable = guestTable;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aGuest, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
                    FillRow(aRow, aGuest, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
                    aRow.Delete();
                    break;
            }


        }

        public void DataSetChange(Booking aBooking, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = bookingTable;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aBooking, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aBooking, dataTable)];
                    FillRow(aRow, aBooking, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aBooking, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
            #endregion

            #region Guest utilities
            private int FindRow(Guest aGuest, string dataTable)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[dataTable].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //In c# there is no item property (but we use the 2-dim array) it is automatically known to the compiler when used as below
                    if (aGuest.ID == Convert.ToString(dsMain.Tables[dataTable].Rows[rowIndex]["ID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }
        private int FindRow(string GuestID, string dataTable)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[dataTable].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //In c# there is no item property (but we use the 2-dim array) it is automatically known to the compiler when used as below
                    if (GuestID == Convert.ToString(dsMain.Tables[dataTable].Rows[rowIndex]["GuestID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }

            private Guest findGuestByGuestID(string guestID)
        {
            return guests[FindRow(guestID, "Guest")];
        }

        private void FillRow(DataRow aRow, Guest aGuest, DBOperation operation)
        {
            Debug.WriteLine(aGuest.ID + " : " + aGuest.GuestID);

            if (operation == DB.DBOperation.Add)
            {
                aRow["ID"] = aGuest.ID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["GuestID"] = aGuest.GuestID;
            }
            aRow["Name"] = aGuest.Name;
            aRow["Phone"] = aGuest.Phone;
            aRow["Email"] = aGuest.Email;
            Debug.WriteLine(aRow["ID"] + " : " + aRow["GuestID"]);

            //*** For each role add the specific data variables
        }






        private void PopulateGuestList(string table)
        {
            DataRow myRow = null;
            Guest aGuest;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Customer object
                    aGuest = new Guest();
                    //Obtain each customer attribute from the specific field in the row in the table
                    aGuest.ID = Convert.ToString(myRow["ID"]).TrimEnd();
                    //Do the same for all other attributes
                    aGuest.GuestID = Convert.ToString(myRow["GuestID"]).TrimEnd();
                    //***The code below shows thee test for database Null values
                    if (myRow["Name"] == System.DBNull.Value)
                    { aGuest.Name = ""; }
                    else { aGuest.Name = Convert.ToString(myRow["Name"]).TrimEnd(); }
                    aGuest.Phone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    aGuest.Email = Convert.ToString(myRow["Email"]).TrimEnd();

                    guests.Add(aGuest);
                }
            }


        }
        #endregion
        #region Bookings
        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Guest aGuest)
        {
            //Create Parameters to communicate with SQL INSERT
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@GuestID", SqlDbType.NVarChar, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);
            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@Email", SqlDbType.NVarChar, 100, "Email");
            daMain.InsertCommand.Parameters.Add(param);
        }
        private void Build_UPDATE_Parameters(Guest aGuest)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do for all fields other than ID and CID as for Insert 
            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 100, "Email");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Guest_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Booking_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@RefNo", SqlDbType.NVarChar, 15, "RefNo");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }


        private void Create_INSERT_Command(Guest aGuest)
        {
            //Create the command that must be used to insert values into the Books table..
            daMain.InsertCommand = new SqlCommand("INSERT into Guest (ID, GuestID, Name, Phone, Email) VALUES (@ID, @GuestID, @Name, @Phone, @Email)", cnMain);

            Build_INSERT_Parameters(aGuest);
        }

        private void Create_UPDATE_Command(Guest aGuest)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and GuestID cannot be changed



            daMain.UpdateCommand = new SqlCommand("UPDATE Guest SET Name =@Name, Phone =@Phone, Email =@Email " + "WHERE ID = @Original_ID", cnMain);

            Build_UPDATE_Parameters(aGuest);
        }

        private string Create_DELETE_Command(Guest aGuest)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table

            daMain.DeleteCommand = new SqlCommand("DELETE FROM Guest WHERE ID = @ID", cnMain);
            try
            {
                Build_DELETE_Guest_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }
        public bool UpdateDataSource(Guest aGuest)
        {
            bool success = true;
            Create_INSERT_Command(aGuest);
            Create_UPDATE_Command(aGuest);
            Create_DELETE_Command(aGuest);
            success = UpdateDataSource(queryAllGuests, guestTable);

            return success;
        }
        #endregion

        #region Booking utilities
        //Find by refNo
        private int FindRow(Booking aBooking, string dataTable)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[dataTable].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    if (aBooking.RefNo == Convert.ToString(dsMain.Tables[dataTable].Rows[rowIndex]["RefNo"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }

        private void FillRow(DataRow aRow, Booking aBooking, DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {
                aRow["RefNo"] = aBooking.RefNo;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["GuestID"] = aBooking.Guest.GuestID;
            }
            aRow["NoPeople"] = aBooking.NumPeople;
            aRow["CheckIn"] = aBooking.StartDate;
            aRow["CheckOut"] = aBooking.EndDate;
            aRow["Confirmed"] = aBooking.Confirmed;
        }






        private void PopulateBookingList(string table)
        {
            bookings = new Collection<Booking>();
            DataRow myRow = null;
            Booking aBooking;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Customer object
                    aBooking = new Booking();
                    //Obtain each customer attribute from the specific field in the row in the table
                    aBooking.RefNo = Convert.ToString(myRow["RefNo"]).TrimEnd();
                    string guestId = Convert.ToString(myRow["GuestID"]).TrimEnd();
                    aBooking.Guest = findGuestByGuestID(guestId);
                    //if (myRow["Name"] == System.DBNull.Value)
                    //{ aGuest.Name = ""; }
                    //else {
                    aBooking.NumPeople = Convert.ToInt32(myRow["NoPeople"]);
                //}
                    aBooking.StartDate = Convert.ToDateTime(myRow["CheckIn"]);
                    aBooking.EndDate = Convert.ToDateTime(myRow["CheckOut"]);
                    aBooking.Confirmed = Convert.ToInt32(myRow["Confirmed"]);

                    bookings.Add(aBooking);
                }
            }


        }
        #endregion

        #region Booking: Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Booking aBooking)
        {
            //Create Parameters to communicate with SQL INSERT
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@RefNo", SqlDbType.NVarChar, 15, "RefNo");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@GuestID", SqlDbType.NVarChar, 10, "GuestID");
            daMain.InsertCommand.Parameters.Add(param);
            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@NoPeople", SqlDbType.NVarChar, 100, "NoPeople");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@CheckIn", SqlDbType.DateTime,100, "CheckIn");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@CheckOut", SqlDbType.DateTime, 100, "CheckOut");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@Confirmed", SqlDbType.Int,1, "Confirmed");
            daMain.InsertCommand.Parameters.Add(param);
        }
        private void Build_UPDATE_Parameters(Booking aBooking)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@CheckIn", SqlDbType.DateTime, 100, "CheckIn");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do for all fields other than ID and CID as for Insert 
            param = new SqlParameter("@CheckOut", SqlDbType.DateTime, 100, "CheckOut");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Confirmed", SqlDbType.Int, 1, "Confirmed");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@NoPeople", SqlDbType.Int, 100, "NoPeople");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_RefNo", SqlDbType.NVarChar, 15, "RefNo");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_BY_GUESTID_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@RefNo", SqlDbType.NVarChar, 15, "RefNo");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Booking aBooking)
        {
            //Create the command that must be used to insert values into the Books table..
            daMain.InsertCommand = new SqlCommand("INSERT into Booking (RefNo, GuestID, NoPeople, CheckIn, CheckOut, Confirmed) VALUES (@RefNo, @GuestID, @NoPeople, @CheckIn, @CheckOut, @Confirmed)", cnMain);

            Build_INSERT_Parameters(aBooking);
        }

        private void Create_UPDATE_Command(Booking aBooking)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and BookingID cannot be changed



            daMain.UpdateCommand = new SqlCommand("UPDATE Booking SET NoPeople=@NoPeople, CheckIn=@CheckIn, CheckOut=@CheckOut, Confirmed=@Confirmed " + "WHERE RefNo = @Original_RefNo", cnMain);

            Build_UPDATE_Parameters(aBooking);
        }

        private string Create_DELETE_Command_Using_RefNo(Booking aBooking)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table

            daMain.DeleteCommand = new SqlCommand("DELETE FROM Booking WHERE RefNo = @RefNo", cnMain);
            try
            {
                Build_DELETE_Booking_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }
        public bool UpdateDataSource(Booking aBooking)
        {
            bool success = true;
            Create_INSERT_Command(aBooking);
            Create_UPDATE_Command(aBooking);
            Create_DELETE_Command_Using_RefNo(aBooking);
            success = UpdateDataSource(queryAllBookings, bookingTable);

            return success;
        }
        #endregion
        #endregion

//#region rooms

    }

}
