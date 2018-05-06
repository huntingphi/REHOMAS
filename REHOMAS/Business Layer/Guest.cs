using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REHOMAS.BusinessLayer
{
    public class Guest:Person
    {
        #region Data members
        
        private string guestID;

        public Guest(string ID, string name, string phone, string email, string guestID):base(ID, name, phone, email)
        {
            GuestID = guestID;
        }
        public Guest() { }



        #endregion

        #region Properties
        public string GuestID
        {
            get
            {
                return guestID;
            }
            set
            {
                guestID = value;
            }
        }
        #endregion

        
        //***One can add a ToString method here to override the ToString method of a Person object
        public override string ToString()
        {
            return this.guestID + ":    " + this.Name;
        }
    }
}

