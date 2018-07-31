using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using GeekRegistrationSystemCore.Constants;
using System;

namespace GeekRegistrationSystemCore
{
    public class CandidateRepo : ICandidateRepo
    {
        public List<CandidateDetails> GetCandidateByTechnology(string technology)
        {
            var candidateList = new List<CandidateDetails>();
            var con = new SQLiteConnection(Database.connectionString);
            try
            {
                using (con)
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(Database.getCandidateDetailsByTechnology, con))
                    {
                        cmd.Parameters.AddWithValue("@technology", technology.ToUpper());
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var candidate = new CandidateDetails
                                {
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Technology = reader["Technology"].ToString(),
                                };
                                candidateList.Add(candidate);
                            }
                        }
                    }
                }
                return candidateList.Any() ? candidateList.ToList() : null;
            }
            catch(Exception)
            {
                throw new Exception("Please check your request!!!");
            }
        }

        public List<CandidateDetails> GetCandidateDetails()
        {
            var candidateList = new List<CandidateDetails>();
            var con = new SQLiteConnection(Database.connectionString);
            try
            {
                using (con)
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(Database.getCandidateDetails, con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var candidate = new CandidateDetails
                                {
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Technology = reader["Technology"].ToString(),
                                };
                                candidateList.Add(candidate);
                            }
                        }
                    }
                }
                return candidateList.Any() ? candidateList.ToList() : null;
            }
            catch (Exception)
            {
                throw new Exception("Please check your request!!!");
            }
        }

        public void RegisterCandidate(CandidateDetails candidateDetails)
        {
            var firstname = candidateDetails.FirstName;
            var lastname = candidateDetails.LastName;
            var technology = candidateDetails.Technology;

            var con = new SQLiteConnection(Database.connectionString);
            try
            {
                using (con)
                {
                    using (var cmd = new SQLiteCommand(Database.registerCandidate, con))
                    {
                        cmd.Parameters.AddWithValue("@firstname", firstname);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@technology", technology);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Please check your request!!!");
            }
        }
    }
}
