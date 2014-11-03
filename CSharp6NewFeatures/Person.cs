using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6NewFeatures
{
    public class Person
    {
        //Auto-property initializers
        public string FirstName { get; set; } = "Juan";
        public string LastName { get; set; } = "Dela Cruz";
        public DateTime BirthDate { get; set; } = new DateTime(1898, 6, 12);

        //Get-only (read-only) auto properties
        public string OtherInformation { get; } = "Other information";

        public Address Address { get; set; }

        public Person()
        {

        }

        public Person(string firstname, string lastname, DateTime datetime)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = datetime;
        }

        //Expression bodied members
        public int Age => Convert.ToInt32(DateTime.Now.Subtract(BirthDate).Days / 365.25);

        //Expression bodied member with parameter
        public int AgeFrom(DateTime d) => Convert.ToInt32(d.Subtract(BirthDate).Days / 365.25);

        //Expression bodied member with multiple parameters
        public int Add(int x, int y) => x + y;
    }
}
