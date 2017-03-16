using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenWebPayroll.Common.Components.DTO
{
    public class CompanyInformationDTO
    {
        private string companyName = string.Empty;
        private string address = string.Empty;
        private string phoneNumber = string.Empty;
        private string zipCode = string.Empty;
        private string taxID = string.Empty;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string TIN
        {
            get { return taxID; }
            set { taxID = value; }
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
