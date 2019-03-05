using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string  allInfo;

        public ContactData()
        {
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()]", "") + "\r\n";

        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (TransformContactDetails(Email) + TransformContactDetails(Email2) + TransformContactDetails(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    return (Firstname + " " + Lastname + "\r\n" + TransformContactDetails(Address) + "\r\n" + TransformContactDetails(HomePhone) + TransformContactDetails(MobilePhone) + TransformContactDetails(WorkPhone) + "\r\n" + TransformContactDetails(Email) + TransformContactDetails(Email2) + TransformContactDetails(Email3)).Trim();

                }
            }
            set
            {
                allInfo = value;
            }
        }
        private string TransformContactDetails(string element)
        {
            if (element == null || element == "")
            {
                return null;
            }
            else
            {
                if (element == HomePhone)
                {
                    return ("H: " + element + "\r\n");
                }
                if (element == MobilePhone)
                {
                    return ("M: " + element + "\r\n");
                }
                if (element == WorkPhone)
                {
                    return ("W: " + element + "\r\n");
                }

                else return element + "\r\n";
            }
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 0;
            }
            int srav = Lastname.CompareTo(other.Lastname);
            if (srav !=0)
            {
                return srav;
            }
            else
            {
                return Firstname.CompareTo(other.Firstname);
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other)) 
            {
                return true;
            }

            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + (Firstname + " " + Lastname);
        }
    }
}
