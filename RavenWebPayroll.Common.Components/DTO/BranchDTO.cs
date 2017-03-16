using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenWebPayroll.Common.Components.DTO
{
    public class BranchDTO
    {
        private Guid id = Guid.Empty;
        private string locationName = string.Empty;
        private string address = string.Empty;
        private string phoneNumber = string.Empty;
        private string zipCode = string.Empty;

        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
    }
}
