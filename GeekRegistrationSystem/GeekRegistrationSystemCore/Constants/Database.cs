using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekRegistrationSystemCore.Constants
{
    public class Database
    {
        //SQLLite connection string and query
        public const string connectionString = @"Data Source = C:\Users\dell\Desktop\GRSDB\GeekHunter.sqlite; Version=3;";
        public const string getCandidateDetails = @"SELECT FirstName, LastName, Technology FROM Candidate";
        public const string getCandidateDetailsByTechnology = @"SELECT FirstName, LastName, Technology FROM Candidate Where Upper(Technology) = @technology";
        public const string registerCandidate = @"Insert into Candidate(FirstName, LastName, Technology) Values(@firstname, @lastname, @technology)";
    }
}
