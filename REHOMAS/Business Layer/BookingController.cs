using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REHOMAS.DatabaseLayer;

namespace REHOMAS.Business_Layer
{
    class BookingController
    {
        HotelDB hotelDB;
        Collection<Booking> bookings;   //***W3

        #region Properties
        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }
        #endregion

        public BookingController()
        {
            //***instantiate the HotelDB object to communicate with the database
            hotelDB = new HotelDB();
            bookings = hotelDB.Bookings;
        }

        #region Database Communication
        public void DataMaintenance(Booking aBooking, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            hotelDB.DataSetChange(aBooking, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the booking to the Collection
                    bookings.Add(aBooking);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aBooking);
                    bookings[index] = aBooking;  // replace booking at this index with the updated booking
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aBooking);  // find the index of the specific booking in collection
                    bookings.RemoveAt(index);  // remove that booking form the collection
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Booking booking)
        {
            //***call the HotelDB method that will commit the changes to the database
            return hotelDB.UpdateDataSource(booking);
        }
        #endregion

        #region Search Methods
        //This method  (function) searched through all the employess to finds onlly those with the required role
        //public Collection<Booking> FindByRole(Collection<Booking> emps, Role.RoleType roleVal)
        //{
        //    Collection<Booking> matches = new Collection<Booking>();

        //    foreach (Booking emp in emps)
        //    {
        //        if (emp.role.RoleValue == roleVal)
        //        {
        //            matches.Add(emp);
        //        }
        //    }
        //    return matches;
        //}

        //public Collection<Booking> FindByRole(Role.RoleType roleVal)
        //{
        //    Collection<Booking> matches = new Collection<Booking>();

        //    foreach (Booking emp in bookings)
        //    {
        //        if (emp.role.RoleValue == roleVal)
        //        {
        //            matches.Add(emp);
        //        }
        //    }
        //    return matches;
        //}
        //This method receives a booking ID as a parameter; finds the booking object in the collection of bookings and then returns this object
        public Booking Find(string RefNo)
        {
            int index = 0;
            bool found = (bookings[index].RefNo == RefNo);  //check if it is the first student
            int count = bookings.Count;
            while (!(found) && (index < bookings.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (bookings[index].RefNo == RefNo);   // this will be TRUE if found
            }
            return bookings[index];  // this is the one!  
        }

        public Booking FindBookingByBookingGuestID(string GuestID)
        {
            int index = 0;
            bool found = (bookings[index].Guest.GuestID == GuestID);  //check if it is the first student
            int count = bookings.Count;
            while (!(found) && (index < bookings.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (bookings[index].Guest.GuestID == GuestID);   // this will be TRUE if found
            }
            return bookings[index];  // this is the one!  
        }

        public int FindIndex(Booking aBooking)
        {
            int counter = 0;
            bool found = false;
            found = (aBooking.RefNo == bookings[counter].RefNo);   //using a Boolean Expression to initialise found
            while (!(found) & counter < bookings.Count - 1)
            {
                counter += 1;
                found = (aBooking.RefNo == bookings[counter].RefNo);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}
