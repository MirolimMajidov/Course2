using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.UnitTesting.NUnitTest.NSubstitute
{
    public class User
    {
        private string _firstName;

        public virtual string FirstName
        {
            get
            {
                return _firstName ?? string.Empty;
            }
            set
            {
                _firstName = value;
            }
        }

        public virtual string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
