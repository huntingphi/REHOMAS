using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REHOMAS
{
    public abstract class Person
    {
        private string id;
        private string name;
        private string phone;
        private string email;

        #region Properties

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public string Email { get => email; set => email = value; }
        #endregion

        #region Constructors
        public Person()
        {
            id = "";
            name = "";
            phone = "";
            email = "";
        }

        public Person(string idVal, string nameVal, string phoneVal, string emailVal)
        {
            id = idVal;
            name = nameVal;
            phone = phoneVal;
            email = emailVal;
        }
        #endregion

        public override string ToString()
        {
            return name + '\n' + phone;
        }
    }
}
