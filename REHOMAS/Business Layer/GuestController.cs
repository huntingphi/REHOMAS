using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REHOMAS.DatabaseLayer;


namespace REHOMAS.BusinessLayer
{
    public class GuestController
    {

        HotelDB hotelDB;
        Collection<Guest> guests;   //***W3

        #region Properties
        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }
        #endregion

        public GuestController()
        {
            //***instantiate the HotelDB object to communicate with the database
            hotelDB = new HotelDB();
            guests = hotelDB.Guests;
        }

        #region Database Communication
        public void DataMaintenance(Guest aGuest, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            hotelDB.DataSetChange(aGuest, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:                                    
                    //*** Add the guest to the Collection
                    guests.Add(aGuest);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aGuest);
                    guests[index] = aGuest;  // replace guest at this index with the updated guest
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);  // find the index of the specific guest in collection
                    guests.RemoveAt(index);  // remove that guest form the collection
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Guest guest)
        {
            //***call the HotelDB method that will commit the changes to the database
            return hotelDB.UpdateDataSource(guest);
        }
        #endregion

        #region Search Methods
        //This method  (function) searched through all the employess to finds onlly those with the required role
        //public Collection<Guest> FindByRole(Collection<Guest> emps, Role.RoleType roleVal)
        //{
        //    Collection<Guest> matches = new Collection<Guest>();

        //    foreach (Guest emp in emps)
        //    {
        //        if (emp.role.RoleValue == roleVal)
        //        {
        //            matches.Add(emp);
        //        }
        //    }
        //    return matches;
        //}

        //public Collection<Guest> FindByRole(Role.RoleType roleVal)
        //{
        //    Collection<Guest> matches = new Collection<Guest>();

        //    foreach (Guest emp in guests)
        //    {
        //        if (emp.role.RoleValue == roleVal)
        //        {
        //            matches.Add(emp);
        //        }
        //    }
        //    return matches;
        //}
        //This method receives a guest ID as a parameter; finds the guest object in the collection of guests and then returns this object
        public Guest Find(string ID)
        {
            int index = 0;
            bool found = (guests[index].ID == ID);  //check if it is the first student
            int count = guests.Count;
            while (!(found) && (index < guests.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (guests[index].ID == ID);   // this will be TRUE if found
            }
            return guests[index];  // this is the one!  
        }

        public Guest FindGuestByGuestID(string GuestID)
        {
            int index = 0;
            bool found = (guests[index].GuestID == GuestID);  //check if it is the first student
            int count = guests.Count;
            while (!(found) && (index < guests.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (guests[index].GuestID == GuestID);   // this will be TRUE if found
            }
            return guests[index];  // this is the one!  
        }

        public int FindIndex(Guest aGuest)
        {
            int counter = 0;
            bool found = false;
            found = (aGuest.ID== guests[counter].ID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < guests.Count - 1)
            {
                counter += 1;
                found = (aGuest.ID == guests[counter].ID);
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
