using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRunner
{
    public class Client
    {
        public int Id;

        public string FirstName
        {
            get
            {
                var firstName = "f";//... //<call to get from database via Id>

            return firstName;
            }
        }

        public string MiddleName
        {
            get
            {
                var middleName = "m";// //<call to get from database via Id>

                return middleName;
            }
        }

        public string LastName
        {
            get
            {
                var lastName = "l";//... //<call to get from database via Id>

                return lastName;
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

        public int GetMatchCount(IEnumerable<string> clientFirstNames, IEnumerable<string> clientMiddleNames, IEnumerable<string> clientLastNames)
        {
            var clientFullNames = BuildMatchArray(clientFirstNames, clientMiddleNames, clientLastNames);
            return clientFullNames.Count(x => x == FullName);
        }


        public string[] BuildMatchArray(IEnumerable<string> clientFirstNames, IEnumerable<string> clientMiddleNames, IEnumerable<string> clientLastNames)
        {
            Debug.Assert(clientFirstNames.Count() == clientMiddleNames.Count() && clientMiddleNames.Count() == clientLastNames.Count());

            var firstAndMiddle = clientFirstNames.Zip(clientMiddleNames, (a, b) => a + " " + b).ToList();
            return firstAndMiddle.Zip(clientLastNames, (a, b) => a + " " + b).ToArray();

        }
    }

}
